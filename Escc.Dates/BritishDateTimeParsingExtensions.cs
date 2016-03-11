using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Escc.Dates
{
    /// <summary>
    /// Extension methods for parsing date strings expressed in British English
    /// </summary>
    public static class BritishDateTimeParsingExtensions
    {
        private static readonly CultureInfo BritishCulture = new CultureInfo("en-GB");
   
        /// <summary>
        /// Parses the date, in way which is a little more forgiving than the default .NET implementation.
        /// </summary>
        /// <param name="date">The date text.</param>
        /// <returns>Parsed date, or <c>null</c> if not recognised</returns>
        public static DateTime? ParseBritishDateTime(this string date)
        {
            // Remove ordinals
            date = date.Trim();
            date = Regex.Replace(date, "\\b([0-9]+)(st|nd|rd|th)\\b", "$1");

            // Otherwise it must be a date recognised by .NET. But if there's only one space in the string,
            // assume user has put a date without a year, eg "29 may", and add the year on the end
            string space = " ";
            if (date.IndexOf(space, StringComparison.InvariantCulture) > -1 && date.IndexOf(space, StringComparison.InvariantCulture) == date.LastIndexOf(space, StringComparison.InvariantCulture))
            {
                date += (space + DateTime.Now.ToUkDateTime().Year);
            }

            DateTime parsedDate;
            if (DateTime.TryParse(date, BritishCulture, DateTimeStyles.None, out parsedDate))
            {
                return parsedDate;
            }
            else
            {
                return null;
            }
        }
    }
}
