using SF2022User01Lib;

namespace TestProjectX
{
    public class Tests
    {
        Calculations calculations;
        [SetUp]
        public void Setup()
        {
            calculations = new Calculations();
        }

        [Test]
        public void ScheduleTrue()
        {
            TimeSpan[] startTimes = new TimeSpan[] {new TimeSpan(10,0,0), new TimeSpan(11,0,0), new TimeSpan(15,0,0), new TimeSpan(15,30,0), new TimeSpan(16,50,0) };
            int[] durations = new int[] {60, 30, 10, 10, 40};
            TimeSpan beginWorkingTime = new TimeSpan(8,0,0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            int consultationTime = 30;
            string[] result = calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            string[] strings = new string[] { "08:00 - 08:30",
                                              "08:30 - 09:00",
                                              "09:00 - 09:30",
                                              "09:30 - 10:00",
                                              "11:30 - 12:00",
                                              "12:00 - 12:30",
                                              "12:30 - 13:00",
                                              "13:00 - 13:30",
                                              "13:30 - 14:00",
                                              "14:00 - 14:30",
                                              "14:30 - 15:00",
                                              "15:40 - 16:10",
                                              "16:10 - 16:40",
                                              "17:30 - 18:00"};
            Assert.AreEqual(result, strings);
        }
        [Test]
        public void ScheduleTrueWhithConsultTime45()
        {
            TimeSpan[] startTimes = new TimeSpan[] { new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0), new TimeSpan(15, 0, 0), new TimeSpan(15, 30, 0), new TimeSpan(16, 50, 0) };
            int[] durations = new int[] { 60, 30, 10, 10, 40 };
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            int consultationTime = 45;
            string[] result = calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime);
            string[] strings = new string[] { "08:00 - 08:45",
                                              "08:45 - 09:30",
                                              "11:30 - 12:15",
                                              "12:15 - 13:00",
                                              "13:00 - 13:45",
                                              "13:45 - 14:30",
                                              "15:40 - 16:25",};
            Assert.AreEqual(result, strings);

        }
        [Test]
        public void MaxConsTime()
        {
            TimeSpan[] startTimes = new System.TimeSpan[] { new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0), new TimeSpan(15, 0, 0), new TimeSpan(15, 30, 0), new TimeSpan(16, 50, 0) };
            int[] durations = new int[] { 60, 30, 10, 10, 40 };
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            int consultationTime = 300;
            Assert.Throws<ArgumentException>(() => calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime));
        }
        //[Test]
        //public void MinConsTime()
        //{
        //    TimeSpan[] startTimes = new System.TimeSpan[] { new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0), new TimeSpan(15, 0, 0), new TimeSpan(15, 30, 0), new TimeSpan(16, 50, 0) };
        //    int[] durations = new int[] { 60, 30, 10, 10, 40 };
        //    TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
        //    TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
        //    int consultationTime = 10;
        //    Assert.Throws<ArgumentException>(() => calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime));
        //}
        [Test]
        public void TestNoValidTime()
        {
            TimeSpan[] startTimes = new System.TimeSpan[] { new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0), new TimeSpan(15, 0, 0), new TimeSpan(15, 30, 0), new TimeSpan(16, 50, 0) };
            int[] durations = new int[] { 60, 30, 10, 10, 40 };
            TimeSpan beginWorkingTime = new TimeSpan(8, 0, 0);
            TimeSpan endWorkingTime = new TimeSpan(18, 0, 0);
            int consultationTime = -30;
            Assert.Throws<ArgumentException>(() => calculations.AvailablePeriods(startTimes, durations, beginWorkingTime, endWorkingTime, consultationTime));
        }
        
    }

}