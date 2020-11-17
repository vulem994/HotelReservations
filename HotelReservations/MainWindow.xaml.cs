using HotelReservations.ClassLibrary.Mockup;
using HotelReservations.ClassLibrary.Models;
using HotelReservations.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace HotelReservations
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        #region -CurrentHotel- property
        private Hotel _CurrentHotel;
        public Hotel CurrentHotel
        {
            get { return _CurrentHotel; }
            set
            {
                if (_CurrentHotel != value)
                {
                    _CurrentHotel = value;
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion

        #region -tmpAllBookings- property
        private List<Booking> _tmpAllBookings;
        public List<Booking> tmpAllBookings
        {
            get { return _tmpAllBookings; }
            set
            {
                if (_tmpAllBookings != value)
                {
                    _tmpAllBookings = value;
                    BookAllBookings();
                    NotifyPropertyChanged();
                    dataGrid_AllBookings.ItemsSource = null;
                    dataGrid_AllBookings.ItemsSource = tmpAllBookings;
                }
            }
        }
        #endregion

        //helper props
        #region nextBookNumber
        private int nextBookNumber
        {
            get
            {
                if (tmpAllBookings != null)
                {
                    return tmpAllBookings.Count + 1;
                }
                return 0;
            }
        }
        #endregion

        public MainWindow()
        {
            this.DataContext = this;
            InitializeComponent();
            InitializeForm();
        }
        //Initialize
        #region InitializeForm function
        private void InitializeForm()
        {
            tmpAllBookings = new List<Booking>();
        }
        #endregion

        //Work with booking functions
        #region BookRoomToCurrentHotel function
        private void BookRoomToCurrentHotel(Booking inReservation)
        {
            if (CurrentHotel != null)
            {
                CurrentHotel.BookHotelRoom(inReservation);
            }
        }
        #endregion

        #region BookAllBookings function
        /// <summary>
        /// Function calls after change tmpAllBookings list
        /// </summary>
        private void BookAllBookings()
        {
            if (tmpAllBookings != null && tmpAllBookings.Count > 0 && CurrentHotel != null)
            {
                foreach (var reservation in tmpAllBookings)
                {
                    BookRoomToCurrentHotel(reservation);
                }
            }
        }
        #endregion


        //Events
        #region Buttons events
        private void CaseButtons_Click(object sender, RoutedEventArgs e) //Test cases buttons click event
        {
            var typedSender = sender as Button;
            if (typedSender != null)
            {
                (int, List<Booking>) TestCase = (0, null);
                switch (typedSender.Tag)
                {
                    case "case1a":
                        TestCase = TestCases.TestCase1a;
                        break;
                    case "case1b":
                        TestCase = TestCases.TestCase1b;
                        break;
                    case "case2":
                        TestCase = TestCases.TestCase2;
                        break;
                    case "case3":
                        TestCase = TestCases.TestCase3;
                        break;
                    case "case4":
                        TestCase = TestCases.TestCase4;
                        break;
                    case "case5":
                        TestCase = TestCases.TestCase5;
                        break;
                    default:
                        return;

                }
                if (TestCase.Item2 != null)
                {
                    CurrentHotel = new Hotel(TestCase.Item1);
                    tmpAllBookings = TestCase.Item2;
                }
            }
        }

        private void button_newBooking_Click(object sender, RoutedEventArgs e) //New Booking button click event
        {
            NewBooking_Form bookForm = new NewBooking_Form();
            var result = bookForm.ShowDialog();
            if (result.HasValue && result.Value == true && bookForm.booking != null)
            {
                bookForm.booking.BookNumber = nextBookNumber;
                tmpAllBookings.Add(bookForm.booking);
                BookRoomToCurrentHotel(bookForm.booking);
                dataGrid_AllBookings.ItemsSource = null;
                dataGrid_AllBookings.ItemsSource = tmpAllBookings;
            }
        }
        #endregion

        //Propery change event implementation
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
