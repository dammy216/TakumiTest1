using System.Globalization;

namespace TakumiTest1
{
    internal class Rokuyo
    {
        /// <summary>
        /// 旧暦の取得とうるう月の計算をする関数
        /// </summary>
        /// <returns>うるう月補正後の旧歴の月と旧暦の日</returns>
        public (int, int) GetLunisolarCalender(DateTime dateTime)
        {
            var jpnLunisolarlCal = new JapaneseLunisolarCalendar();     //旧暦を取得するクラス

            //月と月ごとの日にちを取得
            int lunisolarMonth = jpnLunisolarlCal.GetMonth(dateTime);       //旧暦の月
            int lunisolarDay = jpnLunisolarlCal.GetDayOfMonth(dateTime);    //旧暦の日

            //うるう月の計算
            int leapMonth = jpnLunisolarlCal.GetLeapMonth(      //うるう月をを持つ変数
                jpnLunisolarlCal.GetYear(dateTime),
                jpnLunisolarlCal.GetEra(dateTime)
                );

            //閏月の補正
            if ((leapMonth > 0) && (lunisolarMonth >= leapMonth))   //閏月が0より大きいかつ、旧暦の月が閏月以上
            {
                lunisolarMonth--;              //条件に当てはまった旧暦月から1引いた値を代入して旧暦月を補正
            }

            return (lunisolarMonth, lunisolarDay);
        }

        //六曜の一覧
        public enum RokuyoDate
        {
            Taian,
            Shakko,
            Sensho,
            Tomobiki,
            Senpu,
            Butsumetsu,
        }

        /// <summary>
        /// 旧暦から六曜を求める関数
        /// </summary>
        /// <returns>入力された年月日の六曜</returns>
        /// <exception cref="InvalidOperationException"></exception>
        private RokuyoDate GetRokuyo(DateTime dateTime)
        {
            (int, int) lunisolarMonthDay = GetLunisolarCalender(dateTime);  //戻り値が複数ある場合は
            int month = lunisolarMonthDay.Item1;   //旧暦の月を代入
            int day = lunisolarMonthDay.Item2;     //旧暦の日を代入

            int rokuyoIndex = (month + day) % 6;    //旧暦から六曜を求める計算

            //rokuyoIndexをキャストしてRokuyoDataの数値を紐づける
            return (RokuyoDate)rokuyoIndex;
        }

        /// <summary>
        /// 六曜を文字列に変換するメソッド
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns>string型の六曜</returns>
        public string GetRokuyoString(DateTime dateTime)
        {
            var rokuyo = GetRokuyo(dateTime);
            switch (rokuyo)
            {
                case RokuyoDate.Taian:
                    return "大安";
                case RokuyoDate.Shakko:
                    return "赤口";
                case RokuyoDate.Sensho:
                    return "先勝";
                case RokuyoDate.Tomobiki:
                    return "友引";
                case RokuyoDate.Senpu:
                    return "先負";
                case RokuyoDate.Butsumetsu:
                    return "仏滅";
                default:
                    throw new InvalidOperationException("無効な値です");
            }
        }

    }
}
