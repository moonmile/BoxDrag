﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BoxDragXF
{
    public class BoxViewEx : BoxView
    {
        public virtual void OnManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            var rc = this.Bounds;
            rc.X += e.Delta.Translation.X;
            rc.Y += e.Delta.Translation.Y;
            this.Layout(rc);
        }
    }
    public class ManipulationDeltaRoutedEventArgs
    {
        public ManipulationDeltaRoutedEventArgs(object source, double deltaX, double deltaY)
        {
            this.OriginalSource = source;
            this.Delta = new Delta_()
            {
                Translation = new Delta_.Translation_()
                {
                    X = deltaX,
                    Y = deltaY
                }
            };
        }


        public Delta_ Delta { get; set; }
        public object OriginalSource { get; set; }
        public class Delta_
        {
            public Translation_ Translation { get; set; }
            public class Translation_
            {
                public double X { get; set; }
                public double Y { get; set; }
            }
        }
    }
}
