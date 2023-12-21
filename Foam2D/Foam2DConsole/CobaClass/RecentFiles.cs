using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Foam2DConsole.CobaClass
{
    internal class RecentFiles
    {
        private static List<string>? file_name { get; set; }
        private static List<string>? file_path { get; set; }
        private static List<string>? last_modified {get; set; }

        public static void AddFilePath(string filePath)
        {
            file_path ??= new List<string>();   
            file_path.Add(filePath);
        }

        public static void GetFilePath()    
        {
            foreach (string path in file_path ?? new List<string>())
            {
                
            }
        }

        internal static void SaveToJson(string filePath)
        {
            var recentFilesData = new
            {
                Paths = file_path,

            };

            string jsonData = JsonSerializer.Serialize(recentFilesData, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(filePath, jsonData);
        }
    }
}
