using Core.Helpers;
using System.IO;
using Windows.Storage;

namespace Core.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            
            var dbPath = Path.Combine(ApplicationData.Current.LocalFolder.Path, "aisbriefing.sqlite");
            LoadApplication(new Core.App(dbPath));
        }
    }
}
