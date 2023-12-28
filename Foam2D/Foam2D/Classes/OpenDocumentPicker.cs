using Foam2D.Models;
using Microsoft.UI.Xaml.Markup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foam2D.Classes
{
    public class OpenDocumentPicker
    {

        private const string file_extension = ".jpg";
        public static CurrentWorkingFileData FileMetadata = new CurrentWorkingFileData();

        /// <summary>
        /// Open a file picker window, to open document available on local
        /// </summary>
        /// <returns></returns>
        public static async Task PickFile()
        {
            var customFileType = new FilePickerFileType(
                             new Dictionary<DevicePlatform, IEnumerable<string>>
                             {
                                 {DevicePlatform.WinUI, new[]{file_extension} }
                             });


            PickOptions options = new PickOptions
            {
                PickerTitle = "File Picker",
                FileTypes = customFileType
            };


            var file_path = await FilePicker.Default.PickAsync(options);
            if (file_path != null)
            {
                var time = $"{DateTime.Now.ToString("dd-MM-yyyy")}";

                CurrentWorkingFileData file = new CurrentWorkingFileData();
                //file.SetFileName(x);
                file.SetFileName(file_path.FileName);
                file.SetFilePath(file_path.FullPath);
                file.SetDateModified(time);
                //file_metadata = file;

                await UploadToJson(file);
                
            }
        }

        /// <summary>
        /// Updating the json file with the latest file opened
        /// </summary>
        /// <param name="current_file"></param>
        /// <returns></returns>
        public static async Task UploadToJson(CurrentWorkingFileData current_file)
        {
            await RecentFile.UpdateJsonFile(current_file);
        }
    }
}
