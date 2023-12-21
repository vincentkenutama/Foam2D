using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foam2DConsole.JsonParser
{
    public interface IJsonReader
    {
        public void GetJsonData(string path);
    }
}
