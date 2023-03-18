Есть 
n
 предметов, 
i
-й предмет имеет стоимость 
c
i
 и объем 
w
i
.
Найдите максимальную суммарную стоимость частей предметов (от каждого предмета можно отделить любую часть 
p
 (
0
≤
p
≤
1
), стоимость и объём при этом пропорционально уменьшатся), помещающихся в данный рюкзак вместимостью 
W
.
Задача из курса «Алгоритмы: теория и практика. Методы»: https://stepik.org/course/217/syllabus

Формат ввода
Первая строка содержит количество предметов 
1
≤
n
≤
1
0
3
 и вместимость рюкзака 
1
≤
W
≤
2
0
0
0
0
0
0
. Каждая из следующих 
n
 строк задаёт стоимость 
0
≤
c
i
≤
2
0
0
0
0
0
0
 и объём 
1
≤
w
i
≤
2
⋅
1
0
6
 предмета 
n
, 
W
, 
c
i
, 
w
i
 — целые числа).
Формат вывода
Выведите максимальную стоимость частей предметов, помещающихся в данный рюкзак, с точностью не менее трёх знаков после запятой.





using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp123
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] hh = Console.ReadLine().Split();
            int s = int.Parse(hh[0]);
            double k = int.Parse(hh[1]);
            double[] pp = new double[s];
            double[] pp1 = new double[s];
            double[] pp2 = new double[s];
            for (int i = 0; i < s; i++)
            {
                string[] hh1 = Console.ReadLine().Split();
                pp[i] = double.Parse(hh1[0]);
                pp1[i] = double.Parse(hh1[1]);
                pp2[i] = pp[i] / pp1[i];
            }
            double temp;
            for (int i = 0; i < s; i++)
            {
                for (int j = i + 1; j < s; j++)
                {
                    if (pp2[i] > pp2[j])
                    {
                        temp = pp2[i];
                        pp2[i] = pp2[j];
                        pp2[j] = temp;
                        temp = pp[i];
                        pp[i] = pp[j];
                        pp[j] = temp;
                        temp = pp1[i];
                        pp1[i] = pp1[j];
                        pp1[j] = temp;
                    }
                }
            }
            int y = s-1;
            double max = 0;
            double h;
            while ((k != 0)&&(y!=-1))
            {
                if(k-pp1[y]>=0)
                {
                    max += pp[y];
                    k = k - pp1[y];
                }
                else
                {
                    h=k/pp1[y];
                    max += pp[y] * h;
                    k = 0;
                }
                y--;
            }
            Console.WriteLine(Math.Round(max, 3));
        }
    }
}
