using System;

using Foundation;
using AppKit;
using CoreAnimation;
using CoreGraphics;

namespace GodsEye
{
    public partial class MenuButton : NSButton
    {
        #region Constructors

        // Called when created from unmanaged code
        public MenuButton(IntPtr handle) : base(handle)
        {
            Initialize();
        }

        // Called when created directly from a XIB file
        [Export("initWithCoder:")]
        public MenuButton(NSCoder coder) : base(coder)
        {
            Initialize();
        }

        // Shared initialization code
        void Initialize()
        {
            this.WantsLayer = true;
            this.Layer.CornerRadius = 10;
            this.Layer.BorderColor = NSColor.White.CGColor;
            this.Layer.BorderWidth = (nfloat)0.35;
        }

        #endregion

        public enum ButtonType
        {
            CreateStrategy,
            OpenStrategy,
            SearchMarket
        }

        public void SetBackground(ButtonType type)
        {
            this.Layer.AddSublayer(this.CreateButtonGradient(type));
        }

        public void WasCLicked()
        {
            CABasicAnimation animation = new CABasicAnimation();
            animation.KeyPath = "transform";
            animation.From = NSValue.FromCATransform3D(CATransform3D.MakeScale(0.85f, 0.85f, 1f));
            animation.Duration = 0.15;
            this.Layer.AddAnimation(animation, animation.KeyPath);
        }

        private CAGradientLayer CreateButtonGradient(ButtonType type)
        {
            CGColor[] createStrategy = new CGColor[2] {
                NSColor.FromRgb(78, 84, 200).CGColor,
                NSColor.FromRgb(143, 148, 251).CGColor,
            };
            CGColor[] openStrategy = new CGColor[2] {
                NSColor.FromRgb(99, 99, 99).CGColor,
                NSColor.FromRgb(162, 171, 88).CGColor,
            };
            CGColor[] searchMarket = new CGColor[2] {
                NSColor.FromRgb(100, 43, 115).CGColor,
                NSColor.FromRgb(198, 66, 110).CGColor,
            };

            CAGradientLayer ButtonGradient = new CAGradientLayer
            {
                Colors = type == ButtonType.CreateStrategy ? createStrategy : type == ButtonType.OpenStrategy ? openStrategy : searchMarket,
                Frame = new CGRect(0, 0, 100, 100),
                Locations = new NSNumber[2] { 0.0, 1.0 },
                AutoresizingMask = CAAutoresizingMask.WidthSizable | CAAutoresizingMask.HeightSizable
            };

            return ButtonGradient;
        }
    }
}
