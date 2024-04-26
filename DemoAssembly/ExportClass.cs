using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAssembly
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ExportClass : Attribute
    {
    }
}