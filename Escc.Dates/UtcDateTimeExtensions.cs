using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Escc.Dates
{
    /// <summary>
    /// Extension methods for formatting dates in common international formats
    /// </summary>
    public static class UtcDateTimeExtensions
    {
        /// <summary>
        /// Get a string in the format YYYY-MM-DD from a DateTime object
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToIso8601Date(this DateTime date)
        {
            return date.ToUniversalTime().ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Gets a date and time as an ISO 8601 UTC date and time string
        /// </summary>
        /// <param name="date">Date and time to convert</param>
        /// <returns>ISO 8601 UTC date and time string. <example>2006-04-01T15:30:00Z</example></returns>
        /// <remarks>Suitable for hCalendar microformat.</remarks>
        public static string Iso8601DateTime(DateTime date)
        {
            return date.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Gets a date and time in RFC 822 format, as used by RSS feeds.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>UTC date and time in RFC 822 format</returns>
        /// <remarks>
        /// <para>Syntax specified at <a href="http://asg.web.cmu.edu/rfc/rfc822.html#sec-5.1">http://asg.web.cmu.edu/rfc/rfc822.html#sec-5.1</a></para>
        /// </remarks>
        /// <example>
        /// date-time   =  [ day "," ] date time        ; dd mm yy
        ///                                             ;  hh:mm:ss zzz
        ///
        /// day         =  "Mon"  / "Tue" /  "Wed"  / "Thu"
        ///             /  "Fri"  / "Sat" /  "Sun"
        ///
        /// date        =  1*2DIGIT month 2DIGIT        ; day month year
        ///                                             ;  e.g. 20 Jun 82
        ///
        /// month       =  "Jan"  /  "Feb" /  "Mar"  /  "Apr"
        ///             /  "May"  /  "Jun" /  "Jul"  /  "Aug"
        ///             /  "Sep"  /  "Oct" /  "Nov"  /  "Dec"
        ///
        /// time        =  hour zone                    ; ANSI and Military
        ///
        /// hour        =  2DIGIT ":" 2DIGIT [":" 2DIGIT]
        ///                                             ; 00:00:00 - 23:59:59
        ///
        /// zone        =  "UT"  / "GMT"                ; Universal ToBritishTime
        ///                                             ; North American : UT
        ///             /  "EST" / "EDT"                ;  Eastern:  - 5/ - 4
        ///             /  "CST" / "CDT"                ;  Central:  - 6/ - 5
        ///             /  "MST" / "MDT"                ;  Mountain: - 7/ - 6
        ///             /  "PST" / "PDT"                ;  Pacific:  - 8/ - 7
        ///             /  1ALPHA                       ; Military: Z = UT;
        ///                                             ;  A:-1; (J not used)
        ///                                             ;  M:-12; N:+1; Y:+12
        ///             / ( ("+" / "-") 4DIGIT )        ; Local differential
        ///                                             ;  hours+min. (HHMM)
        /// </example>
        public static string ToRfc822DateTime(this DateTime date)
        {
            // Using four-digit year even though spec above says use two-digit. 
            // Four-digit appears to be in common use so should be OK. 
            return date.ToUniversalTime().ToString("ddd, dd MMM yyyy HH:mm:ss UT");
        }

        /// <summary>
        /// Gets and date and time as a UNIX timestamp
        /// </summary>
        /// <param name="date">Date and time to convert</param>
        /// <returns>UNIX timestamp, eg 1115337662 </returns>
        /// <remarks>See <a href="http://www.unixtimestamp.com/">UNIXtimestamp.com</a> for a testing tool</remarks>
        public static int ToUnixTimestamp(this DateTime date)
        {
            const long ticks1970 = 621355968000000000; // .NET ticks for 1970
            return (int)((date.ToUniversalTime().Ticks - ticks1970) / 10000000L);
        }
    }
}
