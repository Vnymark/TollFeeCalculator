namespace TollFeeCalculator
{
    public class Vehicle
    {
        public string Type {get; set;}
        public int TollFee {get; set;}
        public Vehicle(string type)
        {
            Type = type;
            TollFee = 0;
        }
        
        /* Public functions */
        public Boolean IsTollFree() {
            return (Type == "Motorbike" ||
                    Type == "Emergency" ||
                    Type == "Tractor" ||
                    Type == "Diplomat" ||
                    Type == "Foreign" ||
                    Type == "Military");
        }
    }
}