using Foam2D.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foam2D.Models
{
    public class CurrentWorkingFileData : IFileMetadata
    {
        private string? FileName { get; set; }
        private string? FilePath { get; set; }
        private string? DateModified {get; set; }

        public CurrentWorkingFileData()
        {

        }

        public CurrentWorkingFileData(string file_name, string file_path, string date_modified)
        {
            FileName = file_name;
            FilePath = file_path;
            DateModified = date_modified;
        }

        /// <summary>
        /// The File Metadata Should be Private
        /// </summary>
        public string? GetFileName => FileName;

        /// <summary>
        /// Setter for the file name metadata
        /// </summary>
        /// <param name="file_name"></param>
        public void SetFileName(string file_name)
        {
            FileName = file_name;
        }

        /// <summary>
        /// Getter for the file path
        /// </summary>
        public string? GetFilePath => FilePath;
        
        /// <summary>
        /// Setter for the file path
        /// </summary>
        /// <param name="file_path"></param>
        public void SetFilePath(string file_path)
        {
            this.FilePath = file_path;
        }

        /// <summary>
        /// Getter for the date modified
        /// </summary>
        public string? GetDateModified => DateModified;
        
        /// <summary>
        /// Setter for the date modified 
        /// </summary>
        /// <param name="date_modified"></param>
        public void SetDateModified(string date_modified)
        {
            this.DateModified = date_modified;
        }
    }
}
