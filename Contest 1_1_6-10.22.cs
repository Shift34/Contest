Дан набор из 
n
 слов. Сгруппируйте их по первой букве.
Формат ввода
В первой строке входных данных записано одно целое число 
n
 (
1
≤
n
≤
1
0
0
) — количество слов.
Далее в 
n
 строках записано по одному слову. Слова содержат только маленькие буквы латинского алфавита. Все слова различны. Длина слов не превосходит 20 символов.

Формат вывода
Выведите в первой строке число 
k
 — количество групп.
Далее выведите 
k
 строк. В каждой из этих строк выведите слова, которые попали в одну группу. Слова в строках должны быть разделены пробелами.
Слова в строках должны быть упорядочены лексикографически. Группы необходимо выводить в алфавитном порядке.






using System;
using System.IO;

namespace ConsoleApp95
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] filename = File.ReadAllLines("input.txt");
            int h = int.Parse(filename[0]);
            int p = 1;
            int count = 1;
            string[] y = new string[h];
            for (int i = 0; i < h; i++)
            {
                y[i] = filename[p];
                p++;
            }
            Array.Sort(y);
            for (int i = 1; i < h; i++)
            {
                if (y[i][0] == y[i - 1][0]) continue;
                else count += 1;
            }
            Console.WriteLine(count);
            for (int i = 1; i < h; i++)
            {
                if (y[i - 1][0] == y[i][0])
                {
                    Console.Write(y[i-1]);
                    Console.Write(" ");
                }
                else Console.WriteLine(y[i-1]);
            }
            if (h >= 2)
            {
                if (y[h - 1][0] == y[h - 2][0]) Console.Write(y[h - 1]);
                else Console.WriteLine(y[h - 1]);
            }
            if (h == 1) Console.WriteLine(y[0]);
        }
    }
}


