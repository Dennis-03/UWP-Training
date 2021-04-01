using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace StupendousChallenge
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            MyFrame.Navigate(typeof(Donuts));
        }

        private void Donut_button_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(Donuts));
        }

        private void Coffee_button_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(Coffee));
        }

        private void Schedule_button_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(Schedule));
        }

        private void Complete_button_Click(object sender, RoutedEventArgs e)
        {
            MyFrame.Navigate(typeof(Complete));
        }
    }
}
