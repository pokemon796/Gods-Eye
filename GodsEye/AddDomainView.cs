using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;

namespace GodsEye
{
    public partial class AddDomainView : AppKit.NSView
    {
        #region Constructors

        // Called when created from unmanaged code
        public AddDomainView(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public AddDomainView(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
        }

        #endregion
    }
}
