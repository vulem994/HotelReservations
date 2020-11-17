using HotelReservations.ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HotelReservations.Forms
{
    /// <summary>
    /// Interaction logic for NewBooking_Form.xaml
    /// </summary>
    public partial class NewBooking_Form : Window, INotifyPropertyChanged
    {
        #region -tmpStartDay- property
        private int _tmpStartDay;
        public int tmpStartDay
        {
            get { return _tmpStartDay; }
            set
            {
                if (_tmpStartDay != value)
                {
                    _tmpStartDay = value;
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion

        #region -tmpEndDay- property
        private int _tmpEndDay;
        public int tmpEndDay
        {
            get { return _tmpEndDay; }
            set
            {
                if (_tmpEndDay != value)
                {
                    _tmpEndDay = value;
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion

        public Booking booking;

        public NewBooking_Form()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        #region Buttons events
        private void button_add_Click(object sender, RoutedEventArgs e)
        {
            booking = new Booking() { StartEndDaysInterval = (tmpStartDay, tmpEndDay) };
            this.DialogResult = true;
            this.Close();
        }

        private void button_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
        #endregion


        #region INotifyPropertyChange implementation
        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }//[Class]
}//[Namespace]
