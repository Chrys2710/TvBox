using System;
using System.Windows;

namespace TvBox.Views
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //System.Diagnostics.Process.Start("chrome", "https://www.mycanal.fr/live/&params[tab]=/live-tv/pid5170-live-tv-v2-liste-des-chaines.html&params[filter]=0&params[filters-0$g$]=0$g$2$&params[filters-1$pt$]=current&get=500?epgId=177");

            //Chrome tests
            var chrome = new Chrome("http://localhost:9222");
            var sessions = chrome.GetAvailableSessions();
            //Console.WriteLine("Available debugging sessions");
            //foreach (var s in sessions)
            //Console.WriteLine(s.url);

            if (sessions.Count == 0)
                throw new Exception("All debugging sessions are taken.");

            // Will drive first tab session
            var sessionWSEndpoint = sessions[0].webSocketDebuggerUrl;
            chrome.SetActiveSession(sessionWSEndpoint);
            chrome.NavigateTo("https://www.mycanal.fr/live/&params[tab]=/live-tv/pid5170-live-tv-v2-liste-des-chaines.html&params[filter]=0&params[filters-0$g$]=0$g$2$&params[filters-1$pt$]=current&get=500?epgId=177");



            //var result = chrome.Eval("document.getElementById('lst-ib').value='Hello World'");
            //result = chrome.Eval("document.forms[0].submit()");

            //Console.ReadLine();
        }
    }
}
