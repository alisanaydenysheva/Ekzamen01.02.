using ClassLib;

namespace Ms_Test
{
    [TestClass]
    public class AnalyticsTest
    {
        static Analytics AnalyticsClass = null;

        [ClassInitialize]
        static public void Init(TestContext tc)
        {
            AnalyticsClass = new Analytics();
        }


        [TestMethod]
        public void PopularMonths_CountTest()
        {
            List<DateTime> dates = new List<DateTime>() {
                new DateTime(2020, 11, 17),
                new DateTime(2020, 12, 17),
                new DateTime(2020, 10, 1) };

            dates = AnalyticsClass.PopularMonths(dates);

            // должно вернуть все 3 записи
            Assert.AreEqual(dates.Count, 3);
        }

        [TestMethod]
        public void PopularMonths_ValidDataWithAdditionalSortByDate()
        {
            List<DateTime> dates = new List<DateTime>() {
                new DateTime(2020, 12, 17),
                new DateTime(2020, 12, 15),
                new DateTime(2020, 11, 17),
                new DateTime(2020, 10, 1) };

            dates = AnalyticsClass.PopularMonths(dates);

            
            Assert.AreEqual(dates[0], new DateTime(2020, 12, 1));
            Assert.AreEqual(dates.Count, 3);

            
        }

        [TestMethod]
        public void PopularMonths_ValidDataWithOnlyOneMonth()
        {
            List<DateTime> dates = new List<DateTime>() {
                new DateTime(2020, 12, 11),
                new DateTime(2020, 12, 1),
                new DateTime(2020, 12, 21),
                new DateTime(2020, 12, 6) };

            dates = AnalyticsClass.PopularMonths(dates);


            Assert.AreEqual(dates[0], new DateTime(2020, 12, 1));
            Assert.AreEqual(dates.Count, 1);


        }

    }
}
