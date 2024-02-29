using System;
using TakumiTest1;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("年を入力してください");
        int year = int.Parse(Console.ReadLine());
        if (year < 1) return;

        Console.WriteLine("月を入力してください");
        int month = int.Parse(Console.ReadLine());
        if (month < 1 || month > 12) return;

        Console.WriteLine("日を入力してください");
        int day = int.Parse(Console.ReadLine());
        if (day < 1 || day > DateTime.DaysInMonth(year, month)) return;

        var lunarCalender = new LunisolarCalender(year, month, day);
        

        Console.WriteLine($"{year}年{month}月{day}日はです");
    }
}