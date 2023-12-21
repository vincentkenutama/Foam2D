using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Foam2DConsole.CobaClass
{
    internal class RecentFilesHandler
    {
        private string? file_path;

        private void SetPath(string path)
        {

            file_path = $@"{path}";
        }

        public void GetRecent(string path)
        {
            SetPath(path);
            if(File.Exists(file_path))
            {
                RecentFiles.AddFilePath(file_path);

                Console.WriteLine("file exist");

                using (StreamReader sr = File.OpenText(file_path))
                {

                    string s;
                    while((s = sr.ReadLine()) != null)
                    {
                        //Console.WriteLine(s);
                    }
                }
            }
            else
            {
                Console.WriteLine("file doesn't exist");
            }

            
        }


    }
}
