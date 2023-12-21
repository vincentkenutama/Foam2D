using System;
using Foam2DConsole.CobaClass;
using System.Text.Json;
using System.IO;

namespace Foam2DConsole
{
    class Foam2DConsole
    {
        public static int Main(string[] args)
        {
            //RecentFilesHandler recentFilesHandler = new RecentFilesHandler();

            //string path = @"D:\abc.txt";
            //recentFilesHandler.GetRecent(path);

            //recentFilesHandler.GetRecent(path);

            //RecentFiles.GetFilePath();
            //RecentFiles.SaveToJson(@"D:\coba.json");
            ////Console.WriteLine(RecentFiles.file_path[0]);
            ////Console.WriteLine("coba");
            ///
            //Console.WriteLine(Directory.GetCurrentDirectory());

            string path = @"D:\Foam2D\Resource\path.json";

            RecentFilesData recentFilesData = new RecentFilesData();
            recentFilesData.GetJsonData(path);

            Console.WriteLine(recentFilesData.FilePath);
            //recentFilesData.GetFileName();

            //Console.WriteLine(a);

            //string jsonfile = "";
            //string line;
            //using(StreamReader sr = new StreamReader(path))
            //{
            //    //string line;
            //    int? count= 0;
            //    while((line = sr.ReadLine()) != null)
            //    {
            //        Console.WriteLine(count) ;
            //        //count++;
            //        jsonfile += line;
            //        //Console.WriteLine(line);
            //    }

            //}

            //RecentFilesData? recentFilesData = new RecentFilesData();
            //try
            //{
            //    recentFilesData = JsonSerializer.Deserialize<RecentFilesData>(jsonfile);
            //}
            //catch (Exception)
            //{


            //}

            //Console.WriteLine(recentFilesData);



            //Console.WriteLine(jsonfile);

            Console.ReadKey();

            /*ieldAccessException.*/

            return 0;
        }
    }
}