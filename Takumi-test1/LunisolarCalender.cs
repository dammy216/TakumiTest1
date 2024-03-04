using System.Globalization;

namespace TakumiTest1
{
    class LunisolarCalender
    {   
        //年月日の初期化
        protected int year = 0;
        protected int month = 0;
        protected int day = 0;

        //コンストラクタ
        public LunisolarCalender(int year, int month, int day)
        {
            this.year = year;
            this.month = month;
            this.day = day;
        }

        /// <summary>
        /// 旧暦の取得とうるう月の計算をする関数
        /// </summary>
        /// <returns>うるう月補正後の旧歴の月と旧暦の日</returns>
        protected (int, int) GetLunisolarCalender()
        {
            var jpnLunisolarlCal = new JapaneseLunisolarCalendar();     //旧暦を取得するクラス
            var dataTime = new DateTime(year, month, day);              //入力された年月日を持つ変数

            //月と月ごとの日にちを取得
            int lunisolarMonth = jpnLunisolarlCal.GetMonth(dataTime);       //旧暦の月
            int lunisolarDay = jpnLunisolarlCal.GetDayOfMonth(dataTime);    //旧暦の日

            //うるう月の計算
            int leapMonth = jpnLunisolarlCal.GetLeapMonth(      //うるう月をを持つ変数
                jpnLunisolarlCal.GetYear(dataTime),
                jpnLunisolarlCal.GetEra(dataTime)
                );

            //閏月の補正
            if ((leapMonth > 0) && (lunisolarMonth - leapMonth >= 0))
            {
                lunisolarMonth = lunisolarMonth - 1;              //旧暦月を補正
            }

            return (lunisolarMonth, lunisolarDay);      
        }

    }
}
