using System;
using Car;

class Program
{
    static void Main()
    {
        // Здесь будет загружаться модуль auto.netmodule
        Auto obj = new Auto();
        obj.AutoInfo();

        SportCar obj1 = new SportCar();
        obj1.InfoSportCar();

        Console.ReadLine();
    }
}