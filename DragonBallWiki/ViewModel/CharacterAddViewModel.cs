using DragonBallWiki.Models;
using DragonBallWiki.Stores;
using DragonBallWiki.Views.Pages;
using System.Windows.Input;
using BaseClasses;

namespace DragonBallWiki.ViewModel
{
    public class CharacterAddViewModel : BaseModel
    {
        public ICommand AddCommand { get; set; }
        public ICommand BackCommand { get; set; }


        private CharacterModel _currCharacterModel;

        public CharacterModel CurrCharacterModel
        {
            get => _currCharacterModel;
            set
            {
                _currCharacterModel = value;
                OnPropertyChanged(nameof(CurrCharacterModel));
            }
        }


        public CharacterAddViewModel()
        {
            CurrCharacterModel = new();

            AddCommand = new BaseCommand((o) =>
            {
                // save CurrCharacter to database
            }, (o) => CurrCharacterModel is not null);

            BackCommand = new BaseCommand((o) =>
            {
                CurrCharacterModel = new();
                CurrPageStore.SetCurr(new WikiPage());
            });
        }
    }
}