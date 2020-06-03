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
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		AppKit.NSView Background { get; set; }

		[Outlet]
		GodsEye.MenuButton CreateStrategy { get; set; }

		[Outlet]
		AppKit.NSTextField Headline { get; set; }

		[Outlet]
		AppKit.NSView InternetNotice { get; set; }

		[Outlet]
		AppKit.NSStackView Menu { get; set; }

		[Outlet]
		AppKit.NSView NewsPages { get; set; }

		[Outlet]
		AppKit.NSButton NewsSettings { get; set; }

		[Outlet]
		GodsEye.MenuButton OpenStrategy { get; set; }

		[Outlet]
		GodsEye.MenuButton SearchMarket { get; set; }

		[Outlet]
		AppKit.NSTextField Source { get; set; }

		[Outlet]
		AppKit.NSTextField SubTitleLabel { get; set; }

		[Outlet]
		AppKit.NSImageView TitleIcon { get; set; }

		[Outlet]
		AppKit.NSTextField TitleLabel { get; set; }

		[Outlet]
		AppKit.NSButton URL { get; set; }

		[Action ("OpenNewsManagerPanel:")]
		partial void OpenNewsManagerPanel (Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (Background != null) {
				Background.Dispose ();
				Background = null;
			}

			if (CreateStrategy != null) {
				CreateStrategy.Dispose ();
				CreateStrategy = null;
			}

			if (InternetNotice != null) {
				InternetNotice.Dispose ();
				InternetNotice = null;
			}

			if (Menu != null) {
				Menu.Dispose ();
				Menu = null;
			}

			if (NewsPages != null) {
				NewsPages.Dispose ();
				NewsPages = null;
			}

			if (URL != null) {
				URL.Dispose ();
				URL = null;
			}

			if (Headline != null) {
				Headline.Dispose ();
				Headline = null;
			}

			if (Source != null) {
				Source.Dispose ();
				Source = null;
			}

			if (NewsSettings != null) {
				NewsSettings.Dispose ();
				NewsSettings = null;
			}

			if (OpenStrategy != null) {
				OpenStrategy.Dispose ();
				OpenStrategy = null;
			}

			if (SearchMarket != null) {
				SearchMarket.Dispose ();
				SearchMarket = null;
			}

			if (SubTitleLabel != null) {
				SubTitleLabel.Dispose ();
				SubTitleLabel = null;
			}

			if (TitleIcon != null) {
				TitleIcon.Dispose ();
				TitleIcon = null;
			}

			if (TitleLabel != null) {
				TitleLabel.Dispose ();
				TitleLabel = null;
			}
		}
	}
}
