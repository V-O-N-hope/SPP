using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SPP_1.double_ext
{
    public static class DoubleToBinaryExt
    {
        public static string TobinaryExt(this double db)
        {
            MyBinDouble myBin = new MyBinDouble(db);

            return myBin.ToString();
        }
    }
}
