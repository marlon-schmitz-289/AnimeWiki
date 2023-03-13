using DragonBallWiki.Models;
using DragonBallWiki.Stores;
using DragonBallWiki.Views.Pages;
using DragonBallWiki.Views.Windows;
using System.Collections.Generic;
using System.Windows.Input;
using BaseClasses;

namespace DragonBallWiki.ViewModel
{
    class WikiViewModel : BaseModel
    {
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }


        private List<CharacterModel> characters;
        public List<CharacterModel> Characters
        {
            get => characters;
            set
            {
                characters = value;
                OnPropertyChanged(nameof(Characters));
            }
        }


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


        public WikiViewModel ()
        {
            Characters = new()
            {
                new CharacterModel
                {
                    Name = "Jesus",
                    Description = "Sohn Gottes",
                    Abilities = new()
                    {
                        new AbilityModel
                        {
                            Name = "Water Walk",
                            Description = "Kann auf der Wasseroberfläche laufen"
                        },
                        new AbilityModel
                        {
                            Name = "Ultimate Heal",
                            Description = "Kann selbst Blindheit heilen"
                        }
                    }
                },
                new CharacterModel
                {
                    Name = "Judas",
                    Description = "Jünger unter Jesus",
                    Abilities = new()
                    {
                        new AbilityModel
                        {
                            Name = "Ultimate Betrayal",
                            Description = "Verrät alles und jeden, selbst Gott ist nicht sicher"
                        }
                    }
                },
            };


            AddCommand = new BaseCommand((o) =>
            {
                CurrPageStore.SetCurr(new CharacterAddPage());
            });


            EditCommand = new BaseCommand((o) =>
            {
                CurrPageStore.SetCurr(new CharacterEditPage());
            }, (s) => CurrCharacterModel is not null);


            DeleteCommand = new BaseCommand((o) =>
            {
                // delete CurrCharacter
                var modal = new ModalWindow("Test", "Test Test");
                modal.ShowDialog();
            }, (s) => CurrCharacterModel is not null);
        }
    }
}
