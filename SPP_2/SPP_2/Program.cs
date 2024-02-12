using System;
using System.IO;
using System.Threading;

namespace SPP_2
{
    public static class Program
    {
        static int amount;
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Необходимо указать путь к исходному и целевому каталогам.");
                return;
            }

            string sourceDirectory = args[0];
            string targetDirectory = args[1];

            if (!Directory.Exists(sourceDirectory))
            {
                Console.WriteLine("Исходный каталог не существует.");
                return;
            }

            if (!Directory.Exists(targetDirectory))
            {
                Console.WriteLine("Целевой каталог не существует.");
                return;
            }

            TaskQueue taskQueue = new TaskQueue(Environment.ProcessorCount);

            CopyDirectory(sourceDirectory, targetDirectory, taskQueue);

            taskQueue.Complete();
            taskQueue.WaitAll();

            Console.WriteLine($"Всего скопировано файлов: {amount}");
        }

        static void CopyDirectory(string sourceDirectory, string targetDirectory, TaskQueue taskQueue)
        {
            Directory.CreateDirectory(targetDirectory);

            string[] files = Directory.GetFiles(sourceDirectory);
            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                string targetFilePath = Path.Combine(targetDirectory, fileName);

                amount++;
                taskQueue.EnqueueTask(() =>
                {
                    File.Copy(file, targetFilePath, true);
                    Console.WriteLine($"Скопирован файл: {fileName}");
                });
            }

            string[] subDirectories = Directory.GetDirectories(sourceDirectory);
            foreach (string subDirectory in subDirectories)
            {
                string directoryName = Path.GetFileName(subDirectory);
                string targetSubDirectory = Path.Combine(targetDirectory, directoryName);
                CopyDirectory(subDirectory, targetSubDirectory, taskQueue);
            }
        }
    }
}