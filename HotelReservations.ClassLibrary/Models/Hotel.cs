using HotelReservations.ClassLibrary.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Linq;

namespace HotelReservations.ClassLibrary.Models
{
    public class Hotel : INotifyPropertyChanged
    {
        #region -Rooms- property
        private List<Room> _Rooms;
        public List<Room> Rooms
        {
            get { return _Rooms; }
            set
            {
                if (_Rooms != value)
                {
                    _Rooms = value;
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion

        #region -HotelSize- property
        private int _HotelSize;
        public int HotelSize
        {
            get { return _HotelSize; }
            set
            {
                if (_HotelSize != value)
                {
                    _HotelSize = value;
                    NotifyPropertyChanged();
                }
            }
        }
        #endregion

        public Hotel(int inHotelSize)
        {
            HotelSize = inHotelSize;
            GenerateRooms();
        }
        //Initialize
        #region GenerateRooms function
        /// <summary>
        /// Generates a list of rooms based on the size of the hotel.
        /// </summary>
        private void GenerateRooms()
        {
            Rooms = new List<Room>();

            if (Rooms != null)
            {
                for (int i = 0; i < HotelSize; i++)
                {
                    var newRoom = new Room() { RoomNumber = i + 1 };
                    Rooms.Add(newRoom);
                }
            }
        }
        #endregion

        //Work with reservation functions
        #region BookHotelRoom function
        public bool BookHotelRoom(Booking inReservation)
        {
            Room freeRoom;
            if (SharedFunctions.CheckIfGivenDaysAreCorrect(inReservation.StartEndDaysInterval) &&
                GetBestRoomForGivenDayInterval(inReservation.StartEndDaysInterval, out freeRoom) &&
                freeRoom != null)
            {
                inReservation.isAccepted = true;
                freeRoom.AddReservation(inReservation);
                return true;
            }
            return false;
        }
        #endregion

        #region GetBestRoomForGivenDaysInterval function
        private bool GetBestRoomForGivenDayInterval((int, int) inGivenDaysInterval, out Room bestFreeRoomForReserve)
        {
            bestFreeRoomForReserve = null;
            if (Rooms != null && Rooms.Count > 0)
            {
                var freeRooms = Rooms.Where(o => o.CheckIfRoomFreeForGivenDayInterval(inGivenDaysInterval)).ToList();
                if (freeRooms != null && freeRooms.Count > 0)
                {
                    bestFreeRoomForReserve = freeRooms.First();
                    foreach (var room in freeRooms)
                    {
                        if (room.tmpMinimumDayDistance > 0 && room.tmpMinimumDayDistance < bestFreeRoomForReserve.tmpMinimumDayDistance  )
                        {
                            bestFreeRoomForReserve = room;
                        }
                    }
                    return true;
                }
            }
            return false;
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