using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace AnimeCheerDesktopMascot
{
    public static class Commands
    {
        public static readonly RoutedUICommand Topmost = new RoutedUICommand();
        public static readonly RoutedUICommand Exit = new RoutedUICommand();
        public static readonly RoutedUICommand MouseoverTransparency = new RoutedUICommand();
        public static readonly RoutedUICommand LockWindow = new RoutedUICommand();
        public static readonly RoutedUICommand HalfSize = new RoutedUICommand();
    }

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static AnimeCheerDesktopMascotWindow AnimeCheerDesktopMascotWindow = null;
        public static bool CheckMalal = true;

        public App()
        {
            InitializeComponent();
            var topmostBinding = new CommandBinding(Commands.Topmost, TopmostExecuted, CommandCanExecute);
            var mouseoverTransparencyBinding = new CommandBinding(Commands.MouseoverTransparency, MouseoverTransparencyExecuted, CommandCanExecute);
            var lockwindowBinding = new CommandBinding(Commands.LockWindow, LockWindowExecuted, CommandCanExecute);
            var exitBinding = new CommandBinding(Commands.Exit, ExitExecuted, CommandCanExecute);
            var halfsizeBinding = new CommandBinding(Commands.HalfSize, HalfSizeExecuted, CommandCanExecute);
            CommandManager.RegisterClassCommandBinding(typeof(Popup), topmostBinding);
            CommandManager.RegisterClassCommandBinding(typeof(Popup), exitBinding);
            CommandManager.RegisterClassCommandBinding(typeof(Popup), mouseoverTransparencyBinding);
            CommandManager.RegisterClassCommandBinding(typeof(Popup), lockwindowBinding);
            CommandManager.RegisterClassCommandBinding(typeof(Popup), halfsizeBinding);
        }

        private void HalfSizeExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (AnimeCheerDesktopMascot.Properties.Settings.Default.HalfSize)
            {
                AnimeCheerDesktopMascotWindow.Width /= 2;
                AnimeCheerDesktopMascotWindow.Height /= 2;
            }
            else
            {
                AnimeCheerDesktopMascotWindow.Width = AnimeCheerDesktopMascotWindow.DefaultWidth;
                AnimeCheerDesktopMascotWindow.Height = AnimeCheerDesktopMascotWindow.DefaultHeight;
            }

            AnimeCheerDesktopMascot.Properties.Settings.Default.Save();
        }

        private void LockWindowExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            AnimeCheerDesktopMascot.Properties.Settings.Default.Save();
        }

        private void MouseoverTransparencyExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (!AnimeCheerDesktopMascot.Properties.Settings.Default.MouseoverTransparency)
            {
                AnimeCheerDesktopMascotWindow.CheerImage.Opacity = 1;
            }

            AnimeCheerDesktopMascot.Properties.Settings.Default.Save();
        }

        private void CommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void TopmostExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            AnimeCheerDesktopMascotWindow.Topmost = AnimeCheerDesktopMascot.Properties.Settings.Default.Topmost;
            AnimeCheerDesktopMascot.Properties.Settings.Default.Save();
        }

        private void ExitExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Console.WriteLine("Exit");
            Shutdown();
        }
    }
}
