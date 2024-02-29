using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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

        protected int getLunarCalender()
        {
        JapaneseLunisolarCalendar jpnLunarlCal = new JapaneseLunisolarCalendar();
        int lunarMonth = jpnLunarlCal.GetMonth
        }

    }
}
