using System;
using Foundation;
using UIKit;

namespace BoxDragApple.iOS
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            this.btnInit.TouchUpInside += (s, e) => {
                this.box1.Frame = new CoreGraphics.CGRect(new CoreGraphics.CGPoint(100, 100), box1.Frame.Size);
            };
            this.btnLeft.TouchUpInside += (s, e) => {
                this.box1.Frame = new CoreGraphics.CGRect(
                    new CoreGraphics.CGPoint(this.box1.Frame.Left - 20, box1.Frame.Top),
                    box1.Frame.Size);
            };
            this.btnRight.TouchUpInside += (s, e) => {
                this.box1.Frame = new CoreGraphics.CGRect(
                    new CoreGraphics.CGPoint(this.box1.Frame.Left + 20, box1.Frame.Top),
                    box1.Frame.Size);
            };
            this.btnUp.TouchUpInside += (s, e) => {
                this.box1.Frame = new CoreGraphics.CGRect(
                    new CoreGraphics.CGPoint(this.box1.Frame.Left, box1.Frame.Top - 20),
                    box1.Frame.Size);
            };
            this.btnDown.TouchUpInside += (s, e) => {
                this.box1.Frame = new CoreGraphics.CGRect(
                    new CoreGraphics.CGPoint(this.box1.Frame.Left, box1.Frame.Top + 20),
                    box1.Frame.Size);
            };
        }


        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }

}