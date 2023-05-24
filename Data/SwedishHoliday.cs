using Google.Apis.Calendar.v3;
using Google.Apis.Services;

public class SwedishHoliday {

    /* Would normally be stored in secret */
    const string CalendarId = "sv.swedish.official#holiday@group.v.calendar.google.com";
    const string ApiKey = "AIzaSyAVJ9F2THkFwKLw5NpQX_v8dkg7aMOd40U";

    public List<Google.Apis.Calendar.v3.Data.Event>? Holidays { get; set;}

    public SwedishHoliday() {
        FetchHolidays().Wait();
    }

    private async Task FetchHolidays() {
        var Service = new CalendarService(new BaseClientService.Initializer()
        {   
            ApiKey = ApiKey,
            ApplicationName = "TollFeeCalculator"
        });
        var request = Service.Events.List(CalendarId);
        request.TimeMin = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0);
        request.TimeMax = new DateTime(DateTime.Now.Year, 12, 31, 23, 59, 59);
        request.Fields = "items(summary, start)";
        try {
            var response = await request.ExecuteAsync();
            Holidays = (List<Google.Apis.Calendar.v3.Data.Event>)response.Items;
        } catch {
            Holidays = null;
        }
    }

    public Boolean IsHoliday(DateTime date) {
        if (Holidays != null && Holidays.Exists(x => x.Start.Date == date.Date.ToString("yyyy-MM-dd"))) return true;
        return false;
    }
}