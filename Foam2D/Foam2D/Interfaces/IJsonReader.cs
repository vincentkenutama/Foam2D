using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foam2D.Interfaces
{
    public interface IJsonReader
    {
        Task GetJsonDataAsync(string path);
    }
}
