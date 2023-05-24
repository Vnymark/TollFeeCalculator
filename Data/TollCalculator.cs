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
        /* If it's a toll free vehicle type - No fee should be payed */
        if (vehicle.IsTollFree()) return 0;

        DateTime intervalStart = dates[0];

        /* If it's a weekend - No fee should be payed */
        if (intervalStart.DayOfWeek.ToString() == "Saturday" || intervalStart.DayOfWeek.ToString() == "Sunday") return 0;

        SwedishHoliday Calendar = new SwedishHoliday();

        /* If today or tomorrow is a holiday - No fee should be payed. */
        if (Calendar.IsHoliday(intervalStart) || Calendar.IsHoliday(intervalStart.AddDays(1))) return 0;
        
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
}