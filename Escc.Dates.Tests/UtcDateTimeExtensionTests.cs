using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Escc.Dates.Tests
{
    [TestFixture]
    class UtcDateTimeExtensionTests
    {
        [Test]
        public void Iso8601ShouldNotAdjustDateWithoutTime()
        {
            // This date is subject to daylight savings, one hour ahead of UTC. 
            // In UTC it is the day before, but we throw away the timezone information that explains that, so returning the day before would not be the expected result.
            var timeZone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");
            var ukDate = TimeZoneInfo.ConvertTimeFromUtc(DateTime.Parse("30 May 2016", new CultureInfo("en-GB")), timeZone);

            var isoDate = ukDate.ToIso8601Date();

            Assert.AreEqual("2016-05-30", isoDate);
        }
        
        [Test]
        public void Rfc850DateTimeConvertsOK()
        {
            var date = new DateTime(2005, 08, 15, 15, 52, 01, DateTimeKind.Utc);
            var expected = "Monday, 15-Aug-05 15:52:01 UTC";

            var result = date.ToRfc850DateTime();
            
            Assert.AreEqual(expected, result);
        }
    }
}
