# Escc.Dates

Extension methods for parsing and formatting dates in British English, converting dates to the UK time zone, and converting dates to common international formats.

## Parsing and formatting dates

The `ParseBritishDateTime` method is more forgiving of the way people naturally express dates than the built-in `DateTime.Parse` method. For example, it will assume the current year if one isn't specified.

	var dateTime = "15 May".ParseBritishDateTime();

To format dates and times in British English, look for the `.ToBritish…()` and `.ToShortBritish…()` extension methods on a `DateTime` object. Dates are formatted in British English in line with the East Sussex County Council house style. For example:

	var formatted = new DateTime(2016, 5, 15).ToBritishDateWithDayAndTime();

You can also chain the parse and format methods to reformat a date string.

	var formatted = "15 May".ParseBritishDateTime().ToBritishDateWithDay();

## Converting dates to the UK time zone

Call `.ToUkDateTime()` on any `DateTime` to convert it to a UK date regardless of the culture of the current thread. This is particularly important for applications hosted on Microsoft Azure where the time is in UTC and the culture is en-US.

	var ukNow = DateTime.Now.ToUkDateTime();

## Converting dates to international formats

When complying with standards it's often necessary to use a standard international date and time format.

	// ISO 8601: returns 2006-04-01
	var iso8601Date = new DateTime(2006, 4, 1).ToIso8601Date();

	// ISO 8601: returns 2006-04-01T15:30:00Z
	var iso8601DateTime = new DateTime(2006, 4, 1, 15, 30, 00).Iso8601DateTime();

	// RFC 822, useful for RSS feeds: returns Mon, 15 Aug 05 15:52:01 +0000 
	var rfc822Date = new DateTime(2005, 8, 5, 15, 52, 01).ToRfc822DateTime();

	// RFC 850, useful for the unavailable_after value of the robots meta tag: returns Monday, 15-Aug-05 15:52:01 UTC 
	var rfc850Date = new DateTime(2005, 08, 15, 15, 52, 01, DateTimeKind.Utc).ToRfc850DateTime();

	// UNIX timestamp: returns 1143905400
	var timestamp = new DateTime(2006, 4, 1, 15, 30, 00).ToUnixTimestamp();

## NuGet package

The NuGet package is created using the [NuBuild](https://github.com/bspell1/NuBuild) extension for Visual Studio.