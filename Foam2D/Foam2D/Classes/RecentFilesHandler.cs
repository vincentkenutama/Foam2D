using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Foam2D.Interfaces;

namespace Foam2D.Classes
{
    internal class RecentFile : IJsonReader
    {
        public string? FileName { get; set; }
        public string? FilePath { get; set; }
        public string? LastModified { get; set; }

        public RecentFile() { }

        public async Task GetJsonDataAsync(string path)
        {

            using var stream = await FileSystem.OpenAppPackageFileAsync($@"{path}");
            using var reader = new StreamReader(stream);

            RecentFile? jsondata = JsonSerializer.Deserialize<RecentFile>(reader.ReadToEnd());

            this.FileName = jsondata?.FileName ?? string.Empty;
            this.FilePath = jsondata?.FilePath ?? string.Empty;
            this.LastModified = jsondata?.LastModified;
        }
    }
    
}

