namespace DemoAssembly;

[ExportClass]
public class Person
{
    public int age { get; }
    public string name { get; }

    public static string ClassVersion = "1"; 

    public Person(string name, int age)
    {
        this.age = age;
        this.name = name;
    }
}
