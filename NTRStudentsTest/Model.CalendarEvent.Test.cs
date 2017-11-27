using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calendar;

namespace CalendarTest
{
	[TestClass]
	public class Model_CalendarEvent_Test
	{
		[TestMethod]
		public void TestToString()
		{
            Calendar.Model.CalendarEvent E = new Calendar.Model.CalendarEvent
            {
                Time = DateTime.Parse("2009/02/26 18:37:58"),
                Title = "Test"
            };
            Assert.AreEqual(E.ToString(), "18:37 Test");
		}
	}
}
