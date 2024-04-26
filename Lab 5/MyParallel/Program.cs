
using MyParallel;

System.Console.WriteLine("Hello");


TaskDelegate[] tasks = [
    Task1, Task2, Task3, Task4, Task5, Task6
];

long msc = ParallelWaiAll.wait(tasks);

System.Console.WriteLine($"It was taken for about {msc} msc");

Console.ReadLine();

static void Task1()
{
    Thread.Sleep(10000);
    System.Console.WriteLine("Таск1");
}

static void Task2()
{
    Thread.Sleep(10);
    System.Console.WriteLine("Таск1");
}

static void Task3()
{
    Thread.Sleep(10);
    System.Console.WriteLine("Таск2");
}

static void Task4()
{
    Thread.Sleep(10);
    System.Console.WriteLine("Таск3");
}
static void Task5()
{
    Thread.Sleep(3000);
    System.Console.WriteLine("Таск4");
}
static void Task6()
{
    Thread.Sleep(10);
    System.Console.WriteLine("Таск 6");
}