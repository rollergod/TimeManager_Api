using System.Collections.ObjectModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using static System.Net.Mime.MediaTypeNames;

string currentTimeZone = "Asia/Yekaterinburg";
string test = "+00:00";
DateTime currentDate = DateTime.UtcNow.ToUniversalTime();


var utc = TimeZoneInfo.FindSystemTimeZoneById("UTC");

var value = TimeZoneInfo.FindSystemTimeZoneById(currentTimeZone);
Console.WriteLine(value.ToString());
currentDate = TimeZoneInfo.ConvertTime(currentDate, value);

Console.WriteLine(currentDate.ToString("dd.MM.yyyy HH.mm.ss zzz"));


//var olsonTimeZones = new List<string>()
//{
//        { "Africa/Bangui"},
//        { "Africa/Cairo"},
//        { "Africa/Casablanca"},
//        { "Africa/Harare"},
//        { "Africa/Johannesburg"},
//        { "Africa/Lagos"},
//        { "Africa/Monrovia"},
//        { "Africa/Nairobi"},
//        { "Africa/Windhoek"},
//        { "America/Anchorage"},
//        { "America/Argentina/San_Juan"},
//        { "America/Asuncion"},
//        { "America/Bahia"},
//        { "America/Bogota"},
//        { "America/Buenos_Aires"},
//        { "America/Caracas"},
//        { "America/Cayenne"},
//        { "America/Chicago"},
//        { "America/Chihuahua"},
//        { "America/Cuiaba"},
//        { "America/Denver"},
//        { "America/Fortaleza"},
//        { "America/Godthab"},
//        { "America/Guatemala"},
//        { "America/Halifax"},
//        { "America/Indianapolis"},
//        { "America/Indiana/Indianapolis"},
//        { "America/La_Paz"},
//        { "America/Los_Angeles"},
//        { "America/Mexico_City"},
//        { "America/Montevideo"},
//        { "America/New_York"},
//        { "America/Noronha"},
//        { "America/Phoenix" },
//        { "America/Regina"},
//        { "America/Santa_Isabel"},
//        { "America/Santiago" },
//        { "America/Sao_Paulo"},
//        { "America/St_Johns"},
//        { "America/Tijuana"},
//        { "Antarctica/McMurdo"},
//        { "Atlantic/South_Georgia"},
//        { "Asia/Almaty" },
//        { "Asia/Amman" },
//        { "Asia/Baghdad"},
//        { "Asia/Baku" },
//        { "Asia/Bangkok" },
//        { "Asia/Beirut" },
//        { "Asia/Calcutta"},
//        { "Asia/Colombo" },
//        { "Asia/Damascus" },
//        { "Asia/Dhaka" },
//        { "Asia/Dubai"},
//        { "Asia/Irkutsk"},
//        { "Asia/Jerusalem"},
//        { "Asia/Kabul"},
//        { "Asia/Kamchatka"},
//        { "Asia/Karachi"},
//        { "Asia/Katmandu"},
//        { "Asia/Kolkata"},
//        { "Asia/Krasnoyarsk"},
//        { "Asia/Kuala_Lumpur"},
//        { "Asia/Kuwait"},
//        { "Asia/Magadan"},
//        { "Asia/Muscat"},
//        { "Asia/Novosibirsk"},
//        { "Asia/Oral"},
//        { "Asia/Rangoon"},
//        { "Asia/Riyadh"},
//        { "Asia/Seoul"},
//        { "Asia/Shanghai"},
//        { "Asia/Singapore"},
//        { "Asia/Taipei"},
//        { "Asia/Tashkent"},
//        { "Asia/Tbilisi"},
//        { "Asia/Tehran"},
//        { "Asia/Tokyo"},
//        { "Asia/Ulaanbaatar"},
//        { "Asia/Vladivostok"},
//        { "Asia/Yakutsk"},
//        { "Asia/Yekaterinburg"},
//        { "Asia/Yerevan"},
//        { "Atlantic/Azores"},
//        { "Atlantic/Cape_Verde"},
//        { "Atlantic/Reykjavik"},
//        { "Australia/Adelaide"},
//        { "Australia/Brisbane"},
//        { "Australia/Darwin"},
//        { "Australia/Hobart"},
//        { "Australia/Perth"},
//        { "Australia/Sydney"},
//        { "Etc/GMT"},
//        { "Etc/GMT+11"},
//        { "Etc/GMT+12"},
//        { "Etc/GMT+2"},
//        { "Etc/GMT-12"},
//        { "Europe/Amsterdam"},
//        { "Europe/Athens"},
//        { "Europe/Belgrade" },
//        { "Europe/Berlin"},
//        { "Europe/Brussels"},
//        { "Europe/Budapest" },
//        { "Europe/Dublin"},
//        { "Europe/Helsinki" },
//        { "Europe/Istanbul" },
//        { "Europe/Kiev"},
//        { "Europe/London" },
//        { "Europe/Minsk" },
//        { "Europe/Moscow" },
//        { "Europe/Paris"},
//        { "Europe/Sarajevo"},
//        { "Europe/Warsaw" },
//        { "Indian/Mauritius" },
//        { "Pacific/Apia"},
//        { "Pacific/Auckland" },
//        { "Pacific/Fiji"},
//        { "Pacific/Guadalcanal" },
//        { "Pacific/Guam" },
//        { "Pacific/Honolulu"},
//        { "Pacific/Pago_Pago" },
//        { "Pacific/Port_Moresby" },
//        { "Pacific/Tongatapu" }
//};


//if (olsonTimeZones.Contains(currentTimeZone))
//{
//    var value = TimeZoneInfo.FindSystemTimeZoneById(currentTimeZone);
//    currentDate = TimeZoneInfo.ConvertTime(currentDate, value);

//    Console.WriteLine(currentDate.ToString("dd.MM.yyyy HH.mm.ss zzz"));
//}



string testDate = "12.01.2023 17:15:00";
string pattern = "dd.MM.yyyy HH:mm:ss";

string[] patterns = new string[3]
{
    "dd.MM.yyyy HH:mm:ss zzz",
    "dd.MM.yyyy HH:mm:ss",
    "dd/MM/yyyy HH-mm-ss"
};

foreach (var str in patterns)
{
    DateTime dt;
    if (DateTime.TryParseExact(testDate, str, CultureInfo.InvariantCulture,
                               DateTimeStyles.None,
                               out dt))
    {
        dt = TimeZoneInfo.ConvertTime(dt, TimeZoneInfo.FindSystemTimeZoneById(currentTimeZone));
    }
    else
    {
        Console.WriteLine("Bad");
    }
}

//DateTime dt;
//if (DateTime.TryParseExact(testDate, pattern, CultureInfo.InvariantCulture,
//                           DateTimeStyles.None,
//                           out dt))
//{
//    dt = TimeZoneInfo.ConvertTime(dt, TimeZoneInfo.FindSystemTimeZoneById(currentTimeZone));
//}
//else
//{
//    Console.WriteLine("Bad");
//}