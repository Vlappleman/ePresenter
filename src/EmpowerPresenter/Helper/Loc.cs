/* ePresenter is licensed under the GPLV3 -- see the 'COPYING' file details.
   Copyright (C) 2006 Alex Korchemniy */
using System;
using System.Collections;
using System.Collections.Generic;

namespace EmpowerPresenter
{
    public class Loc
    {
        private static Dictionary<string, string> locStrings = new Dictionary<string, string>();
        public static string culture = "";

        static Loc()
        {
            locStrings.Add("10 files limit", "10 Файлов лимит");
            locStrings.Add("Add", "Добавить");
            locStrings.Add("Add image", "Добавить картину");
            locStrings.Add("Adding a new category", "Добавить категорию");
            locStrings.Add("Add a new song", "Добавить новый псалом");
            locStrings.Add("Additional file types", "Добавочные файлы");
            locStrings.Add("Add text", "Добавить текст");
            locStrings.Add("A project with this name already exists", "Проект под этим именем уже существует");
            locStrings.Add("Are you sure you want to delete?", "Удалить?");
            locStrings.Add("Are you sure you want to remove the image", "Удалить выбранную картину");
            locStrings.Add("Are you sure you want to remove the image from the current category", "Удалить выбранную картину из текущей категории");
            locStrings.Add("Are you sure you want to remove the selected category:", "Удалить выбранную категорию?");
            locStrings.Add("Assign category", "Назначить категорию");
            locStrings.Add("Author:", "Автор:");
            locStrings.Add("Bible searching", "Поиск в Библии");
            locStrings.Add("Black screen", "Черный экран ");
            locStrings.Add("Category already exists", "Категория уже существует ");
            locStrings.Add("Change background", "Изменить фон");
            locStrings.Add("Changing background", "Изменять фон");
            locStrings.Add("Changing defaults", "Changing defaults");
            locStrings.Add("Change font", "Изменить шрифт");
            locStrings.Add("Changing font", "Изменять шрифт");
            locStrings.Add("Changing format", "Изменять формат");
            locStrings.Add("Change opacity", "Яркость");
            locStrings.Add("Chorus:", "Припев:");
            locStrings.Add("Close", "Закрыть");
            locStrings.Add("Confirm Deletion", "Удалить?");
            locStrings.Add("Содержит неправильные символы:", "");
            locStrings.Add("Date modified:", "Дата:");
            locStrings.Add("Delete image", "Удалить картину");
            locStrings.Add("Drag and drop", "Drag and drop");
            locStrings.Add("ePresenter is already running", "ePresenter is already running");
            locStrings.Add("Edit Powerpoint", "Редактировать Powerpoint");
            locStrings.Add("Edit song", "Редактировать псалом");
            locStrings.Add("Error", "Ошыбка");
            locStrings.Add("File:", "Файл:");
            locStrings.Add("File not found:", "PowerPoint файл не найден:");
            locStrings.Add("Fulltext song searching", "Полный поис псалма");
            locStrings.Add("Hide", "Скрыть");
            locStrings.Add("Hide content", "Скрыть проэкт");
            locStrings.Add("Incompatible Presentation", "Incompatible Presentation");
            locStrings.Add("Invalid activation code", "Неправленый номер");
            locStrings.Add("Migration", "Migration");
            locStrings.Add("Modifying song data", "Изменение псалмов");
            locStrings.Add("Multiple verse configuration", "Конфигурация стихов");
            locStrings.Add("Name is already in use", "Имя уже использовано");
            locStrings.Add("Next", "Следующий");
            locStrings.Add("Not a valid number", "Текст не является номером");
            locStrings.Add("Number cannot be negative", "Текст не является номером");
            locStrings.Add("One project limit", "Лимит одного проекта");
            locStrings.Add("Pin Background", "Сохранить фон");
            locStrings.Add("Please enter a new name for the category:", "Пожалуйста, введите имя для категории:");
            locStrings.Add("Please install PowerPoint 2000 or newer.", "Пожалуйста, установите PowerPoint 2000 или новей.");
            locStrings.Add("Please install Windows Media Player 9 or newer.", "Пожалуйста, установите Windows Media Player 9 или новей.");
            locStrings.Add("PowerPoint presentation", "PowerPoint презентация");
            locStrings.Add("Preview:", "Просмотр:");
            locStrings.Add("Previous", "Предыдущий");
            locStrings.Add("Project not saved. Save now?", "Проект не сохранен. Сохранить сичас?");
            locStrings.Add("Remove current category", "Удалить этой категории");
            locStrings.Add("Remove image", "Удалить картину");
            locStrings.Add("Remove image from current category", "Удалить картину с этой категории");
            locStrings.Add("Remove text", "Удалить текст");
            locStrings.Add("Rename category", "Переименованoвать категорию");
            locStrings.Add("Save", "Сохранить");
            locStrings.Add("Save project", "Сохранить проект");
            locStrings.Add("Search contains one of these invalid characters: * %", "Поиск содержит неправильные символы: * %");
            locStrings.Add("Search results:", "Результаты поиска:");
            locStrings.Add("Select files to open", "Выберите файлы");
            locStrings.Add("Select image to add", "Выберите картину");
            locStrings.Add("Select PowerPoint presentation", "Выберите PowerPoint презентацию");
            locStrings.Add("Set as wallpaper", "Set as wallpaper"); // TODO
            locStrings.Add("Settings", "Настройка");
            locStrings.Add("Show content", "Высветить");
            locStrings.Add("Smooth transitions", "Плавный переход");
            locStrings.Add("Song searching", "Поиск псалмов");
            locStrings.Add("Supported files", "Поддерживаемые файлы");
            locStrings.Add("Supported formats", "Поддерживаемые форматы");
            locStrings.Add("Slide {0} of {1}", "Слайд {0} из {1}");
            locStrings.Add("Title:", "Имя:");
            locStrings.Add("Turn off black screen", "Выключить черный экран");
            locStrings.Add("Updates", "Проверка новых обновлений");
            locStrings.Add("Video project", "Видео проект");
            locStrings.Add("Warning", "Предупреждениеe");
            locStrings.Add("Windows Media Player cannot start player. Please make sure version 9 or higher is installed.", "Windows Media Player не можно загрузить. Убедитесь, что версия девять или выше установлена.");
            
        }
        public static string Get(string message)
        {
            if (Loc.culture != "")
            {
                if (!locStrings.ContainsKey(message))
                {
                    Console.WriteLine("Loc.Get asking for: " + message);
                    return message; // localizedStrings.GetLocalizedString(message);
                }
                else
                    return locStrings[message];
            }
            else
                return message;
        }
    }
}
