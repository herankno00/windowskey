using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = Mouse.GetPosition(this);
            Point p1 = new Point(396, 432);
            Point p2 = new Point(p.X, p.Y);
            //距离
            double lines = (Math.Sqrt((p2.X - p1.X) * (p2.X - p1.X) + (p2.Y - p1.Y) * (p2.Y - p1.Y) - 24);

            //取整
            int anglex = Convert.ToInt32(lines);


            double angle = Math.Atan2(p2.X - p1.X, p2.Y - p1.Y);  //弧度  0.9272952180016122
            double theat = angle * (180 / Math.PI);  //角度  53.13010235415598
            TransformGroup transformGroup = new TransformGroup();
            RotateTransform rotateTransform = new RotateTransform();
            rotateTransform.Angle = 180 - theat;
            Dbro.SetValue(RenderTransformProperty, rotateTransform);
            //100 200
            //60  180

           


        }
    }
}
