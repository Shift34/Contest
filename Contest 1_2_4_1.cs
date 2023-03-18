Дано целое число 
1
≤
n
≤
1
0
3
 и массив 
A
[
1
…
n
]
 натуральных чисел, не превосходящих 
2
⋅
1
0
9
.
Выведите максимальное 
1
≤
k
≤
n
, для которого найдётся подпоследовательность 
1
≤
i
1
<
i
2
<
…
<
i
k
≤
n
 длины 
k
, в которой каждый элемент делится на предыдущий (формально: для всех 
1
≤
j
<
k
, 
A
[
i
j
]
∣
∣
A
[
i
j
+
1
]
).
Задача из курса «Алгоритмы: теория и практика. Методы»: https://stepik.org/course/217/syllabus

Пример 1
Ввод	Вывод
4
3 6 7 12
3
Пример 2
Ввод	Вывод
10
1 1 1 1 1 1 1 1 1 1
10
Примечания
Для первого примера 
i
1
=1, 
i
2
=2, 
i
3
=4. В это случае 
A
[
1
]
 делит 
A
[
2
]
 (3 | 6), а 
A
[
2
]
 делит 
A
[
4
]
 (6 | 12).
 
 
 
 
 
 
 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp127
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] yy = new int[n];
            string[] pp = Console.ReadLine().Split();
            for (int i = 0; i < n; i++)
            {
                yy[i] = int.Parse(pp[i]);
            }
            int[] yy1 = new int[n];
            for (int i = 0; i < n; i++)
            {
                yy1[i] = 1;
                for (int j = 0; j < i; j++)
                {
                    if ((yy[i] % yy[j] == 0) && (yy1[j] + 1 > yy1[i]))
                    {
                        yy1[i] = yy1[j] + 1;
                    }
                }
            }
            Console.WriteLine(yy1.Max());
        }
    }
}
