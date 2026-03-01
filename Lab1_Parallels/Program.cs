using Lab1_Parallels;
using System;
namespace Lav
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Random rnd = new();
            Controller controller = new(n);
            Func<int,double, Controller, double> f = (i, p,  c) =>
            {
                double result = 0;
                int count = 0;
                while (!c[i-1])
                {
                    result += p;
                    count++;
                }
                Console.WriteLine($"Thread with number {i} and step {p}" +
                    $" executed with result {result} and count of additions {count}");
                return 0;
            };
            for (int i = 1; i <= n; i++)
            {
                int localI = i;
                new Thread(() => f(localI, rnd.NextDouble(),controller)).Start();
            }
            new Thread(()=>controller.Start()).Start();
        }
    }
}