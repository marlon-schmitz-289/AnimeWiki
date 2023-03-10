using System.Windows;

namespace DragonBallWiki.Views.Windows
{
    public partial class ModalWindow : Window
    {
        public ModalWindow (string title, string text)
        {
            InitializeComponent();

            Title = title;
            TextBlock.Text = text;

            Owner = Application.Current.MainWindow;
        }


        public ModalWindow(string title, string text, Window owner) : this(title, text)
        {
            Owner = owner;
        }
    }
}
