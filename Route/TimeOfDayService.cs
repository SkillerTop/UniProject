interface ITimeOfDayService
{
    string GetTimeOfDay();
}

public class TimeOfDayService : ITimeOfDayService
{
    public string GetTimeOfDay()
    {
        DateTime currentTime = DateTime.Now;
        int hour = currentTime.Hour;

        string timeOfDay;

        switch (hour)
        {
            case int h when h >= 12 && h < 18:
                timeOfDay = "it's daytime";
                break;
            case int h when h >= 18 && h < 24:
                timeOfDay = "it is evening";
                break;
            case int h when h >= 0 && h < 6:
                timeOfDay = "it's night now";
                break;
            default:
                timeOfDay = "it's morning";
                break;
        }

        return timeOfDay;
    }
}
