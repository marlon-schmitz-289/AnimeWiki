using DragonBallWiki.Views.Pages;
using System;
using System.Windows.Controls;

namespace DragonBallWiki.Stores
{
    class CurrPageStore
    {
        private static Page _curr;
        public static Action CurrChanged;


        public static Page GetCurr ()
        {
            _curr ??= new LoginPage();
            return _curr;
        }


        public static void SetCurr (Page newPage)
        {
            _curr = newPage is null ? new LoginPage() : newPage;
            CurrChanged?.Invoke();
        }
    }
}
