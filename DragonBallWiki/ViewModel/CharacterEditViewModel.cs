using DragonBallWiki.Commands;
using DragonBallWiki.Models;
using DragonBallWiki.Stores;
using DragonBallWiki.Views.Pages;
using System.Windows.Input;

namespace DragonBallWiki.ViewModel
{
    public class CharacterEditViewModel : BaseModel
    {
        public ICommand AddCommand { get; set; }
        public ICommand BackCommand { get; set; }


        private Character currCharacter;
        public Character CurrCharacter
        {
            get => currCharacter;
            set
            {
                currCharacter = value;
                OnPropertyChanged(nameof(CurrCharacter));
            }
        }


        public CharacterEditViewModel ()
        {
            CurrCharacter = new();

            AddCommand = new BaseCommand((o) =>
            {
                // save CurrCharacter to database
            }, (o) => CurrCharacter is not null);

            BackCommand = new BaseCommand((o) =>
            {
                CurrCharacter = new();
                CurrPageStore.SetCurr(new WikiPage());
            });
        }
    }
}
