using DynamicList;
using System;

Console.WriteLine("Hello, World!");

DynamicsList<int> list = new DynamicsList<int>();

for (int i = 0; i < 20; i++)
{
    list.Add(i);
}

Console.WriteLine($"Amount is {list.Count}");
list.Clear();
Console.WriteLine($"Amount is {list.Count}");

Console.ReadLine();