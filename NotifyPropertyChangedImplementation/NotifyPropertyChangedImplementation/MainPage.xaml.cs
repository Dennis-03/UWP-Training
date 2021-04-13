using ObservableTest.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace NotifyPropertyChangedImplementation
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<User> Users = new ObservableCollection<User>();
        public MainPage()
        {
            this.InitializeComponent();
            Users.Add(new User("Augustin", "Dennis", "Developer"));
            Users.Add(new User("Andrew", "Boniface", "Doctor"));
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Users.FirstOrDefault(i => i.FirstName == "Andrew").Occupation = "Doctorate";
        }
    }
}
