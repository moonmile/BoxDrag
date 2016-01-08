using BoxDragXF;
using BoxDragXF.WinPhone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;

[assembly: ExportRenderer(typeof(BoxViewEx), typeof(BoxExRenderer))]
namespace BoxDragXF.WinPhone
{
    class BoxExRenderer : Xamarin.Forms.Platform.WinPhone.BoxViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
        {
            base.OnElementChanged(e);
            this.ManipulationDelta += BoxExRenderer_ManipulationDelta;
        }
        
        private void BoxExRenderer_ManipulationDelta(object sender, System.Windows.Input.ManipulationDeltaEventArgs e)
        {
            var el = this.Element as BoxViewEx;
            el.OnManipulationDelta(el, new BoxDragXF.ManipulationDeltaRoutedEventArgs(el, e.DeltaManipulation.Translation.X, e.DeltaManipulation.Translation.Y));
        }
    }
}
