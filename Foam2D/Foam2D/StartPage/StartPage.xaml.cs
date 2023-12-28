using Foam2D.Classes;
using System.Text.Json;
using Foam2D.StartPage.LoadRecentFile;

using System.Diagnostics;
//using Windows.Foundation.Collections;
//using Windows.Media.Protection.PlayReady;
using Foam2D.Models;

namespace Foam2D.StartPage;

public partial class StartPage : ContentPage
{

    
	public StartPage()
	{

        BindingContext = new LoadRecentFiles();
        InitializeComponent();

    }

    private async Task<string> LoadMauiAsset()
    {
        try
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync(@"path.json");
            using var reader = new StreamReader(stream);

            return reader.ReadToEnd();
        }
        catch (Exception ex)
        {
            return "";
        }

    }

    /// <summary>
    /// This open document button still used to prototyped the get file path method
    /// [] To Do : Create an configurator to save the CurrentFile.cs configuration such as file_path, file_name, date, etc
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void OpenBtn_Clicked(object sender, EventArgs e)
    {


        await OpenDocumentPicker.PickFile();
        //await DisplayAlert("Opening File", $"{OpenDocumentPicker.FileMetadata!.GetFileName}", "OK");

        //CurrentWorkingFileData currentWorkingFileData = new CurrentWorkingFileData(file_path.FileName, 
        //    file_path.FullPath, $"{DateTime.Now.ToString("dd-MM-yyyy, HH:mm")}");


        //RecentFile.UpdateJsonFile(currentWorkingFileData);
        //RecentFile.UpdateJsonFile($"coba{count}", $@"D:\", $"{DateTime.Now.ToString("dd-MM-yyyy")}");

        if (BindingContext is LoadRecentFiles loadrecentfiles)
        {
            loadrecentfiles.LoadRecent();
        }
    }

    

}