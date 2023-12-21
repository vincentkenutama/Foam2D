using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Foam2D.Classes;

namespace Foam2D.StartPage.LoadRecentFile
{
    internal class LoadRecentFiles : BindableObject
    {
        private string path = @"path.json";
        private RecentFile recent = new RecentFile();

        string file_name = "";
        string file_path = "";
        string last_modified = "";
        public LoadRecentFiles()
        {
            var json = LoadRecent();
            
        }
        public async Task LoadRecent()
        {
            await recent.GetJsonDataAsync(path);
            FileName = recent.FileName ?? "";
            FilePath = recent.FilePath ?? "what";
            LastModified = recent.LastModified ?? "what";
            
            
        }

        public string FileName
        {
            get => file_name;
            set
            {
                if (file_name == value) return;
                file_name = value;
                OnPropertyChanged();
            }
        }

        public string FilePath
        {
            get => file_path;
            set
            {
                if (file_path == value) return;
                file_path = value;
                OnPropertyChanged();
            }
        }

        public string LastModified
        {
            get => last_modified;
            set
            {
                if (last_modified == value) return;
                last_modified = value;
                OnPropertyChanged();
            }
        }






    }
}
