using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Diagnostics;

using Foam2D.Interfaces;
using Foam2D.Classes;
using Foam2D.Models;


namespace Foam2D.Classes
{
    public class RecentFile : RecentFileData, IJsonReader
    {
        private static RecentFileData? json_data = new RecentFileData
        {
            FileName = new List<string> { },
            FilePath = new List<string> { },
            DateModified = new List<string> { }
        };
            

        private static Queue<List<string>> RecentFileQueue = new Queue<List<string>>();

        private static Queue<string> FileNameQueue = new Queue<string>();
        private static Queue<string> FilePathQueue = new Queue<string>();
        private static Queue<string> DateModifiedQueue = new Queue<string>();


        /// <summary>
        /// Check if the json data is null or not returning boolean
        /// </summary>
        public static bool IsNull = true;

        /// <summary>
        /// Check if the json is loaded or not
        /// </summary>
        private static bool PathSetted { get; set; }

        /// <summary>
        /// Json Path Must be Provided First
        /// </summary>
        private static string? Json_Path;


        /// <summary>
        /// Set the json path, must be done first before all thing
        /// </summary>
        /// <param name="path"></param>
        public static void SetJsonPath(string path)
        {
            Json_Path = path;
            PathSetted = true;
        }

        /// <summary>
        /// Reading the recent file from json "path.json" file
        /// returning nothing, but it stores the data at RecentFileData classs
        /// </summary>
        public static void RecentFileJsonReader()
        {
            if (!PathSetted) return;
            //using var stream = await FileSystem.OpenAppPackageFileAsync($@"D:\Foam2D\Foam2D\Foam2D\Resources\Raw\path.json");
            var stream = File.ReadAllText($@"D:\Foam2D\Foam2D\Foam2D\Resources\Raw\path.json");
            using (var reader = new StringReader(stream))
            {
                try
                {

                    json_data = JsonSerializer.Deserialize<RecentFileData>(stream);
                    if (json_data != null) {IsNull = false;}
                }
                catch 
                {
                    Debug.Assert(PathSetted);
                }

            }

            

            //Slower, 15 vs 5

            //foreach (var name_data in json_data.FileName)
            //{
            //    FileNameQueue.Enqueue(name_data);

            //}

            //foreach(var path_data in json_data.FilePath)
            //{
            //    FilePathQueue.Enqueue(path_data);
            //}

            //foreach(var modified_data in json_data.DateModified)
            //{
            //    DateModifiedQueue.Enqueue(modified_data);
            //}


        }

        /// <summary>
        /// Clearing The Json Data for Next Queue
        /// </summary>
        private static void ClearJsonBuffer()
        {
            json_data?.FileName?.Clear();
            json_data?.FilePath?.Clear();
            json_data?.DateModified?.Clear();
        }

        /// <summary>
        /// Copying All Json Data to the Queue
        /// </summary>
        private static void CopyJsonBuffer()
        {
            for (int i = 0; i < json_data?.FileName?.Count; i++)
            {
                
                FileNameQueue?.Enqueue(json_data.FileName[i]);
                FilePathQueue?.Enqueue(json_data?.FilePath?[i]);
                DateModifiedQueue?.Enqueue(json_data?.DateModified?[i]);
            }
        }

        public static void UpdateJsonFile(string file_name, string file_path, string date_modified)
        {
            //Return if the path for json is not setted
            if (!PathSetted) return;

            FileNameQueue.Enqueue(file_name);
            FilePathQueue.Enqueue(file_path);
            DateModifiedQueue.Enqueue(date_modified);

            CopyJsonBuffer();
            ClearJsonBuffer();
            
            for (int i = 0; i < 5; i++)
            {
                if (!FileNameQueue.TryPeek(out var fileName)) break;

                json_data?.FileName?.Add(FileNameQueue.Dequeue());
                json_data?.FilePath?.Add(FilePathQueue.Dequeue());
                json_data?.DateModified?.Add(DateModifiedQueue.Dequeue());

            }

            //Checking if there is a queue available after 5 recent files
            //Commonly causing bug, if this section is nowhere.
            if(FileNameQueue.TryPeek(out var Filename))
            {
                for(int i = 0; i < FileNameQueue.Count; i++)
                {
                    FileNameQueue.Dequeue();
                    FilePathQueue.Dequeue();
                    DateModifiedQueue.Dequeue();
                }
            }
           
           

            string json_serial = JsonSerializer.Serialize(json_data);

            using (StreamWriter writer = new StreamWriter($@"D:\Foam2D\Foam2D\Foam2D\Resources\Raw\path.json"))
            {
                writer.WriteLine(json_serial);
            }

        }      

        /// <summary>
        /// Returning the file name data getted by RecentFileJsonReader Method
        /// </summary>
        /// <returns></returns>
        public static List<string>? GetFileName() => json_data?.FileName;

        /// <summary>
        /// Returning the file path data getted by RecentFileJsonReader method
        /// </summary>
        /// <returns></returns>
        public static List<string>? GetFilePath() => json_data?.FilePath;

        /// <summary>
        /// Returning the file last modified data getted by RecentFileJsonReader method
        /// </summary>
        /// <returns></returns>
        public static List<string>? GetLastModified() => json_data?.DateModified;
    }
    
}

