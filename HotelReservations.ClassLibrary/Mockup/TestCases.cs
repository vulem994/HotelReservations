using HotelReservations.ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservations.ClassLibrary.Mockup
{
    public class TestCases
    {
        #region Case 1a
        public static (int, List<Booking>) TestCase1a
        {
            get
            {
                return (1, TestCase1aBookings);
            }
        }
        private static List<Booking> TestCase1aBookings { get; } = new List<Booking>()
        {
           new Booking(1,-4,2)
        };
        #endregion

        #region Case 1b
        public static (int, List<Booking>) TestCase1b
        {
            get
            {
                return (1, TestCase1bBookings);
            }
        }
        private static List<Booking> TestCase1bBookings { get; } = new List<Booking>()
        {
           new Booking(1,200,400)
        };
        #endregion

        #region Case 2
        public static (int, List<Booking>) TestCase2
        {
            get
            {
                return (3, TestCase2Bookings);
            }
        }
        private static List<Booking> TestCase2Bookings { get; } = new List<Booking>()
        {
           new Booking(1,0,5),
           new Booking(2,7,13),
           new Booking(3,3,9),
           new Booking(4,5,7),
           new Booking(5,6,6),
           new Booking(6,0,4),
        };
        #endregion

        #region Case 3
        public static (int, List<Booking>) TestCase3
        {
            get
            {
                return (3, TestCase3Bookings);
            }
        }
        private static List<Booking> TestCase3Bookings { get; } = new List<Booking>()
        {
           new Booking(1,1,3),
           new Booking(2,2,5),
           new Booking(3,1,9),
           new Booking(4,0,15),
        };
        #endregion

        #region Case 4
        public static (int, List<Booking>) TestCase4
        {
            get
            {
                return (3, TestCase4Bookings);
            }
        }
        private static List<Booking> TestCase4Bookings { get; } = new List<Booking>()
        {
           new Booking(1,1,3),
           new Booking(2,0,15),
           new Booking(3,1,9),
           new Booking(4,2,5),
           new Booking(5,4,9),
        };
        #endregion

        #region Case 5
        public static (int, List<Booking>) TestCase5
        {
            get
            {
                return (2, TestCase5Bookings);
            }
        }
        private static List<Booking> TestCase5Bookings { get; } = new List<Booking>()
        {
           new Booking(1,1,3),
           new Booking(2,0,4),
           new Booking(3,2,3),
           new Booking(4,5,5),
           new Booking(5,4,10),
           new Booking(6,10,10),
           new Booking(7,6,7),
           new Booking(8,8,10),
           new Booking(9,8,9),
        };
        #endregion

    }
}
