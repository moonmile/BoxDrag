using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace BoxDrag.Android
{
    [Activity(Label = "BoxDrag.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it

            var text1 = this.FindViewById<TextView>(Resource.Id.textView1);
            var text2 = this.FindViewById<TextView>(Resource.Id.textView2);
            var box = this.FindViewById<View>(Resource.Id.box1);
            var btn1 = this.FindViewById<Button>(Resource.Id.button1);

            // 位置を初期化
            btn1.Click += (s, e) =>
            {
                setPos(50, 50);
                dispPos();
            };
            // 位置移動
            this.FindViewById<Button>(Resource.Id.buttonLeft).Click += delegate
            {
                setPos(box.Left - 20, box.Top);
                dispPos();
            };
            this.FindViewById<Button>(Resource.Id.buttonRight).Click += delegate
            {
                setPos(box.Left + 20, box.Top);
                dispPos();
            };
            this.FindViewById<Button>(Resource.Id.buttonUp).Click += delegate
            {
                setPos(box.Left, box.Top - 20);
                dispPos();
            };
            this.FindViewById<Button>(Resource.Id.buttonDown).Click += delegate
            {
                setPos(box.Left, box.Top + 20);
                dispPos();
            };

            box.Touch += Box_Touch;
            // OnManipulationDelta を設定
            this.ManipulationDelta += OnManipulationDelta;

        }


        float _gx, _gy; // 初期の相対値
        float _ox, _oy; // 前回の絶対位置
        int _box_w = 0, _box_h = 0; // 

        public event Action<object, ManipulationDeltaRoutedEventArgs> ManipulationDelta;


        /// <summary>
        /// ドラッグ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Box_Touch(object sender, View.TouchEventArgs e)
        {
            var box = sender as View;
            switch (e.Event.Action)
            {
                case MotionEventActions.Down:
                    // 初期の相対値を保存
                    _gx = e.Event.GetX();
                    _gy = e.Event.GetY();
                    _box_w = box.Width;
                    _box_h = box.Height;
                    break;
                case MotionEventActions.Move:
                    // 移動距離を計算
                    float dx = e.Event.RawX - _ox;
                    float dy = e.Event.RawY - _oy;
                    // 移動
                    // TODO: 誤差で少しずれるが実用上問題ない
                    // setPos((int)box.Left + (int)dx, (int)box.Top + (int)dy);
                    // OnManipulationDelta(sender, new ManipulationDeltaRoutedEventArgs(sender, (int)dx, (int)dy));

                    // イベント呼び出し
                    if (ManipulationDelta != null)
                    {
                        ManipulationDelta(sender, new ManipulationDeltaRoutedEventArgs(sender, (int)dx, (int)dy));
                    }

                    break;
                case MotionEventActions.Up:
                    break;
            }
            // 現在の絶対位置を保存
            _ox = e.Event.RawX;
            _oy = e.Event.RawY;
        }

        public class ManipulationDeltaRoutedEventArgs
        {
            public ManipulationDeltaRoutedEventArgs(object source, int deltaX, int deltaY)
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
                    public int X { get; set; }
                    public int Y { get; set; }
                }
            }
        }
        public virtual void OnManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            var el = e.OriginalSource as View;
            int x = el.Left + e.Delta.Translation.X;
            int y = el.Top + e.Delta.Translation.Y;
            // left, top は同時に設定する必要あり
            // RelativeLayoutHelper.SetLeft(el, x);
            // RelativeLayoutHelper.SetTop(el, y);
            RelativeLayoutHelper.SetXY(el, x, y);
        }

        void setPos(int x, int y)
        {
            var box = this.FindViewById<View>(Resource.Id.box1);
            // var lp = new RelativeLayout.LayoutParams(box.Width, box.Height);
            if (_box_w == 0 || _box_h == 0)
            {
                _box_w = box.Width;
                _box_h = box.Height;
            }
            var lp = new RelativeLayout.LayoutParams(_box_w, _box_h);
            lp.SetMargins(x, y, 0, 0);
            box.LayoutParameters = lp;
        }

        void dispPos()
        {
            var box = this.FindViewById<View>(Resource.Id.box1);
            var text1 = this.FindViewById<TextView>(Resource.Id.textView1);
            var x = box.Left;
            var y = box.Top;
            text1.Text = string.Format("GetX,Y: {0},{1}", x, y);
        }
    }
    class RelativeLayoutHelper
    {
        public static void SetLeft(View el, int left)
        {
            var lp = new RelativeLayout.LayoutParams(el.Width, el.Height);
            lp.SetMargins(left, el.Top, 0, 0);
            el.LayoutParameters = lp;
        }
        public static void SetTop(View el, int top)
        {
            var lp = new RelativeLayout.LayoutParams(el.Width, el.Height);
            lp.SetMargins(el.Left, top, 0, 0);
            el.LayoutParameters = lp;
        }
        public static void SetXY(View el, int left, int top)
        {
            var lp = new RelativeLayout.LayoutParams(el.Width, el.Height);
            lp.SetMargins(left, top, 0, 0);
            el.LayoutParameters = lp;
        }
    }
}

