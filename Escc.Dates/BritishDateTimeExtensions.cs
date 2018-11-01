using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Escc.Dates
{
    /// <summary>
    /// Extension methods for formatting dates in British English, in line with the East Sussex County Council house style
    /// </summary>
    public static class BritishDateTimeExtensions
    {
        private static readonly CultureInfo UkCulture = new CultureInfo("en-GB");

        /// <summary>
        /// Gets the passed time as a UK time regardless of the current thread culture
        /// </summary>
        /// <returns></returns>
        /// <remarks>Important for applications hosted on Microsoft Azure where the time is in UTC and the culture is en-US.</remarks>
        public static DateTime ToUkDateTime(this DateTime dateTime)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(dateTime.ToUniversalTime(), TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time"));
        }

        /// <summary>
        /// Converts a integer month into a full English month name
        /// </summary>
        /// <param name="month">int month</param>
        /// <returns>January, February, March etc.</returns>
        public static string ToBritishMonthName(this int month)
        {
            switch (month)
            {
                case 1:
                    return "January";
                case 2:
                    return "February";
                case 3:
                    return "March";
                case 4:
                    return "April";
                case 5:
                    return "May";
                case 6:
                    return "June";
                case 7:
                    return "July";
                case 8:
                    return "August";
                case 9:
                    return "September";
                case 10:
                    return "October";
                case 11:
                    return "November";
                case 12:
                    return "December";
                default:
                    return String.Empty;
            }
        }

        /// <summary>
        /// Converts a integer month into an abbreviated English month name
        /// </summary>
        /// <param name="month">int month</param>
        /// <returns>Jan, Feb, Mar etc.</returns>
        public static string ToShortBritishMonthName(this int month)
        {
            switch (month)
            {
                case 1:
                    return "Jan";
                case 2:
                    return "Feb";
                case 3:
                    return "Mar";
                case 4:
                    return "Apr";
                case 5:
                    return "May";
                case 6:
                    return "Jun";
                case 7:
                    return "Jul";
                case 8:
                    return "Aug";
                case 9:
                    return "Sep";
                case 10:
                    return "Oct";
                case 11:
                    return "Nov";
                case 12:
                    return "Dec";
                default:
                    return "";
            }
        }

        /// <summary>
        /// Get a string in the format 1 January 2004 from a DateTime object. This method should be used only when the preferred style (including the day) is too long.
        /// </summary>
        public static string ToBritishDate(this DateTime date)
        {
            return (new StringBuilder(date.Date.Day.ToString(UkCulture)).Append(" ").Append(date.Date.Month.ToBritishMonthName()).Append(" ").Append(date.Date.Year.ToString()).ToString());
        }

        /// <summary>
        /// Get a string in the format 1 January 2004 from a DateTime object, or an empty string. This method should be used only when the preferred style (including the day) is too long.
        /// </summary>
        public static string ToBritishDate(this DateTime? date)
        {
            if (date.HasValue) return date.Value.ToBritishDate();
            return String.Empty;
        }

        /// <summary>
        /// Get a string in the format 1 Jan 2004 from a DateTime object. This method should be used only when the preferred full style (including the day) is too long.
        /// </summary>
        public static string ToShortBritishDate(this DateTime date)
        {
            return (new StringBuilder(date.Date.Day.ToString(UkCulture)).Append(" ").Append(date.Date.Month.ToShortBritishMonthName()).Append(" ").Append(date.Date.Year.ToString()).ToString());
        }

        /// <summary>
        /// Get a string in the format 1 Jan 2004 from a DateTime object, or an empty string. This method should be used only when the preferred full style (including the day) is too long.
        /// </summary>
        public static string ToShortBritishDate(this DateTime? date)
        {
            if (date.HasValue) return date.Value.ToShortBritishDate();
            return String.Empty;
        }

        /// <summary>
        /// Get a string in the format 1 Jan 2004 from a DateTime object. Use only for short-term data about the current year, never for anything which will be seen later on, and then only when the preferred full style (including the day) is too long.
        /// </summary>
        public static string ToShortBritishDateNoYear(this DateTime date)
        {
            return (new StringBuilder(date.Date.Day.ToString(UkCulture)).Append(" ").Append(date.Date.Month.ToShortBritishMonthName()).ToString());
        }

        /// <summary>
        /// Get a string in the format 1 Jan 2004 from a DateTime object, or an empty string. Use only for short-term data about the current year, never for anything which will be seen later on, and then only when the preferred full style (including the day) is too long.
        /// </summary>
        public static string ToShortBritishDateNoYear(this DateTime? date)
        {
            if (date.HasValue) return date.Value.ToShortBritishDateNoYear();
            return String.Empty;
        }

        /// <summary>
        /// Get a string in the format Monday 1 January 2004 from a DateTime object
        /// </summary>
        public static string ToBritishDateWithDay(this DateTime date)
        {
            return (new StringBuilder(date.Date.DayOfWeek.ToString()).Append(" ").Append(date.Date.Day.ToString()).Append(" ").Append(date.Date.Month.ToBritishMonthName()).Append(" ").Append(date.Date.Year.ToString()).ToString());
        }

        /// <summary>
        /// Get a string in the format Monday 1 January 2004 from a DateTime object, or an empty string
        /// </summary>
        public static string ToBritishDateWithDay(this DateTime? date)
        {
            if (date.HasValue) return date.Value.ToBritishDateWithDay();
            return String.Empty;
        }

        /// <summary>
        /// Get a string in the format 1 January 2004, 10am from a DateTime object. This method should be used only when the preferred style (including the day) is too long.
        /// </summary>
        public static string ToBritishDateWithTime(this DateTime date)
        {
            return (new StringBuilder(date.ToBritishDate()).Append(", ").Append(date.ToBritishTime()).ToString());
        }

        /// <summary>
        /// Get a string in the format 1 January 2004, 10am from a DateTime object, or an empty string. This method should be used only when the preferred style (including the day) is too long.
        /// </summary>
        public static string ToBritishDateWithTime(this DateTime? date)
        {
            if (date.HasValue) return date.Value.ToBritishDateWithTime();
            return String.Empty;
        }

        /// <summary>
        /// Get a string in the format Monday 1 January 2004, 10am from a DateTime object
        /// </summary>
        public static string ToBritishDateWithDayAndTime(this DateTime date)
        {
            return (new StringBuilder(date.ToBritishDateWithDay()).Append(", ").Append(date.ToBritishTime()).ToString());
        }

        /// <summary>
        /// Get a string in the format Monday 1 January 2004, 10am from a DateTime object, or an empty string
        /// </summary>
        public static string ToBritishDateWithDayAndTime(this DateTime? date)
        {
            if (date.HasValue) return date.Value.ToBritishDateWithDayAndTime();
            return String.Empty;
        }

        /// <summary>
        /// Get a string in the format 1 Jan 2004, 10am from a DateTime object
        /// </summary>
        public static string ToShortBritishDateWithTime(this DateTime date)
        {
            return (new StringBuilder(date.ToShortBritishDate()).Append(", ").Append(date.ToBritishTime()).ToString());
        }

        /// <summary>
        /// Get a string in the format 1 Jan 2004, 10am from a DateTime object, or an empty string
        /// </summary>
        public static string ToShortBritishDateWithTime(this DateTime? date)
        {
            if (date.HasValue) return date.Value.ToShortBritishDateWithTime();
            return String.Empty;
        }

        /// <summary>
        /// Get a string in the format 1 Jan, 10am. Use only for short-term data about the current year, never for anything which will be seen later on.
        /// </summary>
        public static string ToShortBritishDateNoYearWithTime(this DateTime date)
        {
            return (new StringBuilder(date.ToShortBritishDateNoYear()).Append(", ").Append(date.ToBritishTime()).ToString());
        }

        /// <summary>
        /// Get a string in the format 1 Jan, 10am, or an empty string. Use only for short-term data about the current year, never for anything which will be seen later on.
        /// </summary>
        public static string ToShortBritishDateNoYearWithTime(this DateTime? date)
        {
            if (date.HasValue) return date.Value.ToShortBritishDateNoYearWithTime();
            return String.Empty;
        }

        /// <summary>
        /// Get a string in the format January 2004 from a DateTime object
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToBritishMonthAndYear(this DateTime date)
        {
            return date.ToString("MMMM yyyy", UkCulture);
        }

        /// <summary>
        /// Get a string in the format January 2004 from a DateTime object
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToBritishMonthAndYear(this DateTime? date)
        {
            if (date.HasValue) return date.Value.ToBritishMonthAndYear();
            return String.Empty;
        }

        /// <summary>
        /// Get a string in the format 10am or 10.15am from a DateTime object
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string ToBritishTime(this DateTime time)
        {
            StringBuilder sb = new StringBuilder();

            // Add the hour
            if (time.Hour == 0) sb.Append("12");
            else
            {
                sb.Append((time.Hour <= 12) ? time.Hour.ToString() : (time.Hour - 12).ToString());
            }

            // Add the minutes only if there are some
            if (time.Minute > 0)
            {
                sb.Append(".");
                sb.Append(time.ToString("mm"));
            }

            // Add am/pm unless it's midnight or midday
            if (time.Hour == 0 && time.Minute == 0)
            {
                sb.Append(" midnight");
            }
            else if (time.Hour == 12 && time.Minute == 0)
            {
                sb.Append(" noon");
            }
            else
            {
                sb.Append(time.ToString("tt", UkCulture).ToLower(UkCulture));
            }
            return sb.ToString();
        }

        /// <summary>
        /// Get a string in the format 10am or 10.15am, or an empty string, from a DateTime object
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string ToBritishTime(this DateTime? time)
        {
            if (time.HasValue) return time.Value.ToBritishTime();
            return String.Empty;
        }

        /// <summary>
        /// Gets the house-style description of a period from one date and time to another
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns>A text string which includes HTML entities</returns>
        public static string ToBritishDateRangeFromThisDateUntil(this DateTime startDate, DateTime endDate)
        {
            return ToBritishDateRangeFromThisDateUntil(startDate, endDate, true, true);
        }

        /// <summary>
        /// Gets the house-style description of a period from one date/time to another
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <param name="showStartTime">if set to <c>true</c> show start time.</param>
        /// <param name="showEndTime">if set to <c>true</c> show end time.</param>
        /// <returns>A text string which includes HTML entities</returns>
        public static string ToBritishDateRangeFromThisDateUntil(this DateTime startDate, DateTime endDate, bool showStartTime, bool showEndTime)
        {
            return ToBritishDateRangeFromThisDateUntil(startDate, endDate, showStartTime, showEndTime, false);
        }

        /// <summary>
        /// Gets the house-style description of a period from one date/time to another
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <param name="showStartTime">if set to <c>true</c> show start time.</param>
        /// <param name="showEndTime">if set to <c>true</c> show end time.</param>
        /// <param name="useShortDateText">if set to <c>true</c> omit day name and use short month names.</param>
        /// <returns>
        /// A text string which includes HTML entities
        /// </returns>
        public static string ToBritishDateRangeFromThisDateUntil(this DateTime startDate, DateTime endDate, bool showStartTime, bool showEndTime, bool useShortDateText)
        {
            bool multiDay = (startDate.DayOfYear != endDate.DayOfYear || startDate.Year != endDate.Year);
            bool showTime = (showStartTime || showEndTime);
            bool sameMonth = (startDate.Month == endDate.Month && startDate.Year == endDate.Year);

            if (!multiDay && !showTime)
            {
                /*
                    One day, no time
                    ---------------------------------------
                    Friday 26 May 2006
                    */

                if (useShortDateText) return startDate.ToShortBritishDate();
                return startDate.ToBritishDateWithDay();

            }
            else if (!multiDay && showStartTime && !showEndTime)
            {
                /*
                    One day, with start time
                    ---------------------------------------
                    9am, Friday 26 May 2006
                    */
                if (useShortDateText) return startDate.ToShortBritishDateWithTime();
                return startDate.ToBritishDateWithDayAndTime();

            }
            else if (!multiDay && showStartTime && showEndTime)
            {
                /*
                    One day, with start and finish times
                    ---------------------------------------
                    9am-2pm, Friday 26 May 2006
                    */
                if (useShortDateText) return (new StringBuilder(startDate.ToBritishTime()).Append(" to ").Append(endDate.ToBritishTime()).Append(", ").Append(startDate.ToShortBritishDate()).ToString());
                return (new StringBuilder(startDate.ToBritishTime()).Append(" to ").Append(endDate.ToBritishTime()).Append(", ").Append(startDate.ToBritishDateWithDay()).ToString());

            }
            else if (multiDay && !showTime && sameMonth)
            {
                /*
                    Different days, no times, same month
                    ---------------------------------------
                    26-27 May 2006
                    */
                if (useShortDateText) return (new StringBuilder(startDate.Day.ToString(UkCulture)).Append(" to ").Append(endDate.ToShortBritishDate()).ToString());
                return (new StringBuilder(startDate.Day.ToString(UkCulture)).Append(" to ").Append(endDate.ToBritishDate()).ToString());

            }
            else if (multiDay && !showTime && !sameMonth)
            {
                /*
                    Different days, no times, different month
                    ---------------------------------------
                    Friday 26 May 2006 - Thursday 1 June 2006 
                    */
                if (useShortDateText) return (new StringBuilder(startDate.ToShortBritishDate()).Append(" to ").Append(endDate.ToShortBritishDate()).ToString());
                return (new StringBuilder(startDate.ToBritishDateWithDay()).Append(" to ").Append(endDate.ToBritishDateWithDay()).ToString());

            }
            else if (multiDay && showStartTime && !showEndTime)
            {
                /*
                    Different days, with start time
                    ---------------------------------------
                    9am, Friday 26 May 2006 to Saturday 27 May 2006
                    */
                if (useShortDateText) return (new StringBuilder(startDate.ToShortBritishDateWithTime()).Append(" to ").Append(endDate.ToShortBritishDate()).ToString());
                return (new StringBuilder(startDate.ToBritishDateWithDayAndTime()).Append(" to ").Append(endDate.ToBritishDateWithDay()).ToString());

            }
            else if (multiDay && showStartTime && showEndTime)
            {
                /*
                    Different days, with start and end time
                    ---------------------------------------
                    9am, Friday 26 May 2006 to 2pm, Saturday 27 May 2006
                    */
                if (useShortDateText) return (new StringBuilder(startDate.ToShortBritishDateWithTime()).Append(" to ").Append(endDate.ToShortBritishDateWithTime()).ToString());
                return (new StringBuilder(startDate.ToBritishDateWithDayAndTime()).Append(" to ").Append(endDate.ToBritishDateWithDayAndTime()).ToString());

            }

            // Shouldn't get here
            return String.Empty;
        }
    }
}
