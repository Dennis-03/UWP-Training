using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservableTest.Model
{
    internal class User : INotifyPropertyChanged
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        private string occupation;
        public string Occupation
        {
            get
            {
                return occupation;
            }
            set
            {
                occupation = value;
                OnPropertyChange("Occupation");
            }
        }
        public User(string firstName,string lastName,string occupation) 
        {
            FirstName = firstName;
            LastName = lastName;
            Occupation = occupation;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChange(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }

}
