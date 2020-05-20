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

namespace MPlayer
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MediaPlayer player = new MediaPlayer();
        Stream[] plaMas;
        Uri[] urisMas;
        Timer aTimer = new Timer();
        public MainWindow()
        {
            InitializeComponent();

            // Create a timer with a two second interval.
            aTimer = new System.Timers.Timer(2000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;

            myMediaElement.MediaOpened += Element_MediaOpened;
            myMediaElement.MediaEnded += Element_MediaEnded;
            // Play the video once.
            //player.Play();
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            timelineSlider.Value = myMediaElement.Position.TotalMilliseconds;


        }

        // Play the media.
        void OnMouseDownPlayMedia(object sender, MouseButtonEventArgs args)
        {

            // The Play method will begin the media if it is not currently active or
            // resume media if it is paused. This has no effect if the media is
            // already running.
            myMediaElement.Play();
            aTimer.Stop();
            //myMediaElement.Position.TotalMilliseconds
            // Initialize the MediaElement property values.
            InitializePropertyValues();
        }

        // Pause the media.
        void OnMouseDownPauseMedia(object sender, MouseButtonEventArgs args)
        {

            // The Pause method pauses the media if it is currently running.
            // The Play method can be used to resume.
            myMediaElement.Pause();
        }

        // Stop the media.
        void OnMouseDownStopMedia(object sender, MouseButtonEventArgs args)
        {

            // The Stop method stops and resets the media to be played from
            // the beginning.
            myMediaElement.Stop();
            aTimer.Stop();
        }

        // Change the volume of the media.
        private void ChangeMediaVolume(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            myMediaElement.Volume = (double)volumeSlider.Value;
        }

        // Change the speed of the media.
        private void ChangeMediaSpeedRatio(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            myMediaElement.SpeedRatio = (double)speedRatioSlider.Value;
        }

        // When the media opens, initialize the "Seek To" slider maximum value
        // to the total number of miliseconds in the length of the media clip.
        private void Element_MediaOpened(object sender, EventArgs e)
        {
            try
            {
                timelineSlider.Maximum = myMediaElement.NaturalDuration.TimeSpan.TotalMilliseconds;
            }
            catch(Exception d)
            {

               // MessageBox.Show(d.ToString());
            }
        }

        // When the media playback is finished. Stop() the media to seek to media start.
        private void Element_MediaEnded(object sender, EventArgs e)
        {
            myMediaElement.Stop();
        }

        // Jump to different parts of the media (seek to).
        private void SeekToMediaPosition(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            int SliderValue = (int)timelineSlider.Value;

            // Overloaded constructor takes the arguments days, hours, minutes, seconds, milliseconds.
            // Create a TimeSpan with miliseconds equal to the slider value.
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, SliderValue);
            myMediaElement.Position = ts;
        }

        void InitializePropertyValues()
        {
            // Set the media's starting Volume and SpeedRatio to the current value of the
            // their respective slider controls.
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
            ofl.Title = "Выберете один или несколько файлов";
            ofl.Multiselect = true;
            ofl.Filter = "Видео или музыка | .mp4, .mp3, .avi, ,wav, .flac";
            ofl.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            ofl.Filter = "Видео (*.avi, *.mp4, *.wmv)|*.avi; *.mp4; *.wmv|Аудио (*.mp3 *.flac *.wav)|*.mp3; *.flac; *.wav";
            ofl.ShowDialog();
            
            int d = ofl.SafeFileNames.Length;

            urisMas = new Uri[ofl.FileNames.Length];
            //urisMas[] = new Uri(ofl.FileNames)

            for (int i = 0; i < ofl.FileNames.Length; i++)
            {
                urisMas[i] = new Uri(ofl.FileNames[i]);
                MessageBox.Show(urisMas[i].ToString(),ofl.FileNames[i].ToString());
                
            }

            if(urisMas!=null)myMediaElement.Source = urisMas[0];
            //myMediaElement.Play();
            OnMouseDownPlayMedia(sender,new MouseButtonEventArgs(null,0,MouseButton.Left));
            //MessageBox.Show(plaMas.ToString());
            
        }
    }
}
