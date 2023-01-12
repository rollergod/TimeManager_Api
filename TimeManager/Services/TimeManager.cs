using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using TimeManager_Api.Services.Interfaces;

namespace TimeManager_Api.Services
{
    public class TimeManager : ITimeManager
    {
        private DateTime _currentDate = DateTime.Now; 
        private string _currentTimeZone = "UTC";
        private string[] _patterns = new string[3]
        {
            "dd.MM.yyyy HH:mm:ss zzz",
            "dd.MM.yyyy HH:mm:ss",
            "dd/MM/yyyy HH-mm-ss"
        };

        public string GetDate()
        {
            return _currentTimeZone == "UTC" ?
                _currentDate.ToUniversalTime().ToString("dd.MM.yyyy HH:mm:ss zzz") :
                _currentDate.ToString("dd.MM.yyyy HH:mm:ss zzz");
        }

        public bool SetTimeZone(string timeZone)
        {
            TimeZoneInfo timeZoneInfo = GetTimeZone(timeZone);

            if (timeZoneInfo != null || IsTimeZoneExist(timeZoneInfo))
            {
                _currentTimeZone = timeZone;
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool IsTimeZoneExist(TimeZoneInfo timeZone)
        {
            return TimeZoneInfo.GetSystemTimeZones().Contains(timeZone);
        }

        public string ConvertDate(string date)
        {
            foreach (var pattern in _patterns)
            {
                if (MatchStringPatternToDateTime(date, pattern, out _currentDate))
                {
                    _currentDate = TimeZoneInfo.ConvertTime(_currentDate, TimeZoneInfo.FindSystemTimeZoneById(_currentTimeZone));
                    return _currentDate.ToString("dd.MM.yyyy HH:mm:ss zzz");
                }
            }
            return string.Empty;
        }

        private static bool MatchStringPatternToDateTime(string date,string pattern, out DateTime _currentDate)
        {
            return DateTime.TryParseExact(date, pattern, CultureInfo.InvariantCulture,
                                                       DateTimeStyles.None,
                                                       out _currentDate);
        }

        private TimeZoneInfo GetTimeZone(string timeZone)
        {
            try
            {
                var existingTimeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZone);
                return existingTimeZone;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка в {nameof(GetTimeZone)} / ${ex.Message}");
            }
            return null;
        }
    }
}