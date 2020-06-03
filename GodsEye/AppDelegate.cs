using System;
using AppKit;
using Foundation;

namespace GodsEye
{
    [Register("AppDelegate")]
    public class AppDelegate : NSApplicationDelegate
    {
        public AppDelegate()
        {
        }

        public override void DidFinishLaunching(NSNotification notification)
        {
            // Insert code here to initialize your application
        }

        public override void WillTerminate(NSNotification notification)
        {
            // Insert code here to tear down your application

            NewsAPI.Main.DomainsList.Save();
        }

        public void InitializeApplication()
        {
            Network.Main = new Network(new Action(this.InternetReconnected), new Action(this.InternetDisconnected));
            NewsAPI.Main = new NewsAPI();

            if (Network.Main.IsConnected())
            {
                NewsAPI.Main.FetchData(new Action(() =>
                {
                    ((ViewController)NSApplication.SharedApplication.MainWindow.ContentViewController).SetupNews();
                }));
            }
        }

        private void InternetDisconnected()
        {
            ((ViewController)NSApplication.SharedApplication.MainWindow.ContentViewController).InternetDisconnected();
        }

        public void InternetReconnected()
        {
            ((ViewController)NSApplication.SharedApplication.MainWindow.ContentViewController).InternetReconnected();
        }
    }
}
