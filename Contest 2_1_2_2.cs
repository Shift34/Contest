Для создания сервиса бонусов была предложена следующая схема:
Выбирается целое число 
n
.
В помеченные ячейки матрицы 
n
×
n
 записываются 
n
 различных чисел от 
1
 до 
n
2
.
Остальные 
n
2
−
n
 ячеек остаются пустыми.
Пользователь получает бонус, если угадывает числа, расположенные в помеченных ячейках.
Для получения бонуса нужно заполнить матрицу 
n
×
n
 таким образом, чтобы все числа от 
1
 до 
n
2
 встречались ровно один раз, а во всех помеченных ячейках числа совпадали с выигрышным шаблоном.
Найдите любую выигрышную матрицу.

Формат ввода
В первой строке входных данных записано целое число 
n
 (
2
≤
n
≤
1
0
0
).
Далее в 
n
 строках записаны числа в матрице-шаблоне 
a
i
j
 (
0
≤
a
i
j
≤
n
2
).
Если 
a
i
j
=
0
, то соответствующая ячейка матрицы не является помеченной и должна быть заполнена. Если 
a
i
j
≠
0
, то в соответствующую ячейку матрицы нужно вписать 
a
i
j
.

Формат вывода
Выведите 
n
 строк по 
n
 целых чисел — любую из выигрышных матриц.
Гарантируется, что существует как минимум одна выигрышная матрица.








using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedSet<int> hashset = new SortedSet<int>();
            int n = int.Parse(Console.ReadLine());
            int k = 1;
            int[,] massiv = new int[n,n];
            for (int i = 0; i < n; i++)
            {
                string[] inputs = Console.ReadLine().Split();
                for (int j = 0; j < n; j++)
                {
                    massiv[i,j] = int.Parse(inputs[j]);
                    hashset.Add(int.Parse(inputs[j]));
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (massiv[i, j] == 0)
                    {
                        while (hashset.Contains(k))
                        {
                            k++;
                        }
                        massiv[i, j] = k;
                        hashset.Add(k);
                        k++;
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(massiv[i, j] + " "); 
                }
                Console.WriteLine();
            }
        }
    }
}
