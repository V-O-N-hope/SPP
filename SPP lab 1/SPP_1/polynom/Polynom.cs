using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SPP_1.polynom
{
    public class Polynom
    {
        private readonly byte[] coefs;
        
        public Polynom(byte[] arr)
        {
            coefs = new byte[arr.Length];
            arr.CopyTo(coefs, 0);
        }

        public int calc(byte b)
        {
            int res = 0;
            for (int i = 0; i < coefs.Length; i++)
            {
                res += coefs[i] * (int)Math.Pow(b, i);
            }
            return res;
        }

        public static Polynom operator +(Polynom a, Polynom b)
        {
            int length = a.coefs.Length > b.coefs.Length ? a.coefs.Length : b.coefs.Length;
            byte[] arr = new byte[length];

            for (int i = 0; i < a.coefs.Length; i++)
            {
                arr[i] = a.coefs[i];
            }

            for (int i = 0; i < a.coefs.Length; i++)
            {
                arr[i] += b.coefs[i];
            }

            return new Polynom(arr);
        }

        public static Polynom operator -(Polynom a, Polynom b)
        {
            int length = a.coefs.Length > b.coefs.Length ? a.coefs.Length : b.coefs.Length;
            byte[] arr = new byte[length];

            for (int i = 0; i < a.coefs.Length; i++)
            {
                arr[i] = a.coefs[i];
            }


            for (int i = 0; i < a.coefs.Length; i++)
            {
                arr[i] -= b.coefs[i];
            }

            return new Polynom(arr);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < coefs.Length; i++)
            {
                if (coefs[i] != 0)
                {
                    sb.Append("(" + coefs[i] +")x^(" + i + ") + ");
                }
            }

            sb.Remove(sb.ToString().Length - 2, 2);

            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !GetType().Equals(obj.GetType()))
            {
                return false;
            }

            Polynom other = (Polynom)obj;

            if (coefs.Length != other.coefs.Length)
            {
                return false;
            }

            for (int i = 0; i < coefs.Length; i++)
            {
                if (coefs[i] != other.coefs[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            foreach (byte coef in coefs)
            {
                hash = hash * 31 + coef.GetHashCode();
            }
            return hash;
        }
    }
}
