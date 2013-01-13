using System.Windows;
using System.Windows.Controls;

namespace GrigCoreLastfm.UIComponent
{
    public sealed class LogInWindow : Window
    {
        public LogInWindow(WebBrowser wBroser)
        {
            Width = 500;
            Height = 400;
            Title = "LogIn to Last.fm";
            AddChild(wBroser);
        }
    }
}
