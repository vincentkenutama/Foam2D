using Foam2D.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foam2D.Classes
{
    public abstract class JsonReader
    {

        //public virtual void RecentFileJsonReader()
        //{

        //}
        //private 
        public static async Task RecentFileJsonReader(string path)
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync($@"{path}");
            using var reader = new StreamReader(stream);

        }
    }
}
