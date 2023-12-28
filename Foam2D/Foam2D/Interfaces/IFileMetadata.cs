using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foam2D.Interfaces
{
    interface IFileMetadata
    {
        /// <summary>
        /// File Name of current working file
        /// </summary>
        static string? FileName { get; set; }

        /// <summary>
        /// All files should provide the path to its source
        /// </summary>
        static string? FilePath {  get; set; }

        /// <summary>
        /// Date modified of the file 
        /// </summary>
        static string? DateModified { get; set; }

        //Uncomment this if needed
        //string? Author {  get; set; }

 
    }
}
