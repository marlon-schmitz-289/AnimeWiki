using DragonBallWiki.Commands;
using DragonBallWiki.Views.Windows;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DragonBallWiki.ViewModel
{
    public class ModalViewModel : BaseModel
    {
        public ICommand CloseCommand { get; set; }


        public ModalViewModel()
        {
            CloseCommand = new BaseCommand((o) =>
            {
                if (o is Button b)
                {
                    if (b.Name.Equals("Save"))
                    {
                        foreach (Window w in Application.Current.Windows)
                        {
                            if (w.GetType().Equals(typeof(ModalWindow)))
                            {
                                Trace.WriteLine("Speichern");
                                w.Close();
                            }
                        }
                    }
                    else if (b.Name.Equals("Cancel"))
                    {
                        foreach (Window w in Application.Current.Windows)
                        {
                            if (w.GetType().Equals(typeof(ModalWindow)))
                            {
                                Trace.WriteLine("Abbrechen");
                                w.Close();
                            }
                        }
                    }
                }
            });
        }
    }
}
