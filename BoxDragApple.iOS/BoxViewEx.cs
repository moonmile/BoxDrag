using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace BoxDragApple.iOS
{
	partial class BoxViewEx : UIView
	{
		public BoxViewEx (IntPtr handle) : base (handle)
		{
		}
        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);
            UITouch touch = touches.AnyObject as UITouch;

        }
        public override void TouchesMoved(NSSet touches, UIEvent evt)
        {
            base.TouchesMoved(touches, evt);
            UITouch touch = touches.AnyObject as UITouch;
            var newPoint = touch.LocationInView(this);
            var previousPoint = touch.PreviousLocationInView(this);
            nfloat offsetX = previousPoint.X - newPoint.X;
            nfloat offsetY = previousPoint.Y - newPoint.Y;
            this.Frame = new CoreGraphics.CGRect(
                this.Frame.X - offsetX,
                this.Frame.Y - offsetY,
                this.Frame.Width,
                this.Frame.Height);
        }
        public override void TouchesEnded(NSSet touches, UIEvent evt)
        {
            base.TouchesEnded(touches, evt);
        }
    }
}
