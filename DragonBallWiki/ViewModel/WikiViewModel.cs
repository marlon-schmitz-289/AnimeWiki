using DragonBallWiki.Commands;
using DragonBallWiki.Models;
using DragonBallWiki.Stores;
using DragonBallWiki.Views.Pages;
using DragonBallWiki.Views.Windows;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Windows.Input;

namespace DragonBallWiki.ViewModel
{
    class WikiViewModel : BaseModel
    {
        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }


        private List<Character> characters;
        public List<Character> Characters
        {
            get => characters;
            set
            {
                characters = value;
                OnPropertyChanged(nameof(Characters));
            }
        }


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


        public WikiViewModel ()
        {
            Characters = new()
            {
                new Character
                {
                    Name = "Jesus",
                    Description = "Sohn Gottes",
                    Abilities = new()
                    {
                        new Ability
                        {
                            Name = "Water Walk",
                            Description = "Kann auf der Wasseroberfläche laufen"
                        },
                        new Ability
                        {
                            Name = "Ultimate Heal",
                            Description = "Kann selbst Blindheit heilen"
                        }
                    }
                },
                new Character
                {
                    Name = "Judas",
                    Description = "Jünger unter Jesus",
                    Abilities = new()
                    {
                        new Ability
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
            }, (s) => CurrCharacter is not null);


            DeleteCommand = new BaseCommand((o) =>
            {
                // delete CurrCharacter
                var modal = new ModalWindow("Test", "Test Test");
                modal.ShowDialog();
            }, (s) => CurrCharacter is not null);
        }
    }
}
