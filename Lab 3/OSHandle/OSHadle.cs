using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace OSHandle
{

    public static class OSHadle
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool CloseHandle(IntPtr handle);

        public static bool myCloseHandle(ref IntPtr handle)
        {
            var res = CloseHandle(handle);
            if (res)
            {
                handle = IntPtr.Zero;
                Console.WriteLine("Was closed\n");
            }
            else
            {
                Console.WriteLine("Wasn`t closed\n");
            }

            return res;
        }

    }
}