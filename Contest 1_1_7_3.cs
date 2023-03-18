Задана последовательность, состоящая только из символов ‘>’, ‘<’ и ‘-‘. Требуется найти количество стрел, которые спрятаны в этой последовательности. 
Стрелы – это подстроки вида "»-->" и "<--«".

Формат ввода
В первой строке дана строка, состоящая из символов ‘>’, ‘<’ и ‘-‘ (без пробелов).

Формат вывода
В единственную строку выходного файла output.txt или на консоль нужно вывести искомое количество стрелок.





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
            int h1 = h.Length;
            int max = 0;
            for (int i = 0; i <= h1 - 5; i++)
            {
                string t = h.Substring(i, 5);
                if (t == ">>-->" || t == "<--<<") max += 1;
            }
            using (StreamWriter sw = new StreamWriter("output.txt", false))
            {
                sw.Write(max);
            }
            Console.ReadKey();
        }
    }
}
