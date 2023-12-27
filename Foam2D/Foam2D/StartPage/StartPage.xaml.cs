using Foam2D.Classes;
using System.Text.Json;
using Foam2D.StartPage.LoadRecentFile;

using System.Diagnostics;

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

    int count;
    private void OpenBtn_Clicked(object sender, EventArgs e)
    {
        RecentFile.UpdateJsonFile($"coba{count}", $@"D:\", $"{DateTime.Now.ToString("dd-MM-yyyy")}");

        count++;
        if(BindingContext is LoadRecentFiles loadrecentfiles)
        {
            loadrecentfiles.LoadRecent();
        }
    }
}