using EnumComparisionApp.Classes;
using Spectre.Console;

namespace EnumComparisionApp;

internal class Program
{
    static void Main(string[] args)
    {
        //OperationsEnums.Sample1();
        //OperationsEnums.Sample2();
        //OperationsEnums.MicroSoftExample();
        //OperationsPatterns.Sample1();

var dates = Enumerable
    .Range(1, 17)
    .Select(x => new DateOnly(2023, 1, x)).ToList();

foreach (var date in dates)
{
    Console.WriteLine($"{date,-12:MM/dd/yyyy}" + 
                      $"{date.IsWeekend(),-10}{date.DayOfWeek}");
}


        

        //DateTime.Now.GetNextWeeksDates().ForEach( d =>
        //{
            
        //    Console.WriteLine($"{d,-10}{d.IsWeekend(),-10}{d.DayOfWeek}");
        //});

        Console.ReadLine();
    }


      


}


