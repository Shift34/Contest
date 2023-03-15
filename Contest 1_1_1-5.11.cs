Маленький Вася недавно получил в подарок от старшего брата набор юного строителя. 
Этот набор состоит из нескольких деревянных брусков, для каждого из которых известна его длина. Бруски можно класть сверху один на другой, если длины брусков совпадают.

Вася хочет соорудить из всех брусков минимальное количество башенок. Помогите Васе расположить бруски оптимальным образом.

Формат ввода
В первой строке записано целое число N (1 ≤ N ≤ 1000) — количество брусков, имеющихся в распоряжении у Васи. 
Во второй строке через пробел записано N целых чисел li — длины брусков. Все длины — натуральные числа, не превосходящие 1000.

Формат вывода
В одной строке выведите два числа — высоту наибольшей из башен и их общее количество. Помните, что Вася должен использовать все бруски.


using System;

namespace ConsoleApp67
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] l = new int[n];
            int i = 0;
            int max = 0;
            int count = 0;
            int ita = 1;
            string[] kk = Console.ReadLine().Split();
            for (int y = 0; y < n; y++)
            {
                l[y] = int.Parse(kk[y]);
            }
            Array.Sort(l);
            while ( i < n )
            {
                ita = 1;
                if (i + 1 < n) 
                    while ((i + 1 < n)&&(l[i] == l[i + 1]))
                    {
                        ita += 1;
                        i++;
                    }
                count += 1;
                if (max < ita) max = ita;
                i++;
            }
            Console.WriteLine("{0} {1}", max, count);
            Console.ReadKey();

        }
    }
}