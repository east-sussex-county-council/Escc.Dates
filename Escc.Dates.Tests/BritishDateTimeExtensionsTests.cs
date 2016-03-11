using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Escc.Dates;

namespace Escc.Dates.Tests
{
    [TestFixture]
    public class BritishDateTimeExtensionsTests
    {
        [Test]
        public void TestMethod()
        {
            var britishDate = new DateTime(2016, 3, 13, 13, 10, 0).ToBritishDateWithDayAndTime();

            Assert.AreEqual("Sunday 13 March 2016, 1.10pm", britishDate);
        }
    }
}
