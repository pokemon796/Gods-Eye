using System;
using System.Collections;

using Foundation;
using AppKit;

namespace GodsEye
{
    public partial class NewsSourcesManagerController : NSViewController
    {
        #region Constructors

        // Called when created from unmanaged code
        public NewsSourcesManagerController(IntPtr handle) : base(handle)
        {
            Initialize(true);
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public NewsSourcesManagerController(NSCoder coder) : base(coder)
        {
            Initialize(true);
        }

        // Call to load from the XIB/NIB file
        public NewsSourcesManagerController() : base("NewsSourcesManager", NSBundle.MainBundle)
        {
            Initialize(true);
        }

        // Shared initialization code
        void Initialize(bool Booting)
        {
            ArrayList Domains = NewsAPI.Main.DomainsList.GetDomains();

            this.IconFiles = new String[Domains.Count];
            this.DomainURLs = new String[Domains.Count];

            for (int i = 0; i < Domains.Count; i++)
            {
                this.IconFiles[i] = ((String[])Domains[i])[0];
                this.DomainURLs[i] = ((String[])Domains[i])[1];
            }

            string[][] Data = new string[2][] { this.IconFiles, this.DomainURLs };

            if (Booting)
            {
                this.Delegate = new TableViewDataOrganizer(Data);
                this.DataSource = new TableViewDataManager(Data);
            }
            else
            {
                this.Delegate.ReloadData(Data);
                this.DataSource.ReloadData(Data);
            }
        }

        #endregion

        private TableViewDataOrganizer Delegate;
        private TableViewDataManager DataSource;

        private String[] IconFiles;
        private String[] DomainURLs;

        //strongly typed view accessor
        public new NewsSourcesManager View
        {
            get
            {
                return (NewsSourcesManager)base.View;
            }
        }

        public override void ViewDidAppear()
        {
            base.ViewDidAppear();

            this.SourceList.Delegate = this.Delegate;
            this.SourceList.DataSource = this.DataSource;
        }

        partial void ClosePanel(NSObject sender)
        {
            this.DismissController(this);
        }

        partial void Addsource(NSObject sender)
        {
            AddDomainViewController SourceAdder = (AddDomainViewController)this.Storyboard.InstantiateControllerWithIdentifier("AddDomainViewController");
            SourceAdder.SetDismissHandler(new DismissHandler(new Action(() =>
            {
                Initialize(false);
                this.SourceList.ReloadData();
            })));
            this.PresentViewControllerAsSheet(SourceAdder);
        }

        partial void RemoveSource(NSObject sender)
        {
            NewsAPI.Main.DomainsList.Remove((int)this.SourceList.SelectedRow);
            Initialize(false);
            this.SourceList.ReloadData();
        }
    }

    public class TableViewDataOrganizer: NSTableViewDelegate
    {
        private String[][] Data;

        private enum CellIdentifiers
        {
            WebsiteFavIcon,
            WebsiteDomain,
        }

        public TableViewDataOrganizer(String[][] Data)
        {
            this.Data = Data;
        }

        public void ReloadData(String[][] Data)
        {
            this.Data = Data;
        }

        public override NSView GetViewForItem(NSTableView tableView, NSTableColumn tableColumn, nint row)
        {
            CellIdentifiers CellIdentifier;

            NSImage FavIcon = null;
            String Domain = null;

            if (tableColumn.Equals(tableView.TableColumns()[0]))
            {
                CellIdentifier = CellIdentifiers.WebsiteFavIcon;
                FavIcon = new NSImage(new NSUrl(this.Data[0][row]));
            }
            else
            {
                CellIdentifier = CellIdentifiers.WebsiteDomain;
                Domain = this.Data[1][row];
            }
            
            NSTableCellView Cell = (NSTableCellView)tableView.MakeView(CellIdentifier.ToString(), this);
            if (Cell != null)
            {
                if (CellIdentifier == CellIdentifiers.WebsiteDomain)
                {
                    Cell.TextField.StringValue = Domain;
                }
                else
                {
                    Cell.ImageView.Image = FavIcon;
                }

                return Cell;
            }

            return null;
        }

        public override nfloat GetRowHeight(NSTableView tableView, nint row)
        {
            return 40;
        }
    }

    public class TableViewDataManager : NSTableViewDataSource
    {
        private String[][] Data;

        public TableViewDataManager(String[][] Data)
        {
            this.Data = Data;
        }

        public override nint GetRowCount(NSTableView tableView)
        {
            return (Data[0].Length + Data[1].Length) / 2;
        }

        public void ReloadData(String[][] Data)
        {
            this.Data = Data;
        }
    }
}
