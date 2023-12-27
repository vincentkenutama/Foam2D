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
        //JSON 
        private string path = @"path.json";
    
        //Visibility, on start always false except the "no recent files"
        bool[] is_visible = new bool[6] { false, false, false, false, false, true };

        private List<string>? file_name = new List<string>() {"", "", "", "", ""};
        private List<string>? file_path = new List<string>() { "", "", "", "", "" };
        private List<string>? last_modified = new List<string>() { "", "", "", "", "" };

        //Pointing Each Recent Files 
        private delegate void RecentTabDelegate(int index, string file_name, string file_path, string last_mod);
        //RecentTabDelegate FileTab = new RecentTabDelegate();

        public LoadRecentFiles()
        {
            RecentFile.SetJsonPath(path);
            LoadRecent();
        }

        public void LoadRecent()
        {
            RecentFile.RecentFileJsonReader();

            if (RecentFile.IsNull) { return; }

            var file_name_ = RecentFile.GetFileName();
            var file_path_ = RecentFile.GetFilePath();
            var last_modified_ = RecentFile.GetLastModified();

            for (int i = 0; i < file_name_?.Count(); i++)
            {
                SetRecentFiles(i, file_name_[i], file_path_[i], last_modified_[i], true);
                is_visible[i] = true;
            }

            foreach (var visibility in is_visible)
            {
                FirstRecentVisibility = visibility;
                if (visibility == true) { EmptyRecentVisibility = false; break; }
            }

        }

        public void SetRecentFiles(int index, string file_name, string file_path, string last_mod, bool visibility)
        {
            switch(index)
            {
                case 0:
                    FirstFileName = file_name;
                    FirstFilePath = file_path;
                    FirstLastModified = last_mod;
                    FirstRecentVisibility = visibility;
                    break;
                case 1:
                    SecondFileName = file_name;
                    SecondFilePath = file_path;
                    SecondLastModified = last_mod;
                    SecondRecentVisibility = visibility;
                    break;
                case 2:
                    ThirdFileName = file_name;
                    ThirdFilePath = file_path;
                    ThirdLastModified = last_mod;
                    ThirdRecentVisibility = visibility;
                    break;
                case 3:
                    FourthFileName = file_name;
                    FourthFilePath = file_path;
                    FourthLastModified = last_mod;
                    FourthRecentVisibility = visibility;
                    break;
                case 4:
                    FifthFileName = file_name;
                    FifthFilePath = file_path;
                    FifthLastModified = last_mod;
                    FifthRecentVisibility = visibility;
                    break;

            }
            //return "";
        }

        public string FirstFileName
        {
            get => file_name[0];
            set
            {
                if (file_name[0] == value) return;
                file_name[0] = value;
                OnPropertyChanged();
            }
        }

        public string FirstFilePath
        {
            get => file_path[0];
            set
            {
                if (file_path[0] == value) return;
                file_path[0] = value;
                OnPropertyChanged();
            }
        }

        public string FirstLastModified
        {
            get => last_modified[0];
            set
            {
                if (last_modified[0] == value) return;
                last_modified[0] = value;
                OnPropertyChanged();
            }
        }

        public string SecondFileName
        {
            get => file_name[1];
            set
            {
                if (file_name[1] == value) return;
                file_name[1] = value;
                OnPropertyChanged();
            }
        }

        public string SecondFilePath
        {

            get => file_path[1];
            set
            {
                if (file_path[1] == value) return;
                file_path[1] = value;
                OnPropertyChanged();
            }
        }

        public string SecondLastModified
        {
            get => last_modified[1];
            set
            {
                if (last_modified[1] == value) return;
                last_modified[1] = value;
                OnPropertyChanged();
            }
        }

        public string ThirdFileName
        {
            get => file_name[2];
            set
            {
                if (file_name[2] == value) return;
                file_name[2] = value;
                OnPropertyChanged();
            }
        }

        public string ThirdFilePath
        {

            get => file_path[2];
            set
            {
                if (file_path[2] == value) return;
                file_path[2] = value;
                OnPropertyChanged();
            }
        }

        public string ThirdLastModified
        {
            get => last_modified[2];
            set
            {
                if (last_modified[2] == value) return;
                last_modified[2] = value;
                OnPropertyChanged();
            }
        }

        public string FourthFileName
        {
            get => file_name[3];
            set
            {
                if (file_name[3] == value) return;
                file_name[3] = value;
                OnPropertyChanged();
            }
        }

        public string FourthFilePath
        {

            get => file_path[3];
            set
            {
                if (file_path[3] == value) return;
                file_path[3] = value;
                OnPropertyChanged();
            }
        }

        public string FourthLastModified
        {
            get => last_modified[3];
            set
            {
                if (last_modified[3] == value) return;
                last_modified[3] = value;
                OnPropertyChanged();
            }
        }

        public string FifthFileName
        {
            get => file_name[4];
            set
            {
                if (file_name[4] == value) return;
                file_name[4] = value;
                OnPropertyChanged();
            }
        }

        public string FifthFilePath
        {

            get => file_path[4];
            set
            {
                if (file_path[4] == value) return;
                file_path[4] = value;
                OnPropertyChanged();
            }
        }

        public string FifthLastModified
        {
            get => last_modified[4];
            set
            {
                if (last_modified[4] == value) return;
                last_modified[4] = value;
                OnPropertyChanged();
            }
        }

        public bool FirstRecentVisibility
        { 
            get => is_visible[0];
            set
            {
                if (is_visible[0] == value) return;
                is_visible[0] = value;
                OnPropertyChanged();
            }
        }

        public bool SecondRecentVisibility
        {
            get => is_visible[1];
            set
            {
                if (is_visible[1] == value) return;
                is_visible[1] = value;
                OnPropertyChanged();
            }
        }

        public bool ThirdRecentVisibility
        {
            get => is_visible[2];
            set
            {
                if (is_visible[2] == value) return;
                is_visible[2] = value;
                OnPropertyChanged();
            }
        }

        public bool FourthRecentVisibility
        {
            get => is_visible[3];
            set
            {
                if (is_visible[3] == value) return;
                is_visible[3] = value;
                OnPropertyChanged();
            }
        }

        public bool FifthRecentVisibility
        {
            get => is_visible[4];
            set
            {
                if (is_visible[4] == value) return;
                is_visible[4] = value;
                OnPropertyChanged();
            }
        }

        public bool EmptyRecentVisibility
        {
            get => is_visible[5];
            set
            {
                if (is_visible[5] == value) return;
                is_visible[5] = value;
                OnPropertyChanged();
            }
        }
    }
}
