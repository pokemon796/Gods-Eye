using System;
using System.Text;
using System.Timers;

using AppKit;
using Foundation;
using CoreGraphics;
using CoreAnimation;
using CoreFoundation;

namespace GodsEye
{
    public partial class ViewController : NSViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public News[] NewsStories;
        private int CurrentNewsPage;
        private Timer NewsUpdater;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Do any additional setup after loading the view.

            this.Menu.AlphaValue = 0;
            this.NewsPages.AlphaValue = 0;
            this.InternetNotice.AlphaValue = 0;

            this.CreateStrategy.SetBackground(MenuButton.ButtonType.CreateStrategy);
            this.OpenStrategy.SetBackground(MenuButton.ButtonType.OpenStrategy);
            this.SearchMarket.SetBackground(MenuButton.ButtonType.SearchMarket);

            this.Background.WantsLayer = true;
            this.Background.Layer.CornerRadius = (nfloat)7.5;
            this.Background.Layer.BorderColor = NSColor.White.CGColor;
            this.Background.Layer.BorderWidth = (nfloat)0.25;
            this.Background.Layer.AddSublayer(this.CreateBackgroundGradient());

            this.NewsSettings.WantsLayer = true;
            this.NewsSettings.AlphaValue = 0;
            this.NewsSettings.Layer.CornerRadius = 10;
            this.NewsSettings.Layer.MasksToBounds = true;
            this.NewsSettings.Layer.BorderColor = NSColor.White.CGColor;
            this.NewsSettings.Layer.BorderWidth = (nfloat)0.25;
            this.NewsSettings.Layer.BackgroundColor = NSColor.FromRgba(0, 0, 0, 0.4f).CGColor;
        }
        
        public override void ViewDidAppear()
        {
            this.View.Window.IsOpaque = false;
            this.View.Window.BackgroundColor = NSColor.Clear;
            this.View.Window.AlphaValue = 0;

            NSAnimationContext.RunAnimation(new Action<NSAnimationContext>(this.DisplayWindow));
            DispatchQueue.MainQueue.DispatchAfter(new DispatchTime(DispatchTime.Now, 1500000000), new Action(this.OpenApplication));

            this.URL.Activated += (sender, e) =>
            {
                NSWorkspace.SharedWorkspace.OpenUrl(new NSUrl(NewsStories[this.CurrentNewsPage].URL));
            };
        }

        public override NSObject RepresentedObject
        {
            get
            {
                return base.RepresentedObject;
            }
            set
            {
                base.RepresentedObject = value;
                // Update the view, if already loaded.
            }
        }

        public void SetupNews()
        {
            this.CurrentNewsPage = 0;
            this.NewsStories = NewsAPI.Main.GetStories();

            this.NewsUpdater = new Timer(5000);
            this.NewsUpdater.Elapsed += new ElapsedEventHandler(this.UpdateNews);
            this.NewsUpdater.Start();
        }

        public void UpdateNews(Object source, ElapsedEventArgs e)
        {
            DispatchQueue.MainQueue.DispatchAsync(new Action(() =>
            {
                NSAnimationContext.RunAnimation(new Action<NSAnimationContext>((context) =>
                {
                    context.Duration = 0.25;
                    ((NSTextField)this.Headline.Animator).AlphaValue = 0;
                    ((NSTextField)this.Source.Animator).AlphaValue = 0;
                }), new Action(() =>
                {
                    this.Headline.StringValue = RemoveSpecialCharacters(this.NewsStories[this.CurrentNewsPage].Title);
                    this.Source.StringValue = this.NewsStories[this.CurrentNewsPage].Source;
                    NSAnimationContext.RunAnimation(new Action<NSAnimationContext>((context) =>
                    {
                        context.Duration = 0.25;
                        ((NSTextField)this.Headline.Animator).AlphaValue = 1;
                        ((NSTextField)this.Source.Animator).AlphaValue = 1;
                    }));
                }));
                this.CurrentNewsPage += this.CurrentNewsPage == this.NewsStories.Length - 1 ? -(this.NewsStories.Length - 1) : 1;
            }));
        }

        private string RemoveSpecialCharacters(string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_' || c == ' ')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public void InternetDisconnected()
        {
            this.NewsPages.AlphaValue = 0;
            this.CreateStrategy.Enabled = false;
            this.OpenStrategy.Enabled = false;
            this.SearchMarket.Enabled = false;
            NSAnimationContext.RunAnimation(new Action<NSAnimationContext>(this.DisplayInternetNotice));
        }

        public void InternetReconnected()
        {
            this.CreateStrategy.Enabled = true;
            this.OpenStrategy.Enabled = true;
            this.SearchMarket.Enabled = true;
            NSAnimationContext.RunAnimation(new Action<NSAnimationContext>(this.DisplayInternetNotice));
        }

        private void DisplayWindow(NSAnimationContext context)
        {
            context.Duration = 0.5;
            ((NSWindow)this.View.Window.Animator).AlphaValue = 1;
        }

        private void OpenApplication()
        {
            CGRect windowFrame = new CGRect((NSScreen.MainScreen.Frame.Size.Width / 2) - 300, (NSScreen.MainScreen.Frame.Size.Height / 2) - 235, 600, 470);
            this.View.Window.SetFrame(windowFrame, true, true);

            this.View.Window.StyleMask = NSWindowStyle.Titled | NSWindowStyle.FullSizeContentView | NSWindowStyle.Closable | NSWindowStyle.Miniaturizable | NSWindowStyle.Resizable;

            ((AppDelegate)NSApplication.SharedApplication.Delegate).InitializeApplication();

            NSAnimationContext.RunAnimation(new Action<NSAnimationContext>(this.DisplayControls), new Action(() =>
            {
                this.SubTitleLabel.RemoveFromSuperview();
            }));
        }

        private void DisplayControls(NSAnimationContext context)
        {
            context.Duration = 0.5;
            ((NSView)this.SubTitleLabel.Animator).AlphaValue = 0;
            ((NSView)this.Menu.Animator).AlphaValue = 1;
            ((NSView)this.NewsSettings.Animator).AlphaValue = 1;
            ((NSView)this.NewsPages.Animator).AlphaValue = 1;
        }

        private void DisplayInternetNotice(NSAnimationContext context)
        {
            context.Duration = 0.5;
            ((NSView)this.InternetNotice.Animator).AlphaValue = this.CreateStrategy.Enabled ? 0 : 1;
        }

        private CAGradientLayer CreateBackgroundGradient()
        {
            CAGradientLayer BackgroundGradient = new CAGradientLayer
            {
                Colors = new CGColor[2] {
                    NSColor.FromRgb(20, 30, 48).CGColor,
                    NSColor.FromRgb(36, 59, 85).CGColor,
                },
                Frame = this.Background.Bounds,
                Locations = new NSNumber[2] { 0.0, 1.0 },
                AutoresizingMask = CAAutoresizingMask.WidthSizable | CAAutoresizingMask.HeightSizable
            };

            return BackgroundGradient;
        }

        partial void OpenNewsManagerPanel(NSObject sender)
        {
            CABasicAnimation animation = new CABasicAnimation();
            animation.KeyPath = "transform";
            animation.From = NSValue.FromCATransform3D(CATransform3D.MakeScale(0.85f, 0.85f, 1f));
            animation.Duration = 0.15;
            ((NSButton)sender).Layer.AddAnimation(animation, animation.KeyPath);
            this.PresentViewControllerAsSheet((NewsSourcesManagerController)this.Storyboard.InstantiateControllerWithIdentifier("NewsManagerPanel"));
        }
    }
}
