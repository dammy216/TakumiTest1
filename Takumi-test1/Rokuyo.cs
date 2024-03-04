namespace TakumiTest1
{
    internal class Rokuyo : LunisolarCalender
    {
        //コンストラクタ
        public Rokuyo(int year, int month, int day) : base(year, month, day)
        {
        }

        //六曜の一覧
        enum RokuyoData
        {
            大安,
            赤口,
            先勝,
            友引,
            先負,
            仏滅
        }

        /// <summary>
        /// 旧暦から六曜を求める関数
        /// </summary>
        /// <returns>入力された年月日の六曜</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public string RokuyoResult()
        {
            int month = GetLunisolarCalender().Item1;   //旧暦の月を代入
            int day = GetLunisolarCalender().Item2;     //旧暦の日を代入

            int rokuyoIndex = (month + day) % 6;    //旧暦から六曜を求める計算

            //計算結果(余りの値)から対応する六曜を返す処理
            switch (rokuyoIndex)
            {
                case 0:
                    return RokuyoData.大安.ToString();
                case 1:
                    return RokuyoData.赤口.ToString();
                case 2:
                    return RokuyoData.先勝.ToString();
                case 3:
                    return RokuyoData.友引.ToString();
                case 4:
                    return RokuyoData.先負.ToString();
                case 5:
                    return RokuyoData.仏滅.ToString();
                default:
                    throw new InvalidOperationException("無効な値です");
            }
        }

    }
}
