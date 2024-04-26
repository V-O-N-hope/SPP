using System.Reflection;

if (args.Length < 1)
{
    System.Console.WriteLine("sorry, no params");
}
else
{
    // string path = "D:\\Mikita\\Work\\C#\\DemoAssembly\\bin\\Debug\\net9.0\\DemoAssembly.dll";
    string path = args[0];
    getInfo(path);
}   

void getInfo(string path)
{
    var assembly = Assembly.LoadFile(path);
    string attrName = "ExportClass";
    bool shouldParse;


    foreach (var type in assembly.GetTypes())
    {
        
        if (type.IsClass)
        {
            shouldParse = false;
            object[] attributes = type.GetCustomAttributes(true);
            foreach (Attribute attribute in attributes)
            {
                if (attribute.GetType().Name.Equals(attrName))
                {
                    shouldParse = true;
                    break;
                }
            }

            BindingFlags flags = BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance;

            if (shouldParse)
            {
                Console.WriteLine($"Class: {type.Name}");

                // Выводим публичные поля
                foreach (var field in type.GetFields(flags))
                {
                    Console.WriteLine($"Field: {field.Name} ({field.FieldType.Name})");
                }

                // Выводим публичные свойства
                foreach (var property in type.GetProperties(flags))
                {
                    Console.WriteLine($"Property: {property.Name} ({property.PropertyType.Name})");
                }
                Console.WriteLine();
            }

        }
    }
}



