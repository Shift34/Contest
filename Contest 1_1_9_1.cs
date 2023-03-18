Петя изучает позиционные системы счисления. 
Он уже научился складывать и вычитать числа в системах счисления с различными основаниями и теперь перешел к более сложному действию — умножению.
Для того, чтобы умножать большие числа, нужно сначала выучить таблицу умножения. 
К сожалению, во втором классе (а некоторые даже в первом) учат только таблицу умножения десятичных чисел. 
Помогите Пете построить таблицу умножения для чисел в системе счисления с основанием k.

Формат ввода
В первой строке содержится единственное целое число k () — основание системы счисления.

Формат вывода
Выведите таблицу умножения для системы счисления с основанием k. Таблица должна содержать k - 1 строку и k - 1 столбец. 
Элемент на пересечении i-й строки и j-го столбца равен произведению чисел i и j в k-ичной системе счисления. 
Между числами в каждой строке может содержаться произвольное количество пробелов.




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp89
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] filename = File.ReadAllLines("input.txt");
            int k = Convert.ToInt32(filename[0]);
            using (StreamWriter sw = new StreamWriter("output.txt", false))
            {
                for (int i = 0; i < k - 1; i++)
                {
                    for (int j = 0; j < k - 1; j++)
                    {
                        int g = i + 1;
                        int g1 = j + 1;
                        if (i == 0) { sw.Write(g1); sw.Write(" "); }
                        else if (j == 0) { sw.Write(g); sw.Write(" "); }
                        else
                        {
                            int z = (g) * (g1);
                            while (z / k > 0)
                            {
                                int s = z / k;
                                sw.Write(s);
                                z = z - s * k;
                            }
                            sw.Write(z);
                            sw.Write(" ");
                        }
                    }
                    sw.WriteLine();
                }
            }
        }
    }
}

