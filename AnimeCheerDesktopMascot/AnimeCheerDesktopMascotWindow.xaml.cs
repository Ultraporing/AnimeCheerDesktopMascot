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

namespace AnimeCheerDesktopMascot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AnimeCheerDesktopMascotWindow : Window
    {
        public double DefaultWidth = 0;
        public double DefaultHeight = 0;

        public AnimeCheerDesktopMascotWindow()
        {
            InitializeComponent();
            DefaultWidth = Width;
            DefaultHeight = Height;
            App.AnimeCheerDesktopMascotWindow = this;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                if (Properties.Settings.Default.LockWindow)
                {
                    return;
                }

                this.DragMove();
                Properties.Settings.Default.LastWindowPos = new System.Drawing.Point((int)Left, (int)Top);
                Properties.Settings.Default.Save();
            }
                
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Topmost = Properties.Settings.Default.Topmost;

            if (Properties.Settings.Default.FirstRun)
            {
                var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;

                if (Properties.Settings.Default.HalfSize)
                {
                    this.Width /= 2;
                    this.Height /= 2;
                }

                this.Left = desktopWorkingArea.Right - this.Width;
                this.Top = desktopWorkingArea.Bottom - this.Height;

                Properties.Settings.Default.FirstRun = false;
                Properties.Settings.Default.LastWindowPos = new System.Drawing.Point((int)Left, (int)Top);
                Properties.Settings.Default.Save();
            }
            else
            {
                this.Left = Properties.Settings.Default.LastWindowPos.X;
                this.Top = Properties.Settings.Default.LastWindowPos.Y;
            }
        }

        private void CheerImage_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Properties.Settings.Default.MouseoverTransparency)
            {
                CheerImage.Opacity = 0.5;
            }
        }

        private void CheerImage_MouseLeave(object sender, MouseEventArgs e)
        {
            CheerImage.Opacity = 1;
        }
    }
}
