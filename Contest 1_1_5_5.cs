Дано кубическое уравнение a*x3 + b*x2 + c*x + d = 0. Известно, что у этого уравнения ровно один корень. Требуется его найти.

Формат ввода
Во входных данных через пробел записаны четыре целых числа: -1000 < a, b, c, d < 1000.

Формат вывода
Выведите единственный корень уравнения с точностью не менее 4 знаков после десятичной точки.


using System;

namespace ConsoleApp54
{
    class Program

    {
        static double f(double x,int a, int b, int c, int d)
        {
            return a * (x * x * x) + b * (x * x) + c * x + d;
        }
        static void Main(string[] args)
        {
            string[] kk = Console.ReadLine().Split();
            int a = int.Parse(kk[0]);
            int b = int.Parse(kk[1]);
            int c = int.Parse(kk[2]);
            int d = int.Parse(kk[3]);
            const double eps = 0.00001;
            double r = 1;
            double l = -r;
            while (f(r, a, b, c, d) * f(-r, a, b, c, d) >= 0)
            {
                r *= 2;
                l = -r;
            }
                while (r - l > eps)
                {
                    double cred = (l + r) / 2;
                    if (f(cred, a, b, c, d) * f(r, a, b, c, d) > 0) r = cred;
                    else l = cred;
                }
            Console.WriteLine("{0:f6}",l);
            Console.ReadKey();

        }
    }
}
