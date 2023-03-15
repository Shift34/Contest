Формат ввода
В первой строке записано целое число n (2 ≤ n ≤ 100) — количество первокурсников. Далее следуют описания данных о их росте первокурсников, в том порядке, в котором они стоят. 
Первокурсники стоят покругу. Первокурсники задаются величинами своего роста — через пробел записаны n целых чисел a1, a2, ..., an (1 ≤ ai ≤ 1000).

Формат вывода
Выведите два целых числа — номера соседних первокурсников, которых нужно отправить в разведку. 
Если оптимальных решений несколько, выведите то, в котором сумма номеров минимальна, если и таких решений несколько, то выведите решение в котором номер одного из первокурсников минимален. 
Учтите, что первокурсники стоят по кругу.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gty
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int min = 1110;
            int first = 0;
            int last = 0;
            int i = 0;
            int f = 1;
            int[] ff = new int[n];
            string[] kk = Console.ReadLine().Split();
            while(i<n)
            {
                ff[i] = int.Parse(kk[i]);
                i += 1;
            }
            while (f < n)
            {
                if (Math.Abs(ff[f] - ff[f - 1]) < min)
                {
                    if (min != 89998)
                    {
                        min = Math.Abs(ff[f] - ff[f - 1]);
                        first = f;
                        last = f + 1;
                    }
                    else break;               
                }
                else if (Math.Abs(ff[0] - ff[n - 1]) < min)
                {
                    if (min != 9995)
                    {
                        min = Math.Abs(ff[0] - ff[n - 1]);
                        first = 1; last = n;
                    }
                    else break;
                }
                f += 1;
            }
            Console.WriteLine("{0} {1}",first,last);
            Console.ReadKey();
        }
    }
}
