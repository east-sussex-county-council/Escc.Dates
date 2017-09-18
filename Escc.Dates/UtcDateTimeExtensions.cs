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
        /// <returns>Date in IS8601 format</returns>
        public static string ToIso8601Date(this DateTime date)
        {
            // Do not adjust to UTC because that's liable to change the date due to daylight saving or different time zones, 
            // but we're throwing away the timezone information that allows it to be converted back again
            return date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Get a string in the format YYYY-MM-DD from a DateTime object
        /// </summary>
        /// <param name="date"></param>
        /// <returns>Date in IS8601 format, or an empty string</returns>
        public static string ToIso8601Date(this DateTime? date)
        {
            if (date.HasValue) return date.Value.ToIso8601Date();
            return String.Empty;
        }
        
        /// <summary>
        /// Gets a date and time as an ISO 8601 UTC date and time string
        /// </summary>
        /// <param name="date">Date and time to convert</param>
        /// <returns>ISO 8601 UTC date and time string. <example>2006-04-01T15:30:00Z</example></returns>
        /// <remarks>Suitable for hCalendar microformat.</remarks>
        public static string ToIso8601DateTime(this DateTime date)
        {
            return date.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Gets a date and time as an ISO 8601 UTC date and time string
        /// </summary>
        /// <param name="date">Date and time to convert</param>
        /// <returns>ISO 8601 UTC date and time string, or an empty string. <example>2006-04-01T15:30:00Z</example></returns>
        /// <remarks>Suitable for hCalendar microformat.</remarks>
        public static string ToIso8601DateTime(this DateTime? date)
        {
            if (date.HasValue) return date.Value.ToIso8601DateTime();
            return String.Empty;
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
        /// Gets a date and time in RFC 822 format, as used by RSS feeds.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>UTC date and time in RFC 822 format, or an empty string</returns>
        public static string ToRfc822DateTime(this DateTime? date)
        {
            if (date.HasValue) return date.Value.ToRfc822DateTime();
            return String.Empty;
        }

        /// <summary>
        /// Returns a date and time in RFC 850 format, as used by the 'unavailable_after' value of the robots meta tag understood by Google.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>UTC date and time in RFC 850 format</returns>
        /// <remarks>
        /// <para>Syntax specified at <a href="https://tools.ietf.org/html/rfc850">https://tools.ietf.org/html/rfc850</a></para>
        /// </remarks>
        /// <example>
        /// 2.1.4  Date  The Date line (formerly   "Posted")   is  the
        /// date,  in  a format  that must be acceptable both to the
        /// ARPANET and to the getdate routine, that the  article was
        /// originally posted  to the  network.This date remains
        /// unchanged as the article  is  propagated throughout  the
        /// network.One format that is acceptable to both is
        ///
        ///   Weekday, DD-Mon-YY HH:MM:SS TIMEZONE
        ///
        /// Several examples of valid  dates appear  in  the sample
        /// article above.  Note in particular that ctime format:
        ///
        ///   Wdy Mon DD HH:MM:SS YYYY
        ///
        /// is not acceptable because it is not a valid ARPANET  date.
        /// However, since older software still generates this format,
        /// news implementations are encouraged to accept this format
        /// and translate it into an acceptable format.
        ///
        /// The contents of the TIMEZONE field is currently subject to
        /// worldwide time zone  abbreviations, including the  usual
        /// American  zones  (PST, PDT, MST, MDT, CST, CDT, EST, EDT),
        /// the other   North American   zones(Bering through
        /// Newfoundland),  European zones, Australian zones, and so
        /// on.Lacking a complete list at present(and unsure if  an
        /// unambiguous   list exists),   authors of  software are
        /// encouraged to keep this code flexible, and  in  particular
        /// not  to assume  that time  zone names are exactly three
        /// letters long.   Implementations are  free to  edit  this
        /// field, keeping the  time the same, but changing the time
        /// zone (with an appropriate adjustment  to the  local time
        /// shown) to a known time zone.
        /// </example>
        public static string ToRfc850DateTime(this DateTime date)
        {
            return date.ToUniversalTime().ToString("dddd, dd-MMM-yy HH:mm:ss UTC");
        }

        /// <summary>
        /// Returns a date and time in RFC 850 format, as used by the 'unavailable_after' value of the robots meta tag understood by Google.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>UTC date and time in RFC 850 format</returns>
        public static string ToRfc850DateTime(this DateTime? date)
        {
            if (date.HasValue) return date.Value.ToRfc850DateTime();
            return String.Empty;
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
