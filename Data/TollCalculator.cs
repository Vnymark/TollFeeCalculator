using System;
using System.Globalization;
using TollFeeCalculator;

public class TollCalculator
{

    /**
     * Calculate the total toll fee for one day
     *
     * @param vehicle - the vehicle
     * @param dates   - date and time of all passes on one day
     * @return - the total toll fee for that day
     */

    public int GetTotalTollFee(Vehicle vehicle, DateTime[] dates)
    {
       if (vehicle.IsTollFree() || IsTollFreeDate(dates[0])) return 0;
        
        DateTime intervalStart = dates[0];
        TollFee fee = new TollFee(intervalStart);

        foreach (DateTime date in dates)
        {   
            if (fee.IsSameInterval(date))
            {
                fee.Add(date);
            }
            else
            {
                vehicle.TollFee += fee.HighestFee;
                fee = new TollFee(date);
            }
        }
        vehicle.TollFee += fee.HighestFee;
        return vehicle.GetTollFee();
    }

    private Boolean IsTollFreeDate(DateTime date)
    {
        int year = date.Year;
        int month = date.Month;
        int day = date.Day;

        if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) return true;

        if (year == 2023)
        {
            if (month == 1 && (day == 5 || day == 6) ||
                month == 4 && (day == 6 || day == 7 || day == 10) ||
                month == 5 && (day == 1 || day == 17 || day == 18) ||
                month == 6 && (day == 5 || day == 6 || day == 23) ||
                month == 7 ||
                month == 11 && day == 3 ||
                month == 12 && (day == 25 || day == 26))
            {
                return true;
            }
        }
        return false;
    }
}