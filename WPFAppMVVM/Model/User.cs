using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace WPFAppMVVM.Model
{
    public class User : INotifyPropertyChanged
    {
        private int userId;
        private string firstName;
        private string lastName;
        private string city;
        private string state;
        private string country;

        public int UserId
        {
            get
            {
                return userId;
            }
            set
            {
                userId = value;
                OnPropertyChanged(nameof(UserId));
            }
        }
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }
        public string City
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
                OnPropertyChanged(nameof(City));
            }
        }
        public string State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
                OnPropertyChanged(nameof(State));
            }
        }
        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                country = value;
                OnPropertyChanged(nameof(Country));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
