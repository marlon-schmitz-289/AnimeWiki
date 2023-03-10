using DragonBallWiki.Commands;
using DragonBallWiki.Stores;
using DragonBallWiki.Views.Pages;
using System.Windows.Input;

namespace DragonBallWiki.ViewModel
{
    class LoginViewModel : BaseModel
    {
        public ICommand CmdLogin { get; set; }


        public LoginViewModel ()
        {
            CmdLogin = new BaseCommand(Login);
        }


        private void Login (object o)
        {
            CurrPageStore.SetCurr(new WikiPage());
        }
    }
}
