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
	[Register ("NewsSourcesManagerController")]
	partial class NewsSourcesManagerController
	{
		[Outlet]
		AppKit.NSButton AddItem { get; set; }

		[Outlet]
		AppKit.NSButton Exit { get; set; }

		[Outlet]
		AppKit.NSButton RemoveItem { get; set; }

		[Outlet]
		AppKit.NSTableView SourceList { get; set; }

		[Outlet]
		AppKit.NSTextField Title { get; set; }

		[Action ("Addsource:")]
		partial void Addsource (Foundation.NSObject sender);

		[Action ("AddSource:")]
		partial void AddSource (Foundation.NSObject sender);

		[Action ("ClosePanel:")]
		partial void ClosePanel (Foundation.NSObject sender);

		[Action ("RemoveSource:")]
		partial void RemoveSource (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (AddItem != null) {
				AddItem.Dispose ();
				AddItem = null;
			}

			if (Exit != null) {
				Exit.Dispose ();
				Exit = null;
			}

			if (RemoveItem != null) {
				RemoveItem.Dispose ();
				RemoveItem = null;
			}

			if (SourceList != null) {
				SourceList.Dispose ();
				SourceList = null;
			}

			if (Title != null) {
				Title.Dispose ();
				Title = null;
			}
		}
	}
}
