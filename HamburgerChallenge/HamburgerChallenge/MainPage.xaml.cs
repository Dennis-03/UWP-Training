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

namespace HamburgerChallenge
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            MyFrame.Navigate(typeof(BlankPage1));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Hamburger_Click(object sender, RoutedEventArgs e)
        {
            MyNavigation.IsPaneOpen = !MyNavigation.IsPaneOpen;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Food.IsSelected)
            {
                MyFrame.Navigate(typeof(Food));
                Title.Text = "Food";
                BackButton.Visibility = Visibility.Visible;
            }
            else if (Financial.IsSelected)
            {
                MyFrame.Navigate(typeof(BlankPage1));
                Title.Text = "Financial";
                BackButton.Visibility = Visibility.Collapsed;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (MyFrame.CanGoBack)
            {
                MyFrame.GoBack();
                Financial.IsSelected = true;
            }
        }
    }
}
