using HotelReservations.ClassLibrary.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace HotelReservations.ClassLibrary.Models
{
    public class Booking : INotifyPropertyChanged
    {
        #region -BookNumber- property
        private int _BookNumber;
        public int BookNumber
        {
            get { return _BookNumber; }
            set
            {
                if (_BookNumber != value)
                {
                    _BookNumber = value;
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion

        #region -StartEndDaysInterval- property
        private (int, int) _StartEndDaysInterval;
        public (int, int) StartEndDaysInterval
        {
            get { return _StartEndDaysInterval; }
            set
            {
                if (_StartEndDaysInterval != value)
                {
                    _StartEndDaysInterval = value;
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion

        //Helper propertiesw
        #region -isAccepted- property
        private bool _isAccepted = false; //default
        public bool isAccepted
        {
            get { return _isAccepted; }
            set
            {
                if (_isAccepted != value)
                {
                    _isAccepted = value;
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion

        #region -name- property
        public String name
        {
            get
            {
                return $"Booking {BookNumber}";
            }

        }
        #endregion

        #region -startDay- property
        public int startDay
        {
            get
            {
                return StartEndDaysInterval.Item1;
            }

        }
        #endregion

        #region -endDay- property
        public int endDay
        {
            get
            {
                return StartEndDaysInterval.Item2;
            }

        }
        #endregion

        public Booking()
        {

        }

        public Booking(int inBookNumber, int inStartDay, int inEndDay)
        {
            BookNumber = inBookNumber;
            StartEndDaysInterval = (inStartDay, inEndDay);
        }

        //Work with intervals functions
        #region CheckIfThisReservationHasDiferentTimeIntervalThanGiven function
        public bool CheckIfThisReservationHasDiferentDaysIntervalThanGiven((int, int) inGivenDaysInterval)
        {
            return !SharedFunctions.CheckIfIntervalDaysOverlap(inGivenDaysInterval, StartEndDaysInterval);
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
