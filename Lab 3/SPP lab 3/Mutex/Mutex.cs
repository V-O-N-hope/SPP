using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mutex
{
    public class Mutex
    {
        private Thread? _thread = null;
        public void Lock()
        {
            Thread t = Thread.CurrentThread;
            while (Interlocked.CompareExchange(ref _thread, t, null) != null)
                Thread.Yield();
            // Thread.MemoryBarrier();
        }

        public void Unlock()
        {
            Thread t = Thread.CurrentThread;
            if (Interlocked.CompareExchange(ref _thread, null, t) != t)
                throw new SynchronizationLockException();
            // Thread.MemoryBarrier();
        }
    }

}