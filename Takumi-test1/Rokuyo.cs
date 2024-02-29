namespace TakumiTest1
{
    internal class Rokuyo : LunisolarCalender
    {
        public Rokuyo(int year, int month, int day) : base(year, month, day)
        {
        }

        enum RokuyoData
        {
            大安,
            赤口,
            先勝,
            友引,
            先負,
            仏滅
        }

        public string RokuyoResult()
        {
            int month = GetLunisolarCalender().Item1;
            int day = GetLunisolarCalender().Item2;

            int rokuyoIndex = (month + day) % 6; // 六曜は7日周期で繰り返すため、6で割った余りを使う

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
