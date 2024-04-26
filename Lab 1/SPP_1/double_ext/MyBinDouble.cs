using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPP_1.double_ext
{
    public class MyBinDouble
    {
        public byte sign;
        public byte[] exponent = new byte[11];
        public byte[] mantissa = new byte[52];

        public MyBinDouble(double number)
        {
            byte[] bitsMean = new byte[64];

            unsafe
            {
                ulong bits = 0;
                ulong signMask = 1UL << 63;
                ulong exponentMask = 0x7FFUL << 52;
                ulong mantissaMask = (1UL << 52) - 1;

                ulong* pBits = &bits;
                double* pNumber = &number;

                byte* pByteBits = (byte*)pBits;

                for (int i = 0; i < sizeof(double); i++)
                {
                    pByteBits[i] = ((byte*)pNumber)[i];
                }

                for (int i = 0; i < 64; i++)
                {
                    bitsMean[i] = (byte)((bits & signMask) != 0 ? 1 : 0);
                    bits <<= 1;
                }
            }

            sign = bitsMean[0];

            for (int i = 1; i < 12; i++)
            {
                exponent[i - 1] = bitsMean[i];
            }

            for (int i = 12; i < 64; i++)
            {
                mantissa[i - 12] = bitsMean[i];
            }
        }

        const string space = " ";

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(sign);

            sb.Append(space);
            for (int i = 0; i < 11; i++)
            {
                sb.Append(exponent[i]);
            }

            sb.Append(space);
            for (int i = 0; i < 52; i++)
            {
                sb.Append(mantissa[i]);
            }

            return sb.ToString();
        }
    }
}
