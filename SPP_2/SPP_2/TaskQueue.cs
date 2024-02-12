using System;
using System.Collections.Generic;
using System.Threading;

public delegate void TaskDelegate();

public class TaskQueue
{
    private Queue<TaskDelegate> taskQueue;
    private List<Thread> threadPool;
    private bool isStopped;
   
    public TaskQueue(int numThreads)
    {
        taskQueue = new Queue<TaskDelegate>();
        threadPool = new List<Thread>();
        isStopped = false;

        // Создание и запуск потоков пула
        for (int i = 0; i < numThreads; i++)
        {
            Thread thread = new Thread(Worker);
            thread.Start();
            threadPool.Add(thread);
        }
    }

    public void EnqueueTask(TaskDelegate task)
    {
        lock (taskQueue)
        {
            taskQueue.Enqueue(task);
            Monitor.Pulse(taskQueue); // Разбудить потоки, если они ждут новых задач
        }
    }

    public void Complete()
    {
        lock (taskQueue)
        {
            isStopped = true;
            Monitor.PulseAll(taskQueue); // Разбудить все потоки, чтобы они вышли из ожидания
        }
    }

    public void WaitAll()
    {
        foreach (Thread thread in threadPool)
        {
            thread.Join(); // Дождаться завершения всех потоков
        }
    }

    private void Worker()
    {
        while (true)
        {
            TaskDelegate task;

            lock (taskQueue)
            {
                while (taskQueue.Count == 0 && !isStopped)
                {
                    Monitor.Wait(taskQueue); // Ожидание новой задачи или завершения работы
                }

                if (isStopped && taskQueue.Count == 0)
                {
                    return; // Поток завершает работу, если пул остановлен и очередь задач пуста
                }

                task = taskQueue.Dequeue();
            }

            task.Invoke(); // Выполнение задачи
        }
    }
}