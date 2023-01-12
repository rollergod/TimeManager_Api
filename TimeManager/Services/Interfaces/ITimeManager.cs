namespace TimeManager_Api.Services.Interfaces
{
    public interface ITimeManager
    {
        string GetDate();
        bool SetTimeZone(string timeZone);
        string ConvertDate(string time);
    }
}