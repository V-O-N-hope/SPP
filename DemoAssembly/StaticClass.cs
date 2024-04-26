using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAssembly
{
    [ExportClass]
    public static class StaticClass
    {
        public static int binding;

        private static int noView;
    }
}