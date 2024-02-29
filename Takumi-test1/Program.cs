using TakumiTest1;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("年を入力してください");
        int year = int.Parse(Console.ReadLine());
        if (year < 1960 || year > 2050)
        {
            Console.WriteLine("1960年から2050年までを入力してください");
            return;
        }

        Console.WriteLine("月を入力してください");
        int month = int.Parse(Console.ReadLine());
        if (month < 1 || month > 12)
        {
            Console.WriteLine("1月から12月までを入力してください");
            return;
        }

        Console.WriteLine("日を入力してください");
        int day = int.Parse(Console.ReadLine());
        if (day < 1 || day > DateTime.DaysInMonth(year, month))
        {
            Console.WriteLine("月の規定日内で入力してください");
            return;
        }
        if(year == 1960 && day < 28 || year == 2050 && day > 22)
        {
            Console.WriteLine("1960年28日以降、2050年22日以内で入力してください");
            return;
        }

        new LunisolarCalender(year, month, day);
        var rokuyo = new Rokuyo(year, month, day);

        Console.WriteLine($"{year}年{month}月{day}日は{rokuyo.RokuyoResult()}です");
    }
}