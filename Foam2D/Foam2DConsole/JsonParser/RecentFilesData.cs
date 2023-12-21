using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using Foam2DConsole.JsonParser;

namespace Foam2DConsole.CobaClass
{
    public class RecentFilesData : IJsonReader
    {
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? LastModified { get; set; }

        public RecentFilesData() { }
        
        public void GetJsonData(string path)
        {
            RecentFilesData? jsondata = new RecentFilesData();

            string? json = "";
            using(StreamReader sr = new StreamReader(path))
            {
                string line;
                while((line = sr.ReadLine()) != null) { json += line; }
            }
            try
            {
                jsondata = JsonSerializer.Deserialize<RecentFilesData>(json);
                this.FileName = jsondata?.FileName;
                this.LastModified = jsondata?.LastModified;
                this.FilePath = jsondata?.FilePath;
            }
            catch 
            {
                Console.WriteLine("File path doesn't exist");
            }

            //Console.WriteLine(this.FileName);

        }

    }
}
