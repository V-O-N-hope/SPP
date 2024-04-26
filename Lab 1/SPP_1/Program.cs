using SPP_1.polynom;

namespace SPP_1
{
    public static class Program
    {
        
        static void Main(string[] args)
        {
            byte[] degrees = { 1, 2, 0, 4 };
            byte[] degrees2 = { 1, 2, 0, 2 };

            Polynom polynom = new Polynom(degrees);
            Polynom polynom2 = new Polynom(degrees2);

            var sum = (polynom - polynom2) + (polynom - polynom2);
            int res = sum.calc(5);
            Console.WriteLine(sum.ToString());
            Console.WriteLine(res);
        }
    }
}
