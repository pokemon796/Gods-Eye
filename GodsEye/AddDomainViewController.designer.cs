// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace GodsEye
{
	[Register ("AddDomainViewController")]
	partial class AddDomainViewController
	{
		[Outlet]
		AppKit.NSTextField Description { get; set; }

		[Outlet]
		AppKit.NSButton Exit { get; set; }

		[Outlet]
		AppKit.NSButton Submit { get; set; }

		[Outlet]
		AppKit.NSTextField Title { get; set; }

		[Outlet]
		AppKit.NSTextField URLTextField { get; set; }

		[Action ("Close:")]
		partial void Close (Foundation.NSObject sender);

		[Action ("UserSubmittedNewSource:")]
		partial void UserSubmittedNewSource (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (Title != null) {
				Title.Dispose ();
				Title = null;
			}

			if (Description != null) {
				Description.Dispose ();
				Description = null;
			}

			if (URLTextField != null) {
				URLTextField.Dispose ();
				URLTextField = null;
			}

			if (Submit != null) {
				Submit.Dispose ();
				Submit = null;
			}

			if (Exit != null) {
				Exit.Dispose ();
				Exit = null;
			}
		}
	}
}
