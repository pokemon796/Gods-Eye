using System;

using Foundation;
using AppKit;

namespace GodsEye
{
    public partial class AddDomainViewController : NSViewController
    {
        #region Constructors

        // Called when created from unmanaged code
        public AddDomainViewController(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public AddDomainViewController(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Call to load from the XIB/NIB file
        public AddDomainViewController() : base("AddDomainView", NSBundle.MainBundle)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion

        private TextFieldManager Delegate;
        private DismissHandler Dismiss;

        //strongly typed view accessor
        public new AddDomainView View
        {
            get
            {
                return (AddDomainView)base.View;
            }
        }

        public override void ViewDidAppear()
        {
            base.ViewDidAppear();


            Delegate = new TextFieldManager(new Action(() =>
            {
                String Domain = this.URLTextField.StringValue;
                this.Submit.Enabled = Domain.Length > 0 && this.IsValidWebsite(Domain) && !NewsAPI.Main.DomainsList.Contains(Domain);
            }));

            this.URLTextField.Delegate = this.Delegate;
        }

        public void SetDismissHandler(DismissHandler Dismiss)
        {
            this.Dismiss = Dismiss;
        }

        partial void UserSubmittedNewSource(NSObject sender)
        {
            NewsAPI.Main.DomainsList.Add(ParseWebsite(this.URLTextField.StringValue));
            this.Close(this);
        }

        partial void Close(NSObject sender)
        {
            this.DismissController(this);
            this.Dismiss.HandleDismissal();
        }

        private bool IsValidWebsite(String URL)
        {
            return URL.Contains("www.") && URL.Contains(".com") && !URL.Contains("..");
        }

        private String ParseWebsite(String URL)
        {
            return URL.Substring(URL.IndexOf(".") + 1).Substring(0, URL.IndexOf(".com"));
        }
    }

    public class TextFieldManager: NSTextFieldDelegate
    {
        public Action ValueChanged;

        public TextFieldManager(Action ValueChanged)
        {
            this.ValueChanged = ValueChanged;
        }

        public override void Changed(NSNotification notification)
        {
            this.ValueChanged();
        }
    }

    public class DismissHandler
    {
        private Action Dismissed;

        public DismissHandler(Action Dismissed)
        {
            this.Dismissed = Dismissed;
        }

        public void HandleDismissal()
        {
            this.Dismissed();
        }
    }
}
