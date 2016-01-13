using BoxDragXF;
using BoxDragXF.UWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(BoxViewEx), typeof(BoxExRenderer))]
namespace BoxDragXF.UWP
{
    class BoxExRenderer : Xamarin.Forms.Platform.UWP.BoxViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
        {
            base.OnElementChanged(e);
            this.ManipulationDelta += BoxExRenderer_ManipulationDelta1;
            this.ManipulationMode = Windows.UI.Xaml.Input.ManipulationModes.All;
        }

        private void BoxExRenderer_ManipulationDelta1(object sender, Windows.UI.Xaml.Input.ManipulationDeltaRoutedEventArgs e)
        {
            var el = this.Element as BoxViewEx;
            el.OnManipulationDelta(el, new BoxDragXF.ManipulationDeltaRoutedEventArgs(el, e.Delta.Translation.X, e.Delta.Translation.Y));
        }
    }
}
