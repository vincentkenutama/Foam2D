using Foam2D.Classes;
using System.Text.Json;
using Foam2D.StartPage.LoadRecentFile;

namespace Foam2D.StartPage;

public partial class StartPage : ContentPage
{

    RecentFile recent = new RecentFile();
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
}