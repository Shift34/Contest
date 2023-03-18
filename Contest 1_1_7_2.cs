Дядюшка Скрудж МакДак уже стар, он разучился считать, но также как и раньше, он любит купаться в своем золотохранилище и при каждом возможном случае стремится его пополнить. 
В обмен на одну из его земель братья Гавс предложили ему выбрать одну из трех куч с золотыми монетами. 
Скруджу хочется получить наибольшее количество золотых монет. Помогите дядюшке сделать правильный выбор!

Формат ввода
В первой строке входного файла INPUT.TXT записаны три натуральных числа через пробел. Каждое из чисел не превышает 10100. Числа записаны без ведущих нулей.

Формат вывода
В выходной файл OUTPUT.TXT нужно вывести одно целое число — максимальное количество монет, которые может получить Скрудж МакДак.




using System;
using System.IO;

namespace ConsoleApp77
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] filename = File.ReadAllLines("input.txt");
            string h = filename[0];
            string[] s_arr = h.Split();
            string x1 = s_arr[0];
            string x2 = s_arr[1];
            string x3 = s_arr[2];
            string max ="0";
            int max1 = 0;
            int w = 0;
            int a = x1.Length;
            int b = x2.Length;
            int c = x3.Length;
            if (a > b)
            { max = x1; max1 = a; }
            else if (a < b)
            { max = x2; max1 = b; }
            else
            {
                while (a > w)
                {
                    int result1 = Convert.ToInt32(x1[w]);
                    int result2 = Convert.ToInt32(x2[w]);
                    if (result1 > result2)
                    {
                        max = x1;
                        max1 = a;
                        break;
                    }
                    if (result1 < result2)
                    {
                        max = x2;
                        max1 = b;
                        break;
                    }
                    w += 1;
                }
            }
            if (c > max1) { max = x3; max1 = c; }
                else if (max1==c)
                {
                    w = 0;
                    while (max1 > w)
                    {
                        int result2 = Convert.ToInt32(max[w]);
                        int result3 = Convert.ToInt32(x3[w]);
                        if (result2 > result3)
                        {
                            break;
                        }
                        if (result2 < result3)
                        {
                            max = x3;
                            max1 = c;
                            break;
                        }
                    w += 1;
                    }
                }
                
            using (StreamWriter sw = new StreamWriter("output.txt", false))
            {
                sw.Write(max);
            }
            Console.ReadKey();
        }
    }
}
