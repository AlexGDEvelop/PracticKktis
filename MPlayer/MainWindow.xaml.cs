using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
//using System.Threading;
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
using System.Timers;
using System.Threading;
using System.Windows.Threading;

namespace MPlayer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MediaPlayer player = new MediaPlayer();

        string[] words;
        Uri[] urisMas;
        DispatcherTimer aTimer;
        int index = 0;


        public MainWindow()
        {
            InitializeComponent();

            aTimer = new DispatcherTimer();
            aTimer.Interval = TimeSpan.FromSeconds(0.5);
            aTimer.Tick += new EventHandler(OnTimedEvent);
            myMediaElement.MediaOpened += Element_MediaOpened;
            myMediaElement.MediaEnded += Element_MediaEnded;
        }

        private void OnTimedEvent(Object source, EventArgs e)
        {

            timelineSlider.Value = myMediaElement.Position.TotalMilliseconds;
            ftime.Content =TimeSpan.FromSeconds(Math.Round(myMediaElement.Position.TotalSeconds));

        }
        

        void OnMouseDownPlayMedia(object sender, MouseButtonEventArgs args)
        {


            myMediaElement.Visibility = Visibility.Visible;
            try
            {
                if (urisMas != null & sender != fed) myMediaElement.Source = new Uri(sender.ToString());

            }
            catch(Exception l)
            {

            }
            myMediaElement.Play();
            
            aTimer.Start();

            InitializePropertyValues();
        }


        void OnMouseDownPauseMedia(object sender, MouseButtonEventArgs args)
        {

            // The Pause method pauses the media if it is currently running.
            // The Play method can be used to resume.
            myMediaElement.Pause();
        }

        void OnMouseDownLeftRewMedia(object sender, MouseButtonEventArgs args)
        {

            if(urisMas.Length!=0&index!=0)index--;
            OnMouseDownPlayMedia(urisMas[index], null);


        }

        void OnMouseDownRightRewMedia(object sender, MouseButtonEventArgs args)
        {
            if (urisMas != null)
            {
                if (urisMas.Length != 0 & urisMas.Length != index + 1)
                {
                    index++;
                    OnMouseDownPlayMedia(urisMas[index], null);
                }
            }
            
            
        }

        void OnMouseDownListMedia(object sender, MouseButtonEventArgs args)
        {

            if (myMediaElement.Visibility == Visibility.Hidden) myMediaElement.Visibility = Visibility.Visible;
            else myMediaElement.Visibility = Visibility.Hidden;

        }

        void OnMouseDownStopMedia(object sender, MouseButtonEventArgs args)
        {

            // The Stop method stops and resets the media to be played from
            // the beginning.
            myMediaElement.Stop();
            aTimer.Stop();
        }

        private void ChangeMediaVolume(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            myMediaElement.Volume = (double)volumeSlider.Value;
        }


        private void ChangeMediaSpeedRatio(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            myMediaElement.SpeedRatio = (double)speedRatioSlider.Value;
        }

        private void Element_MediaOpened(object sender, EventArgs e)
        {
            

            try
            {
  
                timelineSlider.Maximum = myMediaElement.NaturalDuration.TimeSpan.TotalMilliseconds;

                maxtimer.Content = TimeSpan.FromSeconds(Math.Round(myMediaElement.NaturalDuration.TimeSpan.TotalSeconds));
                //MessageBox.Show(maxtimer.Content.ToString(), TimeSpan.FromSeconds(Math.Round(myMediaElement.NaturalDuration.TimeSpan.TotalSeconds)).ToString());
            }
            catch(Exception d)
            {

            }
        }

        private void Element_MediaEnded(object sender, EventArgs e)
        {
            aTimer.Stop();
            myMediaElement.Stop();
        }

        private void SeekToMediaPosition(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            int SliderValue = (int)timelineSlider.Value;
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, SliderValue);
            myMediaElement.Position = ts;
        }

        void InitializePropertyValues()
        {
            myMediaElement.Volume = (double)volumeSlider.Value;
            myMediaElement.SpeedRatio = (double)speedRatioSlider.Value;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            player.Open(new Uri("f.mp3", UriKind.Relative));
            player.Play();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofl = new OpenFileDialog();
            listbox1.Items.Clear();
            ofl.Title = "Выберете один или несколько файлов";
            ofl.Multiselect = true;
            ofl.Filter = "Видео или музыка | .mp4, .mp3, .avi, ,wav, .flac";
            ofl.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            ofl.Filter = "Видео (*.avi, *.mp4, *.wmv)|*.avi; *.mp4; *.wmv|Аудио (*.mp3 *.flac *.wav)|*.mp3; *.flac; *.wav";
            
            ofl.ShowDialog();
            
            int d = ofl.SafeFileNames.Length;

            urisMas = new Uri[ofl.FileNames.Length];

            for (int i = 0; i < ofl.FileNames.Length; i++)
            {
                urisMas[i] = new Uri(ofl.FileNames[i]);
                words = ofl.FileNames[i].Split(new char[] {'\\' }, StringSplitOptions.RemoveEmptyEntries);
                listbox1.Items.Add(words.Last());
                
               
            }


            if (urisMas[0] != null)myMediaElement.Source = urisMas[0];
            OnMouseDownPlayMedia(urisMas[0],null);
            
        }

        private void listbox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (listbox1.SelectedItem != null)
            {
                index = listbox1.SelectedIndex;
            }
  

            OnMouseDownPlayMedia(urisMas[index], null);



        }
    }
}
