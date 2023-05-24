namespace TollFeeCalculator
{
    public class TollFee
    {
        public int HighestFee {get; set;}
        public DateTime IntervalStart {get;}

        public TollFee(DateTime IntervalStart)
        {
            this.IntervalStart = IntervalStart;
            HighestFee = GetTollFee(IntervalStart);
        }

        /* Private functions */
        private int GetTollFee(DateTime date) {
            int hour = date.Hour;
            int minute = date.Minute;

            if (hour == 6 && minute >= 0 && minute <= 29) return 9;
            else if (hour == 6 && minute >= 30 && minute <= 59) return 16;
            else if (hour == 7 && minute >= 0 && minute <= 59) return 22;
            else if (hour == 8 && minute >= 0 && minute <= 29) return 16;
            else if (hour >= 8 && hour <= 14 && minute >= 30 && minute <= 59) return 9;
            else if (hour == 15 && minute >= 0 && minute <= 29) return 16;
            else if (hour == 15 && minute >= 0 || hour == 16 && minute <= 59) return 22;
            else if (hour == 17 && minute >= 0 && minute <= 59) return 16;
            else if (hour == 18 && minute >= 0 && minute <= 29) return 9;
            else return 0;
        }

        /* Public functions */
        public void Add(DateTime date) {
            int fee = GetTollFee(date);
            if (HighestFee < fee) HighestFee = fee;
        }

        public Boolean IsSameInterval(DateTime date) {
            double diffInMillies = (date - this.IntervalStart).TotalMilliseconds;
            double minutes = diffInMillies/1000/60;
            return (minutes <= 60);
        }
    }
}