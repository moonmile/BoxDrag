// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace BoxDragApple.iOS
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		BoxDragApple.iOS.BoxViewEx box1 { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnDown { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnInit { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnLeft { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnRight { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnUp { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (box1 != null) {
				box1.Dispose ();
				box1 = null;
			}
			if (btnDown != null) {
				btnDown.Dispose ();
				btnDown = null;
			}
			if (btnInit != null) {
				btnInit.Dispose ();
				btnInit = null;
			}
			if (btnLeft != null) {
				btnLeft.Dispose ();
				btnLeft = null;
			}
			if (btnRight != null) {
				btnRight.Dispose ();
				btnRight = null;
			}
			if (btnUp != null) {
				btnUp.Dispose ();
				btnUp = null;
			}
		}
	}
}
