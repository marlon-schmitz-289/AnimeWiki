using DragonBallWiki.Stores;
using DragonBallWiki.Views.Pages;
using System.Windows.Input;
using BaseClasses;
using DragonBallWiki.Models;

namespace DragonBallWiki.ViewModel
{
    class LoginViewModel : BaseModel
    {
        private ICommand _cmdLogin;
        public ICommand CmdLogin
        {
            get => _cmdLogin;
            private set
            {
                if (Equals(value, _cmdLogin)) return;
                _cmdLogin = value;
                OnPropertyChanged();
            }
        }

        
        private UserModel _currUser;
        public UserModel CurrUser
        {
            get => _currUser;
            set
            {
                if (Equals(value, _currUser)) return;
                _currUser = value;
                OnPropertyChanged();
            }
        }


        public LoginViewModel ()
        {
            CmdLogin = new BaseCommand(Login);
        }


        private void Login (object o)
        {
            if (CurrUser is not null)
            {
                CurrPageStore.SetCurr(new WikiPage());
            }
        }
    }
}
