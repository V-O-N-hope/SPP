using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyParallel
{
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
                Monitor.Pulse(taskQueue);
            }
        }

        public void Complete()
        {
            lock (taskQueue)
            {
                isStopped = true;
                Monitor.PulseAll(taskQueue);
            }
        }

        public void WaitAll()
        {
            foreach (Thread thread in threadPool)
            {
                thread.Join();
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
                        Monitor.Wait(taskQueue); 
                    }

                    if (isStopped && taskQueue.Count == 0)
                    {
                        return;
                    }

                    task = taskQueue.Dequeue();
                }

                task.Invoke();
            }
        }
    }
}