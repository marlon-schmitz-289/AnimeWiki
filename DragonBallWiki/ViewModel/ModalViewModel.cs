using DragonBallWiki.Views.Windows;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BaseClasses;

namespace DragonBallWiki.ViewModel
{
    public class ModalViewModel : BaseModel
    {
        public ICommand CloseCommand { get; set; }


        public ModalViewModel()
        {
            CloseCommand = new BaseCommand((o) =>
            {
                if (o is not Button b) return;
                switch (b.Name)
                {
                    case "Save":
                    {
                        for (var index = 0; index < Application.Current.Windows.Count; index++)
                        {
                            var w = Application.Current.Windows[index];
                            if (!w.GetType().Equals(typeof(ModalWindow))) continue;
                            Trace.WriteLine("Speichern");
                            w.Close();
                        }

                        break;
                    }
                    case "Cancel":
                    {
                        foreach (Window w in Application.Current.Windows)
                        {
                            if (!w.GetType().Equals(typeof(ModalWindow))) continue;
                            Trace.WriteLine("Abbrechen");
                            w.Close();
                        }

                        break;
                    }
                }
            });
        }
    }
}
