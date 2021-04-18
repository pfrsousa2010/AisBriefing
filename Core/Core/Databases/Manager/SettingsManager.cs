using Core.Models;
using System.Linq;

namespace Core.Databases.Manager
{
    public class SettingsManager : BaseManager<Settings>
    {
        public Settings GetSettings()
        {
            return Database.Settings.FirstOrDefault();
        }

    }
}
