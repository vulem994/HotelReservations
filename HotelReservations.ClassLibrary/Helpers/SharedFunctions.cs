using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservations.ClassLibrary.Helpers
{
    public class SharedFunctions
    {
        const int maximumDaysNumber = 365;

        #region CheckIfGivenDaysAreCorrect function
        public static bool CheckIfGivenDaysAreCorrect((int, int) inStartEndIntervalDays)
        {
            if (inStartEndIntervalDays.Item1 >= 0 && inStartEndIntervalDays.Item1 <= maximumDaysNumber
                && inStartEndIntervalDays.Item2 >= 0 && inStartEndIntervalDays.Item2 <= maximumDaysNumber
                && inStartEndIntervalDays.Item2 >= inStartEndIntervalDays.Item1)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region CheckIfIntervalDaysOverlap function
        public static bool CheckIfIntervalDaysOverlap((int, int) inGivenIntervalDays, (int, int) inReservationIntervalDays)
        {
            if (inGivenIntervalDays.Item2 < inReservationIntervalDays.Item1 ||
                inGivenIntervalDays.Item1 > inReservationIntervalDays.Item2)
                return false;
            return true;
        } 
        #endregion


    }//[Class]
}//[Namespace]
