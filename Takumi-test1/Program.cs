﻿using TakumiTest1;

internal class Program
{
    private static void Main(string[] args)
    {
        //年の入力
        Console.WriteLine("年を入力してください");
        bool isYearConvert = int.TryParse(Console.ReadLine(), out int year); //tryparseで変換可能か確認する

        if (!isYearConvert)
        {
            Console.WriteLine("不正な値です");
            return;
        }
        if (year < 1960 || year > 2050)
        {
            Console.WriteLine("1960年から2050年までを入力してください");
            return;
        }

        //月の入力
        Console.WriteLine("月を入力してください");
        bool isMonthConvert = int.TryParse(Console.ReadLine(), out int month);

        if (!isMonthConvert)
        {
            Console.WriteLine("不正な値です");
            return;
        }
        if (month < 1 || month > 12)
        {
            Console.WriteLine("1月から12月までを入力してください");
            return;
        }

        //日の入力
        Console.WriteLine("日を入力してください");
        bool isDayConvert = int.TryParse(Console.ReadLine(), out int day);

        if (!isDayConvert)
        {
            Console.WriteLine("不正な値です");
            return;
        }
        if (day < 1 || day > DateTime.DaysInMonth(year, month))
        {
            Console.WriteLine("月の規定日内で入力してください");
            return;
        }
        if (year == 1960 && day < 28 || year == 2050 && day > 22)
        {
            Console.WriteLine("1960年28日以降、2050年22日以内で入力してください");    //jpnLunisolarcalがこの日付までしか対応していないため
            return;
        }

        var dateTime = new DateTime(year, month, day);  //datetimeの作成
        var rokuyo = new Rokuyo();  //使用頻度が高くなかったりする場合はプロパティに渡さない手もある

        rokuyo.GetLunisolarCalender(dateTime);

        Console.WriteLine($"{year}年{month}月{day}日は{rokuyo.GetRokuyoString(dateTime)}です");
    }
}