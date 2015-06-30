using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WpfApplicationDummy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Thread th = new Thread(KeepUpdating);
            th.Start();   
        }

        private bool ShouldStop = false;
        private void KeepUpdating(object obj)
        {
            string path = @"D:\Result.txt";
            while(!ShouldStop)
            {
                try
                {
                    if (File.Exists(path))
                    {
                        App.Current.Dispatcher.BeginInvoke((Action)(() =>
                        {

                            TextReader rw = new StreamReader(path);
                            tbResult2.Text = rw.ReadLine();
                            rw.Close();
                        }));
                    }
                    Thread.Sleep(200);
                }
                catch (Exception)
                {
                }
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            ShouldStop = true;
        }
    }
}
