LogBuffer logBuffer = new LogBuffer(5, 3);

for (int i = 1; i <= 5001; i++)
{
    logBuffer.add($"{i} - My message");
}

System.Console.WriteLine("End...");

Console.ReadLine();

