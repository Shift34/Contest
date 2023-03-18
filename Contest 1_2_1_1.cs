Дима обнаружил у папы на столе специальный чертежный прибор, похожий на циркуль-измеритель.
Измеритель отличается от обычного циркуля тем, что в обеих его ножках находятся иголки (у обычного циркуля в одной ножке находится иголка, а в другой – грифель).

Кроме измерителя Дима нашел на столе клетчатый лист бумаги, в углах некоторых клеток которого были нарисованы точки. 
Так как измеритель служит для измерения расстояний, то Дима решил измерить все попарные расстояния между всеми точками на листе бумаги.

Ваша задача - написать программу, которая по координатам точек определит, сколько различных расстояний встречается среди расстояний, которые измерил Дима.

Формат ввода
Первая строка входного файла INPUT.TXT содержит число n – количество точек (2 ≤ n ≤ 106). Следующие n строк содержат по два целых числа – координаты точек. 
Координаты не превышают 104 по абсолютной величине.

Формат вывода
На первой строке выходного файла OUTPUT.TXT выведите k – количество различных расстояний, которые измерил Дима. 
Следующие k строк должны содержать по одному вещественному числу – сами расстояния. Расстояния должны быть выведены в возрастающем порядке. 
Каждое число должно быть выведено с точностью не менее чем 1012.





using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp114
{
    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> spisok = new HashSet<int>(); 
            int n = int.Parse(Console.ReadLine());
            Point[] hh = new Point[n];
            int f = 0;
            for (int j = 0; j < n; j++)
            {
                string[] kk = Console.ReadLine().Split();
                hh[f].X = int.Parse(kk[0]);
                hh[f].Y = int.Parse(kk[1]);
                f++;
            }
            for (int i = 0; i < n-1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    int x = hh[j].X - hh[i].X;
                    int y = hh[j].Y - hh[i].Y;
                    int z = x * x + y * y;
                    spisok.Add (z);
                }
            }
            Console.WriteLine(spisok.Count);
            List<int> ll = spisok.ToList<int>();
            ll.Sort();
            foreach (int item in ll)
            {
                Console.WriteLine(Math.Sqrt(item));
            }
        }
    }
}


