/* ePresenter is licensed under the GPLV3 -- see the 'COPYING' file details.
   Copyright (C) 2006 Alex Korchemniy */
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;

using System.Data.OleDb;
using EmpowerPresenter.Data;
using System.Windows.Forms;
using FirebirdSql.Data.FirebirdClient;

namespace EmpowerPresenter
{
    public class SongProject : IProject, ISlideShow, IKeyClient, ISupportGfxCtx
    {
        public event EventHandler Refresh;
        public event EventHandler RequestActivate;
        public event EventHandler RequestDeactivate;
        
        // Data
        private string name = "";
        private string copyright = "";
        internal PresenterDataset.SongsRow currentSong;
        internal List<SongVerse> songVerses = new List<SongVerse>();

        // Slides
        private bool stripFormatting = false;
        private bool includeVerseNumbers = false;
        internal int currentSlideNum = -1;
        internal List<SongSlideData> songSlides = new List<SongSlideData>();

        // Graphics
        private GfxContext graphicsContext = new GfxContext();
        private PresenterFont songFont;

        ///////////////////////////////////////////////////////
        public SongProject(PresenterDataset.SongsRow currentSong)
        {
            Program.ConfigHelper.SongDefaultsChanged += new EventHandler(ConfigHelper_SongDefaultsChanged);

            this.currentSong = currentSong;
            this.name = currentSong.Number + ". " + currentSong.Title;
            LoadData(currentSong);
            PrepareForDisplay();
        }
        private void ConfigHelper_SongDefaultsChanged(object sender, EventArgs e)
        {
            RefreshData();
        }
        private void LoadData(PresenterDataset.SongsRow currentSong)
        {
            // Clear
            songVerses.Clear();
            
            // Populate songVerses
            LoadVerses(songVerses, currentSong.AutoNumber, false);

            // Load other data
            currentSong.Image = Data.Songs.GetSongBackground(currentSong.AutoNumber);
            copyright = EmpowerPresenter.Data.Songs.GetSongCopyright(currentSong.AutoNumber);
            songFont = PresenterFont.GetFontFromDatabase(currentSong.FontId);
            graphicsContext.opacity = currentSong.Overlay;
            if (graphicsContext.opacity == 777)
                graphicsContext.opacity = Program.ConfigHelper.SongDefaultOpacity;

            // Load img into context
            if (graphicsContext.img == null)
            {
                PhotoInfo pi = new PhotoInfo();
                pi.ImageId = currentSong.Image;
                graphicsContext.img = pi.FullSizeImage;
            }

            // Load formatting settings
            string settings = currentSong.Settings;
            if (settings == null || settings == "")
                settings = Program.ConfigHelper.SongDefaultFormat;
            string[] sparts = settings.Split("|".ToCharArray());
            if (sparts.Length == 2)
            {
                stripFormatting = bool.Parse(sparts[0]);
                includeVerseNumbers = bool.Parse(sparts[1]);
            }
        }
        public static void LoadVerses(List<SongVerse> listToLoad, int autoNumber, bool removeFormatting)
        {
            listToLoad.Clear();
            using (FBirdTask t = new FBirdTask())
            {
                t.CommandText =
                    "SELECT [AutoNumber], [IsChorus], [Verse], [OrderNum] " +
                    "FROM [SongVerses] " +
                    "WHERE [AutoNumber] = @AutoNumber " +
                    "ORDER BY [OrderNum]";
                t.Parameters.Add("@AutoNumber", FbDbType.Integer);
                t.Parameters["@AutoNumber"].Value = autoNumber;

                t.ExecuteReader();
                int verseNumber = 1;
                while (t.DR.Read())
                {
                    bool isChorus = t.GetInt32(1) == 1;
                    int vnum = isChorus ? -1 : verseNumber;
                    string verseData = t.GetString(2);
                    if (removeFormatting)
                        verseData = RemoveVerseFormatting(verseData);
                    SongVerse sv = new SongVerse(isChorus, verseData, vnum);
                    listToLoad.Add(sv);
                    if (!isChorus)
                        verseNumber++;
                }
            }
        }
        public static string RemoveVerseFormatting(string verse)
        {
            string s = verse.Replace("\r", " ").Replace("\n", " ").Replace("<br/>", " ");

            // Remove extra spaces... convert to single spaces
            List<char> lChars = new List<char>();
            foreach (char c in s) // First get a list of all characters
                lChars.Add(c);

            // Run through deleting extra spaces
            char currentChar;
            int currentIx = 0;
            while (true && currentIx < lChars.Count)
            {
                currentChar = lChars[currentIx];
                if (currentIx + 1 < lChars.Count) // if there is a character ahead
                {
                    if (currentChar == ' ' && lChars[currentIx + 1] == ' ')
                    {
                        lChars.RemoveAt(currentIx);
                        continue; // Continue without advancing the current index;
                    }
                }
                currentIx++;
            }
            s = new string(lChars.ToArray()); // Rebuild the string from characters

            return s;
        }
        public void RefreshData()
        {
            LoadData(currentSong);
            PrepareForDisplay();

            // Update image settings
            graphicsContext.opacity = currentSong.Overlay;
            if (graphicsContext.opacity == 777)
                graphicsContext.opacity = Program.ConfigHelper.SongDefaultOpacity;
            PhotoInfo pi = new PhotoInfo();
            pi.ImageId = currentSong.Image;
            UpdateBackgroundImage(pi.FullSizeImage);

            GotoSlide(currentSlideNum, true);
        }

        // Graphic prep
        private void PrepareForDisplay()
        {
            // Clear
            int slideNumberBackup = currentSlideNum;
            songSlides.Clear();
            currentSlideNum = -1;

            // Build the slides for all verses
            SongVerse lastChorusFound = null;
            for (int i = 0; i < songVerses.Count; i++)
            {
                SongVerse sv = songVerses[i];
                bool isLast = (i == (songVerses.Count - 1)); // check if this is the last verse
                bool isNextAChorus = (!isLast && songVerses[i + 1].IsChorus); // check if next verse is a chorus
                lastChorusFound = sv.IsChorus ? sv : lastChorusFound; // update the chorus if we hit a new one

                // Add the current verse
                InternalSplitVerse(sv, isLast, songVerses[i].VerseNumber); 

                // Add the chorus
                if (lastChorusFound != null && !sv.IsChorus && !isNextAChorus)
                    InternalSplitVerse(lastChorusFound, isLast, -1); 
            }

            // Set the last slide
            if (songSlides.Count > 0)
                songSlides[songSlides.Count - 1].isLast = true;

            // Reset the current slide number
            if (songSlides.Count > 0)
            {
                if (slideNumberBackup != -1)
                    currentSlideNum = slideNumberBackup;
                else
                    currentSlideNum = 0;
            }
        }
        private void InternalSplitVerse(SongVerse sv, bool isLast, int verseNumber)
        {
            char[] trimChars = "\r\n ".ToCharArray();

            string tmp = sv.Text;
            if (sv.Text.IndexOf("<br/>") != -1 && !stripFormatting)
            {
                bool first = true;
                while (tmp.IndexOf("<br/>") != -1) // Verses with breaks are handled here
                {
                    // Create a slide from the verse part
                    string vPart = tmp.Substring(0, tmp.IndexOf("<br/>"));
                    tmp = tmp.Substring(tmp.IndexOf("<br/>") + 5);
                    string verseData = vPart.Trim(trimChars);

                    // Verse number support
                    if (includeVerseNumbers && first)
                        verseData = IncludeVerseNumber(sv, verseNumber, verseData);
                    
                    // Add slide
                    songSlides.Add(new SongSlideData(songSlides.Count, sv.IsChorus, verseData, true, verseNumber));
                    first = false;
                }
                if (tmp.Length > 0)
                {
                    string verseData = tmp.Trim(trimChars);
                    songSlides.Add(new SongSlideData(songSlides.Count, sv.IsChorus, verseData, true, verseNumber));
                }
            }
            else
            {
                string verseData = sv.Text.Trim(trimChars);
                
                // Verse number support
                if (includeVerseNumbers)
                    verseData = IncludeVerseNumber(sv, verseNumber, verseData);

                songSlides.Add(new SongSlideData(songSlides.Count, sv.IsChorus, verseData, false, verseNumber));
            }
        }
        private string IncludeVerseNumber(SongVerse sv, int verseNumber, string verseData)
        {
            string chorus = "Припев: ";
            if (sv.IsChorus)
                verseData = chorus + verseData;
            else if (verseNumber == 1)
                verseData = currentSong.Number + ". " + verseData;
            else
                verseData = verseNumber + ". " + verseData;
            return verseData;
        }
        public Dictionary<int, string> GetInlineRepresentation()
        {
            if (songSlides.Count == 0)
                return new Dictionary<int,string>();

            Dictionary<int, string> slideText = new Dictionary<int, string>();
            if (includeVerseNumbers)
            {
                foreach (SongSlideData ssd in this.songSlides)
                    slideText.Add(ssd.slideNumber, RemoveVerseFormatting(ssd.text));
            }
            else
            {
                string chorus = Loc.Get("Chorus:") + " ";
                string lastRefStr = "";
                bool titleAdded = false;
                foreach (SongSlideData ssd in this.songSlides)
                {
                    string refstr = "";

                    if (ssd.isChorus)
                    {
                        if (lastRefStr != chorus)
                        {
                            refstr = chorus;
                            lastRefStr = refstr;
                        }
                        else
                            refstr = "";
                    }
                    else
                    {
                        if (!ssd.isPartial && ssd.verseNumber != 1)
                        {
                            refstr = ssd.verseNumber + ". ";
                            lastRefStr = refstr;
                        }
                        if (ssd.isPartial && ssd.verseNumber != 1)
                        {
                            if (lastRefStr != ssd.verseNumber + ". ") // Notice: number is applied only once
                            {
                                refstr = ssd.verseNumber + ". ";
                                lastRefStr = refstr;
                            }
                        }
                    }

                    // Add title
                    if (!titleAdded)
                    {
                        refstr = currentSong.Number + ". " + refstr;
                        titleAdded = true;
                    }

                    string verse = RemoveVerseFormatting(ssd.text);
                    slideText.Add(ssd.slideNumber, refstr + verse);
                }
            }
            return slideText;
        }

        // Graphics
        public void RefreshUI()
        {
            if (Refresh != null)
                Refresh(this, null);
        }
        public GfxContext GetCurrentGfxContext()
        {
            // Check bounds
            if (currentSlideNum > songSlides.Count - 1)
                currentSlideNum = songSlides.Count - 1;

            SongSlideData data = songSlides[currentSlideNum];
            string verse = data.text;
            const int PADDING = 30;

            // No formatting support
            if (stripFormatting)
                verse = SongProject.RemoveVerseFormatting(verse);

            // Double space support
            if (!stripFormatting)
            {
                string lineSpacing = songFont.DoubleSpace ? "\r\n\r\n" : "\r\n";
                verse = verse.Replace("\r\n", "\n").Replace("\n", lineSpacing);
            }

            #region Standard format (build context)
            Size nativeSize = DisplayEngine.NativeResolution.Size;
            graphicsContext.destSize = nativeSize;
            graphicsContext.textRegions.Clear();

            // Add the verse box
            GfxTextRegion rVerse = new GfxTextRegion();
            rVerse.bounds = new Rectangle(PADDING, PADDING, nativeSize.Width - PADDING * 2, nativeSize.Height - 80);
            rVerse.font = songFont;
            rVerse.message = verse;
            graphicsContext.textRegions.Add(rVerse);

            // Last slide ***
            if (data.isLast)
            {
                GfxTextRegion rEnd = new GfxTextRegion();
                rEnd.bounds = new Rectangle(PADDING, nativeSize.Height - 80, nativeSize.Width - PADDING * 2, 40);
                rEnd.font = (PresenterFont)songFont.Clone();
                rEnd.font.HorizontalAlignment = HorizontalAlignment.Center;
                rEnd.message = "* * *";
                graphicsContext.textRegions.Add(rEnd);
            }

            // Copyright
            if (copyright != "")
            {
                GfxTextRegion rEnd = new GfxTextRegion();
                rEnd.bounds = new Rectangle(PADDING, nativeSize.Height - 40, nativeSize.Width - PADDING * 2, 40 - 7);
                rEnd.font = new PresenterFont();
                rEnd.font.fontName = "Verdana";
                rEnd.font.Italic = true;
                rEnd.font.SizeInPoints = 12;
                rEnd.font.HorizontalAlignment = HorizontalAlignment.Center;
                rEnd.font.VerticalAlignment = VerticalAlignment.Bottom;
                rEnd.font.Color = songFont.Color;
                rEnd.font.Shadow = false;
                rEnd.font.Outline = false;
                rEnd.message = copyright;
                graphicsContext.textRegions.Add(rEnd);
            }
            #endregion

            return graphicsContext.Clone();
        }
        public void UpdateBackgroundImage(Image i)
        {
            graphicsContext.img = i;
            RefreshUI();
        }
        public void UpdateBackgroundImage(PhotoInfo photo)
        {
            UpdateBackgroundImage(photo.FullSizeImage);
        }
        public void SetOpacity(int opacityval)
        {
            graphicsContext.opacity = opacityval;
            RefreshUI();
        }

        public bool StripFormatting
        {
            get { return stripFormatting; }
            set
            {
                if (stripFormatting != value)
                {
                    stripFormatting = value;
                    PrepareForDisplay(); // Recalculate sizes
                }
            }
        }
        public bool VerseNumbers
        {
            get { return includeVerseNumbers; }
            set
            {
                if (includeVerseNumbers != value)
                {
                    includeVerseNumbers = value;
                    PrepareForDisplay(); // Recalculate sizes
                }
            }
        }

        #region IProject Members

        public string GetName(){return name;}
        public ProjectType GetProjectType(){return ProjectType.Song;}
        public void Activate()
        {
            Program.Presenter.ActivateKeyClient(this);
            if (RequestActivate != null)
                RequestActivate(this, null);
        }
        public void CloseProject()
        {
            Program.ConfigHelper.SongDefaultsChanged -= new EventHandler(ConfigHelper_SongDefaultsChanged);

            if (RequestDeactivate != null)
                RequestDeactivate(this, null);
        }
        public Type GetControllerUIType() { return typeof(SongProjectView); }
        public Type GetDisplayerType() { return typeof(DisplayEngine); }
        public bool IsPrimaryDisplay() { return true; }

        #endregion

        #region ISlideShow Members

        public void GotoSlide(int x)
        {
            GotoSlide(x, false);
        }
        public void GotoSlide(int x, bool forceRefresh)
        {
            if (currentSlideNum != x || forceRefresh)
            {
                // Update the current number
                currentSlideNum = x;

                RefreshUI(); // This method will trigger all controllers to refresh

                // Keys
                // TODO: register for keys
            }
        }
        public void GoNextSlide()
        {
            if (currentSlideNum < songSlides.Count - 1)
                GotoSlide(currentSlideNum + 1);
        }
        public void GoPrevSlide()
        {
            if (currentSlideNum > 0)
                GotoSlide(currentSlideNum - 1);
        }

        #endregion

        #region IKeyClient Members

        public void ProccesKeys(Keys k, bool exOwer)
        {
            if (exOwer)
                return;

            if (k == Keys.Right || k == Keys.Down || k == Keys.PageDown || k == Keys.Space || k == Keys.Enter)
            {
                GoNextSlide();
                ActivateController();
            }
            else if (k == Keys.Left || k == Keys.Up || k == Keys.PageUp || k == Keys.Back)
            {
                GoPrevSlide();
                ActivateController();
            }
        }
        private void ActivateController()
        {
            if (Program.Presenter.activeController == null ||
                Program.Presenter.activeController.GetType() != this.GetControllerUIType())
                Program.Presenter.ActivateController(this);
        }

        #endregion

        ////////////////////////////////////////////////////////
        internal class SongSlideData
        {
            public int slideNumber = 0;
            public bool isChorus = false;
            public string text = "";
            public bool isLast = false;
            public bool isPartial = false;
            public int verseNumber = -1;
            public SongSlideData(int slideNumber, bool isChorus, string text, bool isPartial, int verseNumber)
            {
                this.slideNumber = slideNumber;
                this.isChorus = isChorus;
                this.text = text;
                this.isPartial = isPartial;
                this.verseNumber = verseNumber;
            }
        }
    }
}
