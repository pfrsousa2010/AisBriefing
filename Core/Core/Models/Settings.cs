namespace Core.Models
{
    public class Settings : BaseModel
    {
        bool darkTheme;

        public bool DarkTheme
        {
            get => darkTheme;
            set => SetProperty(ref darkTheme, value);
        }
    }
}
