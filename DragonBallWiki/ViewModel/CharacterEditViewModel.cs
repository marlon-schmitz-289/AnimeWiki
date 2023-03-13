using DragonBallWiki.Models;
using DragonBallWiki.Stores;
using DragonBallWiki.Views.Pages;
using System.Windows.Input;
using BaseClasses;

namespace DragonBallWiki.ViewModel
{
    public class CharacterEditViewModel : BaseModel
    {
        public ICommand AddCommand { get; set; }
        public ICommand BackCommand { get; set; }


        private CharacterModel? _currCharacter;
        public CharacterModel? CurrCharacter
        {
            get => _currCharacter;
            set
            {
                _currCharacter = value;
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
