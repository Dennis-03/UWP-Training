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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace StupendousChallenge
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Coffee : Page
    {

        string _roast,_cream,_sweet;
        public Coffee()
        {
            this.InitializeComponent();
        }

        private void Roast_Click(object sender, RoutedEventArgs e)
        {
            var selected = (MenuFlyoutItem)sender;
            _roast = selected.Text;
            Display_coffee();
        }

        private void Cream_Click(object sender, RoutedEventArgs e)
        {
            var selected = (MenuFlyoutItem)sender;
            _cream = selected.Text;
            Display_coffee();
        }

        private void Sweetner_Click(object sender, RoutedEventArgs e)
        {
            var selected = (MenuFlyoutItem)sender;
            _sweet = selected.Text;
            Display_coffee();
        }
        private void Display_coffee()
        {
            if(_roast == "None" || String.IsNullOrEmpty(_roast  ))
            {
                Coffee_type.Text = "None";
                return;
            }

            Coffee_type.Text = _roast;
            
            if (_sweet != "None" || String.IsNullOrEmpty(_sweet))
            {
                Coffee_type.Text += " + " + _sweet;
            }
            if (_cream != "None" || String.IsNullOrEmpty(_cream))
            {
                Coffee_type.Text += " + " + _cream;
            }
        }
    }
}
