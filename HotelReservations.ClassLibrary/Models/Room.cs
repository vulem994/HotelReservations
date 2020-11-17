using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Linq;

namespace HotelReservations.ClassLibrary.Models
{
    public class Room : INotifyPropertyChanged
    {
        #region -RoomNumber- property
        private int _RoomNumber;
        public int RoomNumber
        {
            get { return _RoomNumber; }
            set
            {
                if (_RoomNumber != value)
                {
                    _RoomNumber = value;
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion

        #region -Reservations- property
        private List<Booking> _Reservations;
        public List<Booking> Reservations
        {
            get { return _Reservations; }
            set
            {
                if (_Reservations != value)
                {
                    _Reservations = value;
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion

        //helper props
        #region -tmpMinimumDayDistance- property
        /// <summary>
        /// Temporary variable that shows the minimum distance from the nearest reservation for a given time. 
        /// </summary>
        public int tmpMinimumDayDistance;
        #endregion

        public Room()
        {
            InitializeClass();
        }

        //Initialize
        #region IntializeClass function
        private void InitializeClass()
        {
            if (Reservations == null)
            {
                Reservations = new List<Booking>();
            }
        }
        #endregion

        //Work with reservations functions
        #region AddReservation function
        public bool AddReservation(Booking inReservation)
        {
            if (Reservations != null && inReservation != null)
            {
                Reservations.Add(inReservation);
                return true;
            }
            return false;
        }
        #endregion

        #region CheckIfGivenDaysIntervalIsFreeForThisRoom function
        /// <summary>
        /// Function for checking if room is free for given days interval, and if so, than set minimum days distance to closest occupied reservation from list.
        /// </summary>
        /// <param name="inDaysInterval"></param>
        /// <returns> vuska</returns>
        public bool CheckIfRoomFreeForGivenDayInterval((int, int) inDaysInterval)
        {
            if (Reservations != null && Reservations.Count > 0)
            {

                var occupiedReservation = Reservations.FirstOrDefault(o => o.CheckIfThisReservationHasDiferentDaysIntervalThanGiven(inDaysInterval) == false);
                if (occupiedReservation != null)
                {
                    return false;
                }

                #region Setting minimum days distance to closest occupied reservation
                var reservationsBeforeNew = Reservations.Where(o => o.startDay - inDaysInterval.Item2 > 0).ToList();
                if (reservationsBeforeNew != null && reservationsBeforeNew.Count > 0)
                {
                    tmpMinimumDayDistance = reservationsBeforeNew.Min(o => o.startDay - inDaysInterval.Item2);
                }

                var reservationsAfterNew = Reservations.Where(o => inDaysInterval.Item1 - o.endDay > 0).ToList();
                if (reservationsAfterNew != null && reservationsAfterNew.Count > 0)
                {
                    int reservationsAfterMinDistance = reservationsAfterNew.Min(o => inDaysInterval.Item1 - o.endDay);
                    if (reservationsAfterMinDistance < tmpMinimumDayDistance || tmpMinimumDayDistance == 0)
                    {
                        tmpMinimumDayDistance = reservationsAfterMinDistance;
                    }
                } 
                #endregion

            }
            return true;
        }
        #endregion


        //Property change event implementation
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