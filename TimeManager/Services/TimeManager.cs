using System;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using TimeManager_Api.Services.Interfaces;

namespace TimeManager_Api.Services
{
    public class TimeManager : ITimeManager
    {
        private TimeZoneInfo _currentTimeZone = TimeZoneInfo.Utc;
        private string[] _patterns = new string[3]
        {
            "dd.MM.yyyy HH:mm:ss zzzz",
            "dd.MM.yyyy HH:mm:ss",
            "dd/MM/yyyy HH-mm-ss"
        };

        public string GetDate()
        {
            //return TimeZoneInfo.ConvertTime(DateTime.UtcNow, _currentTimeZone)
            //                    .ToString(_patterns[0]);

            return TimeZoneInfo.ConvertTime(DateTimeOffset.UtcNow, _currentTimeZone)
                                .ToString(_patterns[0]);
        }

        public bool SetTimeZone(string timeZone)
        {
            TimeZoneInfo timeZoneInfo = GetTimeZone(timeZone);

            if (timeZoneInfo == null)
                return false;

            _currentTimeZone = timeZoneInfo;
            return true;
        }

        public string ConvertDate(string date)
        {
            foreach (var pattern in _patterns)
            {
                if (MatchStringPatternToDateTime(date, pattern, out var _parsedDate))
                {
                    _parsedDate = TimeZoneInfo.ConvertTime(_parsedDate,
                                                            _currentTimeZone);

                    return _parsedDate.ToString(_patterns[0]);
                }
            }
            return string.Empty;
        }

        private static bool MatchStringPatternToDateTime(string date,string pattern, out DateTimeOffset dateToParse)
        {
            return DateTimeOffset.TryParseExact(
                date,
                pattern,
                CultureInfo.InvariantCulture,
                DateTimeStyles.AssumeUniversal,
                out dateToParse);
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