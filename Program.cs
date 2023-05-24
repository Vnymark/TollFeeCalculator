using TollFeeCalculator;

/* Test data */
Vehicle vehicle = new Vehicle("Car");
DateTime[] datetimes = new DateTime[5]{
    new DateTime(2023, 5, 17, 07, 10, 00),
    new DateTime(2023, 5, 17, 06, 40, 00),
    new DateTime(2023, 5, 17, 09, 15, 00),
    new DateTime(2023, 5, 17, 10, 05, 00),
    new DateTime(2023, 5, 17, 16, 15, 00)
};

/* Calculates the toll fees for the vehicle */
TollCalculator tollCalculator = new TollCalculator();
string description = "Tollfee for a {0} on {1}:";
string result = "{0}kr";
Console.WriteLine(string.Format(description, vehicle.Type, datetimes[0].ToShortDateString()));
Console.WriteLine(string.Format(result, tollCalculator.GetTotalTollFee(vehicle, datetimes)));

