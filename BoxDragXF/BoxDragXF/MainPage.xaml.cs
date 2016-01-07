using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace BoxDragXF
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.LayoutChanged += MainPage_LayoutChanged;
        }

        private void MainPage_LayoutChanged(object sender, EventArgs e)
        {
            button1.Clicked += delegate {
                var rc = box1.Bounds;
                rc.X = 50;
                rc.Y = 50;
                box1.LayoutTo(rc);
            };
            buttonLeft.Clicked += delegate
            {
                var rc = box1.Bounds;
                rc.X -= 20;
                box1.LayoutTo(rc);
            };
            buttonRight.Clicked += delegate
            {
                var rc = box1.Bounds;
                rc.X += 20;
                box1.LayoutTo(rc);
            };
            buttonUp.Clicked += delegate
            {
                var rc = box1.Bounds;
                rc.Y -= 20;
                box1.LayoutTo(rc);
            };
            buttonDown.Clicked += delegate
            {
                var rc = box1.Bounds;
                rc.Y += 20;
                box1.LayoutTo(rc);
            };
        }
    }
}
