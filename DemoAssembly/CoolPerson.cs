using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAssembly
{
    public class CoolPerson : Person
    {
        public bool isRich;
        private bool isSingle;

        public CoolPerson(string name, int age) : base(name, age)
        {

        }
    }
}