using System.Globalization;

namespace TakumiTest1
{
    class LunisolarCalender
    {
        protected int year = 0;
        protected int month = 0;
        protected int day = 0;

        public LunisolarCalender(int year, int month, int day)
        {
            this.year = year;
            this.month = month;
            this.day = day;
        }

        protected (int, int) GetLunisolarCalender()
        {
            var jpnLunisolarlCal = new JapaneseLunisolarCalendar();
            var dataTime = new DateTime(year, month, day);

            int lunisolarMonth = jpnLunisolarlCal.GetMonth(dataTime);
            int lunisolarDay = jpnLunisolarlCal.GetDayOfMonth(dataTime);

            int leapMonth = jpnLunisolarlCal.GetLeapMonth(
                jpnLunisolarlCal.GetYear(dataTime),
                jpnLunisolarlCal.GetEra(dataTime)
                );

            //閏月含む場合の月を補正
            if ((leapMonth > 0) && (lunisolarMonth - leapMonth >= 0))
            {
                lunisolarMonth = lunisolarMonth - 1;              //旧暦月の補正
            }

            return (lunisolarMonth, lunisolarDay);
        }

    }
}
