Задано целое положительное целое число x. Найдите число способов представить его в виде суммы четырёх положительных целых чисел x = a + b + c + d, где a ≤ b ≤ c ≤ d.

Формат ввода
В первой строке входного файла содержится число x (1 ≤ x ≤ 1500)

Формат вывода
В выходной файл выведите ответ на задачу


using System;

namespace ConsoleApp11
{
    class Program
    {

        static void Main(string[] args)
        {
            int x = int.Parse(Console.ReadLine());
            int k = 0;
            for (int d = x-3; d>= 1; d--)
            if (d * 4 >= x)
            {
                for (int c = d; c>= 1; c--)
                if ((d + c < x) && (d + c * 3 >= x))
                { 
                    for (int b = c; b >= 1; b--)
                    if ((d + c + b < x) && (b * 2 + c + d >= x))
                    {
                    int a = x - (d + b + c);
                    if (a <= b) 
                    if (a + b + c + d == x)
                    k += 1;
                    }
                }
            }
            Console.WriteLine(k);
            Console.ReadKey();
        }
    }
}
