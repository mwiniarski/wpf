using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calendar;

namespace CalendarTest
{
	[TestClass]
	public class Model_Year_Test
	{
		[TestMethod]
		public void TestToString()
		{
            Calendar.Model.Year E = new Calendar.Model.Year
            {
                Week = 15,
            };
            E.Days.Add(new Calendar.Model.Day { Date = DateTime.Parse("2009/12/31 18:37:58") });
            Assert.AreEqual(E.Days[0].DateString, "gru 31");
		}
	}
}
