using System.Diagnostics;

namespace MyParallel
{
    public class ParallelWaiAll
    {
        //returns amount of ms that where needed 
        public static long wait(TaskDelegate[] tasks){
            TaskQueue taskQueue = new TaskQueue(Environment.ProcessorCount);

            Stopwatch sw = Stopwatch.StartNew();

            foreach (var task in tasks)
            {
                taskQueue.EnqueueTask(task);
            }

            taskQueue.Complete();
            taskQueue.WaitAll();

            sw.Stop();

            return sw.ElapsedMilliseconds;
        }
    }
}