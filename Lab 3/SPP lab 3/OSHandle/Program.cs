using System;
using System.IO;
using OSHandle;

public class Program
{
    private static void Main(string[] args)
    {
        try
        {
            using (FileStream fileStream = new FileStream("E:\\Models\\Cube.obj", FileMode.Open))
            {
                IntPtr fileHandle = fileStream.SafeFileHandle.DangerousGetHandle();
                Console.WriteLine("File handle: " + fileHandle.ToString());

                Console.WriteLine("Enter handle: ");
                int iHandle = int.Parse(Console.ReadLine());

                IntPtr handle = iHandle;

                OSHadle.myCloseHandle(ref handle);

                // Check if fileHandle is still open

                try
                {
                    byte[] buffer = new byte[1];
                    fileStream.Read(buffer, 0, 1);
                    Console.WriteLine("You didn't close the file handle.");
                }
                catch (IOException)
                {
                    Console.WriteLine("File handle is closed.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        Console.ReadLine();
    }
}