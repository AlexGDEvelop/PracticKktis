using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WebBrowser
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Create a stringBuilder

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            /*WindowStyle = WindowStyle.None;
            ResizeMode = ResizeMode.NoResize;
            Left = 0;
            Top = 0;
            Width = SystemParameters.VirtualScreenWidth;
            Height = SystemParameters.VirtualScreenHeight;
            Topmost = true;*/
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            // do your stuff
            if (AddTabButton.IsSelected)
            {


                // Create a stringBuilder
                StringBuilder sb = new StringBuilder();

                // use xaml to declare a button as string containing xaml
                /* sb.Append(@"<Button xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation' 
                             xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml' ");
                 sb.Append(@"Content='Click Me!' />");*/

                // Create a button using a XamlReader


                // Add created button to previously created container.




                /*<StackPanel>
                        <TextBlock Margin=' 0' Height='13'><Run Text='Страница'/><InlineUIContainer>
                
                                < Button HorizontalContentAlignment = 'Left'  Style = '{DynamicResource DefaultButtonStyle}' Width = '15' Height = '15' VerticalContentAlignment = 'Top' Padding ='0' Margin = '15,0,0,0' RenderTransformOrigin = '1.9,0.6' BorderBrush = '{x:Null}' Foreground = '{x:Null}' >
                                    < Button.Background >
                                        < ImageBrush ImageSource = 'imgonline-com-ua-Transparent-backgr-SoPSEMoFeUkzKk.png' Stretch = 'Uniform' />
                                    </ Button.Background >
                                </ Button >
                            </ InlineUIContainer ></ TextBlock >
                    </ StackPanel >");
                
                tc_main.Items.Add(myButton);

                tc_main.Items.Add(new TabItem { 
                       //HeaderTemplate = sb*/
                sb.Append(@"<TextBlock Margin='0' Height='13'><Run Text='Главная'/><InlineUIContainer>
                                <Button HorizontalContentAlignment='Left'  Style='{DynamicResource DefaultButtonStyle}' Width='15' Height='15' VerticalContentAlignment='Top' Padding='0' Margin='15,0,0,0'  BorderBrush='{x:Null}' Foreground='{x:Null}'>
                                    <Button.Background>
                                        <ImageBrush ImageSource='imgonline-com-ua-Transparent-backgr-SoPSEMoFeUkzKk.png' Stretch='Uniform'/>
                                    </Button.Background>
                                </Button>
                            </InlineUIContainer></TextBlock>");




                TextBlock tb = new TextBlock();
                tb.Inlines.Add(new Button
                {
                    HorizontalContentAlignment = HorizontalAlignment.Left,
                    Width = 15,
                    Height = 15,
                    VerticalContentAlignment = VerticalAlignment.Top,
                    Margin = new Thickness(15, 0, 0, 0),
                    BorderBrush= null,
                    Foreground = null



                }) ;

                tb.Text = "СТраница";

                StackPanel stack = new StackPanel();
                test it = new test();
                stack.Children.Add(tb);

                TabItem d = new TabItem() { 
                    Header =  stack,
                    Content = it };
                
                tc_main.Items.Insert(tc_main.Items.Count - 1,it);
                tc_main.Items.Contains(tc_main.Items.Count);
                tc_main.Items.GetItemAt(tc_main.Items.Count - 1);
                
                /*List<string> MyList = new List<string>();
                
                string newItem = "Item " + (MyList.Count + 1);
                MyList.Add(newItem);
                e.Handled = true;
                Dispatcher.BeginInvoke(new Action(() => tc_main.SelectedItem = newItem));*/
                // Create a button using a XamlReader


                // Add created button to previously created container.

            }
            // do your stuff
        }
    }
}
