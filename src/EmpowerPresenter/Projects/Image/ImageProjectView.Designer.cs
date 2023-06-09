using System.Drawing;
namespace EmpowerPresenter
{
	partial class ImageProjectView
	{
		private System.ComponentModel.IContainer components = null;
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageProjectView));
			this.themedPanel1 = new Vendisoft.Controls.ThemedPanel();
			this.btnWallpaper = new Vendisoft.Controls.ImageButton();
			this.btnOptions = new Vendisoft.Controls.ImageButton();
			this.btnRemove = new Vendisoft.Controls.ImageButton();
			this.btnAdd = new Vendisoft.Controls.ImageButton();
			this.lbImages = new System.Windows.Forms.ListBox();
			this.lblTitle = new System.Windows.Forms.Label();
			this.lblInfo = new System.Windows.Forms.Label();
			this.btnNext = new Vendisoft.Controls.ImageButton();
			this.btnPrev = new Vendisoft.Controls.ImageButton();
			this.pnlPreviewImage = new System.Windows.Forms.Label();
			this.btnClose = new Vendisoft.Controls.ImageButton();
			this.btnActivate = new Vendisoft.Controls.ImageButton();
			this.themedPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// themedPanel1
			// 
			this.themedPanel1.BackColor = System.Drawing.Color.Transparent;
			this.themedPanel1.BottomSplice = 50;
			this.themedPanel1.Controls.Add(this.btnWallpaper);
			this.themedPanel1.Controls.Add(this.btnOptions);
			this.themedPanel1.Controls.Add(this.btnRemove);
			this.themedPanel1.Controls.Add(this.btnAdd);
			this.themedPanel1.Controls.Add(this.lbImages);
			this.themedPanel1.Controls.Add(this.lblTitle);
			this.themedPanel1.Controls.Add(this.lblInfo);
			this.themedPanel1.Controls.Add(this.btnNext);
			this.themedPanel1.Controls.Add(this.btnPrev);
			this.themedPanel1.Controls.Add(this.pnlPreviewImage);
			this.themedPanel1.Controls.Add(this.btnClose);
			this.themedPanel1.Controls.Add(this.btnActivate);
			resources.ApplyResources(this.themedPanel1, "themedPanel1");
			this.themedPanel1.Image = global::EmpowerPresenter.Properties.Resources.panelbackground;
			this.themedPanel1.LeftSlice = 50;
			this.themedPanel1.Name = "themedPanel1";
			this.themedPanel1.RightSplice = 50;
			this.themedPanel1.TopSplice = 50;
			// 
			// btnWallpaper
			// 
			this.btnWallpaper.BackColor = System.Drawing.Color.Transparent;
			this.btnWallpaper.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnWallpaper.DisabledImg = global::EmpowerPresenter.Properties.Resources.image_d1;
			resources.ApplyResources(this.btnWallpaper, "btnWallpaper");
			this.btnWallpaper.IsHighlighted = false;
			this.btnWallpaper.IsPressed = false;
			this.btnWallpaper.IsSelected = false;
			this.btnWallpaper.Name = "btnWallpaper";
			this.btnWallpaper.NormalImg = global::EmpowerPresenter.Properties.Resources.image1;
			this.btnWallpaper.OverImg = global::EmpowerPresenter.Properties.Resources.image1;
			this.btnWallpaper.PressedImg = global::EmpowerPresenter.Properties.Resources.image1;
			this.btnWallpaper.Tag = "Set as wallpaper";
			this.btnWallpaper.MouseLeave += new System.EventHandler(this.imgBtn_MouseLeave);
			this.btnWallpaper.Click += new System.EventHandler(this.btnWallpaper_Click);
			this.btnWallpaper.MouseEnter += new System.EventHandler(this.imgBtn_MouseEnter);
			// 
			// btnOptions
			// 
			this.btnOptions.BackColor = System.Drawing.Color.Transparent;
			this.btnOptions.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnOptions.DisabledImg = global::EmpowerPresenter.Properties.Resources.cog;
			this.btnOptions.IsHighlighted = false;
			this.btnOptions.IsPressed = false;
			this.btnOptions.IsSelected = false;
			resources.ApplyResources(this.btnOptions, "btnOptions");
			this.btnOptions.Name = "btnOptions";
			this.btnOptions.NormalImg = global::EmpowerPresenter.Properties.Resources.cog;
			this.btnOptions.OverImg = global::EmpowerPresenter.Properties.Resources.cog;
			this.btnOptions.PressedImg = global::EmpowerPresenter.Properties.Resources.cog;
			this.btnOptions.Tag = "Settings";
			this.btnOptions.MouseLeave += new System.EventHandler(this.imgBtn_MouseLeave);
			this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
			this.btnOptions.MouseEnter += new System.EventHandler(this.imgBtn_MouseEnter);
			// 
			// btnRemove
			// 
			this.btnRemove.BackColor = System.Drawing.Color.Transparent;
			this.btnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnRemove.DisabledImg = global::EmpowerPresenter.Properties.Resources.removeimage;
			this.btnRemove.IsHighlighted = false;
			this.btnRemove.IsPressed = false;
			this.btnRemove.IsSelected = false;
			resources.ApplyResources(this.btnRemove, "btnRemove");
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.NormalImg = global::EmpowerPresenter.Properties.Resources.removeimage;
			this.btnRemove.OverImg = global::EmpowerPresenter.Properties.Resources.removeimage;
			this.btnRemove.PressedImg = global::EmpowerPresenter.Properties.Resources.removeimage;
			this.btnRemove.Tag = "Remove image";
			this.btnRemove.MouseLeave += new System.EventHandler(this.imgBtn_MouseLeave);
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			this.btnRemove.MouseEnter += new System.EventHandler(this.imgBtn_MouseEnter);
			// 
			// btnAdd
			// 
			this.btnAdd.BackColor = System.Drawing.Color.Transparent;
			this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnAdd.DisabledImg = global::EmpowerPresenter.Properties.Resources.addimage;
			this.btnAdd.IsHighlighted = false;
			this.btnAdd.IsPressed = false;
			this.btnAdd.IsSelected = false;
			resources.ApplyResources(this.btnAdd, "btnAdd");
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.NormalImg = global::EmpowerPresenter.Properties.Resources.addimage;
			this.btnAdd.OverImg = global::EmpowerPresenter.Properties.Resources.addimage;
			this.btnAdd.PressedImg = global::EmpowerPresenter.Properties.Resources.addimage;
			this.btnAdd.Tag = "Add image";
			this.btnAdd.MouseLeave += new System.EventHandler(this.imgBtn_MouseLeave);
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.btnAdd.MouseEnter += new System.EventHandler(this.imgBtn_MouseEnter);
			// 
			// lbImages
			// 
			resources.ApplyResources(this.lbImages, "lbImages");
			this.lbImages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbImages.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.lbImages.FormattingEnabled = true;
			this.lbImages.Name = "lbImages";
			this.lbImages.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox1_DrawItem);
			this.lbImages.SelectedIndexChanged += new System.EventHandler(this.lbImages_SelectedIndexChanged);
			// 
			// lblTitle
			// 
			this.lblTitle.BackColor = System.Drawing.Color.SteelBlue;
			resources.ApplyResources(this.lblTitle, "lblTitle");
			this.lblTitle.ForeColor = System.Drawing.Color.White;
			this.lblTitle.Name = "lblTitle";
			// 
			// lblInfo
			// 
			resources.ApplyResources(this.lblInfo, "lblInfo");
			this.lblInfo.BackColor = System.Drawing.Color.Transparent;
			this.lblInfo.Name = "lblInfo";
			// 
			// btnNext
			// 
			this.btnNext.BackColor = System.Drawing.Color.Transparent;
			this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnNext.DisabledImg = global::EmpowerPresenter.Properties.Resources.greenright_d;
			this.btnNext.IsHighlighted = false;
			this.btnNext.IsPressed = false;
			this.btnNext.IsSelected = false;
			resources.ApplyResources(this.btnNext, "btnNext");
			this.btnNext.Name = "btnNext";
			this.btnNext.NormalImg = global::EmpowerPresenter.Properties.Resources.greenright_n;
			this.btnNext.OverImg = global::EmpowerPresenter.Properties.Resources.greenright_n;
			this.btnNext.PressedImg = global::EmpowerPresenter.Properties.Resources.greenright_n;
			this.btnNext.Tag = "Next";
			this.btnNext.MouseLeave += new System.EventHandler(this.imgBtn_MouseLeave);
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			this.btnNext.MouseEnter += new System.EventHandler(this.imgBtn_MouseEnter);
			// 
			// btnPrev
			// 
			this.btnPrev.BackColor = System.Drawing.Color.Transparent;
			this.btnPrev.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnPrev.DisabledImg = global::EmpowerPresenter.Properties.Resources.greenleft_d;
			this.btnPrev.IsHighlighted = false;
			this.btnPrev.IsPressed = false;
			this.btnPrev.IsSelected = false;
			resources.ApplyResources(this.btnPrev, "btnPrev");
			this.btnPrev.Name = "btnPrev";
			this.btnPrev.NormalImg = global::EmpowerPresenter.Properties.Resources.greenleft_n;
			this.btnPrev.OverImg = global::EmpowerPresenter.Properties.Resources.greenleft_n;
			this.btnPrev.PressedImg = global::EmpowerPresenter.Properties.Resources.greenleft_n;
			this.btnPrev.Tag = "Previous";
			this.btnPrev.MouseLeave += new System.EventHandler(this.imgBtn_MouseLeave);
			this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
			this.btnPrev.MouseEnter += new System.EventHandler(this.imgBtn_MouseEnter);
			// 
			// pnlPreviewImage
			// 
			resources.ApplyResources(this.pnlPreviewImage, "pnlPreviewImage");
			this.pnlPreviewImage.BackColor = System.Drawing.Color.Transparent;
			this.pnlPreviewImage.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pnlPreviewImage.Name = "pnlPreviewImage";
			this.pnlPreviewImage.MouseDown += new System.Windows.Forms.MouseEventHandler(pnlPreviewImage_MouseDown);
			this.pnlPreviewImage.Resize += new System.EventHandler(this.pnlPreviewImage_Resize);
			this.pnlPreviewImage.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPreviewImage_Paint);
			// 
			// btnClose
			// 
			resources.ApplyResources(this.btnClose, "btnClose");
			this.btnClose.BackColor = System.Drawing.Color.Transparent;
			this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnClose.DisabledImg = global::EmpowerPresenter.Properties.Resources.close_n;
			this.btnClose.IsHighlighted = false;
			this.btnClose.IsPressed = false;
			this.btnClose.IsSelected = false;
			this.btnClose.Name = "btnClose";
			this.btnClose.NormalImg = global::EmpowerPresenter.Properties.Resources.close_n;
			this.btnClose.OverImg = global::EmpowerPresenter.Properties.Resources.close_o;
			this.btnClose.PressedImg = global::EmpowerPresenter.Properties.Resources.close_n;
			this.btnClose.Tag = "Close";
			this.btnClose.MouseLeave += new System.EventHandler(this.imgBtn_MouseLeave);
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			this.btnClose.MouseEnter += new System.EventHandler(this.imgBtn_MouseEnter);
			// 
			// btnActivate
			// 
			this.btnActivate.BackColor = System.Drawing.Color.Transparent;
			this.btnActivate.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnActivate.DisabledImg = global::EmpowerPresenter.Properties.Resources.activate_btnd;
			resources.ApplyResources(this.btnActivate, "btnActivate");
			this.btnActivate.IsHighlighted = false;
			this.btnActivate.IsPressed = false;
			this.btnActivate.IsSelected = false;
			this.btnActivate.Name = "btnActivate";
			this.btnActivate.NormalImg = global::EmpowerPresenter.Properties.Resources.activate_btnn;
			this.btnActivate.OverImg = global::EmpowerPresenter.Properties.Resources.activate_btnover;
			this.btnActivate.PressedImg = global::EmpowerPresenter.Properties.Resources.activate_btnn;
			this.btnActivate.Click += new System.EventHandler(this.btnActivate_Click);
			// 
			// ImageProjectView
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
			this.Controls.Add(this.themedPanel1);
			this.DoubleBuffered = true;
			this.Name = "ImageProjectView";
			this.themedPanel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private Vendisoft.Controls.ThemedPanel themedPanel1;
		private Vendisoft.Controls.ImageButton btnActivate;
		private Vendisoft.Controls.ImageButton btnClose;
		private System.Windows.Forms.Label pnlPreviewImage;
		private Vendisoft.Controls.ImageButton btnNext;
		private Vendisoft.Controls.ImageButton btnPrev;
		private System.Windows.Forms.Label lblInfo;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.ListBox lbImages;
		private Vendisoft.Controls.ImageButton btnRemove;
		private Vendisoft.Controls.ImageButton btnAdd;
		private Vendisoft.Controls.ImageButton btnWallpaper;
		private Vendisoft.Controls.ImageButton btnOptions;
	}
}
