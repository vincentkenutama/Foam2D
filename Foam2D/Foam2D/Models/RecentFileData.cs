using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foam2D.Models
{
    public class RecentFileData
    {
        public List<string>? FileName { get; set; }
        public List<string>? FilePath { get; set; }
        public List<string>? DateModified { get; set; }
    }
}
