using System;
using System.Windows;
using Учебная_практика;

namespace Practic3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void wmp_start_Click(object sender, RoutedEventArgs e)
        {
            Kernel32.WinExec(@"C:\Program Files\Windows Media Player\wmplayer.exe", Kernel32.ShowWind.SW_SHOWNORMAL);
        }

        private void aimp_start_Click(object sender, RoutedEventArgs e)
        {
            Kernel32.WinExec(@"C:\Users\ИВАН\Desktop\Alex\Program\AIMP\AIMP.exe", Kernel32.ShowWind.SW_SHOWNORMAL);
        }

        private void d_start_Click(object sender, RoutedEventArgs e)
        {
            Kernel32.WinExec(@"C:\Users\ИВАН\Desktop\Alex\Program\VLC\vlc.exe", Kernel32.ShowWind.SW_SHOWNORMAL);
        }

        private void f_start_Click(object sender, RoutedEventArgs e)
        {
            Kernel32.WinExec(@"C:\Users\ИВАН\Desktop\Alex\Program\foobinx\foobnix.exe", Kernel32.ShowWind.SW_SHOWNORMAL);
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);

        }
    }
}
