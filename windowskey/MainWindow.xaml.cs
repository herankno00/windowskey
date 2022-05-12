using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.WinApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Label = System.Windows.Controls.Label;

namespace windowskey
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window    
    {
        MouseHook mh;   
        public MainWindow()
        {
            InitializeComponent();
            this.Topmost = true;
        }
        protected override void OnMouseLeftButtonDown(System.Windows.Input.MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            // Begin dragging the window
            this.DragMove();
        }
        Dictionary<string, Label> kVPairs = new Dictionary<string, Label>();
        User32dll.KeyboardHook k = new User32dll.KeyboardHook();
        private void HookListener_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            // updatelable(Convert.ToInt32(e.KeyChar));
        }
        private void HookListener_KeyPuP(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            Dwdatelable(e.KeyCode.ToString());
        }
        private void HookListener_KeyPDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            updatelable(e.KeyCode.ToString());
        }

        public void updatelable(string keychars)
        {
            if (keychars.Length == 2 && keychars[0] == 'D')
            {
                keychars = keychars[1].ToString();
            }
            if (keychars.Length == 7 && keychars[0] == 'N')
            {
                keychars = keychars[6].ToString();
            }
            Label l;
            kVPairs.TryGetValue(keychars, out l);
            if (l != null)
            {
                l.Background = Brushes.Pink;
            }
        }
        public void Dwdatelable(string keychars)
        {
            if (keychars.Length == 2 && keychars[0] == 'D')
            {
                keychars = keychars[1].ToString();
            }
            if (keychars.Length == 7 && keychars[0] == 'N')
            {
                keychars = keychars[6].ToString();
            }
            Label l;
            kVPairs.TryGetValue(keychars, out l); if (l != null)
            {
                l.Background = null;
            }
        }
   

        private void Window_Initialized(object sender, EventArgs e)
        {
      

            bs = lftmouse.Background;
            foreach (object item in Grids.Children)
            {
                Label las = item as Label;
                if (las != null)
                {
                    string str = las.Content.ToString();
                    if (str.Length == 1)
                    {
                        kVPairs.Add(str.ToUpper(), las);
                    }
                    else
                    {
                        kVPairs.Add(str, las);
                    }
                } 
             
            }
            k.KeyPressEvent += new System.Windows.Forms.KeyPressEventHandler(HookListener_KeyPress);
            k.KeyUpEvent += new KeyEventHandler(HookListener_KeyPuP);
            k.KeyDownEvent += new KeyEventHandler(HookListener_KeyPDown);
            k.Start();
            mh = new MouseHook();
            mh.SetHook();
            mh.MouseMoveEvent += mh_MouseMoveEvent;
            mh.MouseClickEvent += mh_MouseClickEvent;
          
        }
        Brush bs = null;
        private   async void mh_MouseClickEvent(object sender, MouseEventArgs e)
        {
          
            if (e.Button == MouseButtons.Left) {
                lftmouse.Background = Brushes.Red;
                await Task.Delay(300);
                lftmouse.Background = bs;

            }
            else
            {
                 rttmouse.Background= Brushes.Red;
                await Task.Delay(300);
                rttmouse.Background = bs;

            }
        }
        private void mh_MouseMoveEvent(object sender, MouseEventArgs e)
        {
            // w100 h140 

            Amouse.SetValue(Canvas.TopProperty,(double)e.Y/20);
            Amouse.SetValue(Canvas.LeftProperty,(double)e.X/20);
         
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            mh.UnHook();
            k.Stop();
        }
    }
}
