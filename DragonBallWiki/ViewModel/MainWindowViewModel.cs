using DragonBallWiki.Stores;
using DragonBallWiki.Views.Pages;
using System.Windows.Controls;
using System.Windows.Input;
using BaseClasses;

namespace DragonBallWiki.ViewModel
{
    public class MainWindowViewModel : BaseModel
    {
        public ICommand CmdOnLoad { get; set; }


        public Page CurrPage
        {
            get => CurrPageStore.GetCurr();
            set
            {
                CurrPageStore.SetCurr(value);
                OnPropertyChanged(nameof(CurrPage));
            }
        }


        public MainWindowViewModel ()
        {
            CurrPageStore.CurrChanged += () => OnPropertyChanged(nameof(CurrPage));
            CmdOnLoad = new BaseCommand(OnLoad);
            CurrPage = new LoginPage();
        }


        private static void OnLoad (object sender)
        {
#if !DEBUG
            MediaPlayerStore.InitializePlayer();
            MediaPlayerStore.GetPlayer().Play();
#endif
        }
    }
}
