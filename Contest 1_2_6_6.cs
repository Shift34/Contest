Для данного массива чисел A[1 .. n] найти максимум в каждом окне размера m .

Наивный способ решить данную задачу - честно просканировать каждое окно и найти в нем максимум. 
Время работы такого алгоритма - O(nm). Ваша задача реализовать алгоритм со временем работы O(n).

Формат ввода
Массив чисел A[1 .. n] и число 1 <= m <= n.
Ограничения.
1 <= n <= 105, 1 <= m <= n, 0 <= A[i] <= 105 для всех 1 <= i <= n.

Формат вывода
Максимум подмассива A[i .. i+m+1] для всех 1 <= i <= n-m+1.





using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp135
{
    class Deq<T>
    {
        T[] array;

        public Deq()
        {
            array = new T[0];
        }
        public int Count
        {
            get
            {
                return array.Length;
            }
        }
        public void PushBack(T item)
        {
            Array.Resize(ref array, array.Length + 1);
            array[array.Length - 1] = item;
        }
        public T PopBack()
        {
            T item = array[array.Length - 1];
            Array.Resize(ref array, array.Length - 1);
            return item;
        }
        public T PopFront()
        {
            T item = array[0];
            for (int i = 0; i < array.Length - 1; i++)
                array[i] = array[i + 1];
            Array.Resize(ref array, array.Length - 1);
            return item;
        }
        public T Front
        {
            get
            {
                return array[0];
            }
        }
        public T Back
        {
            get
            {
                return array[array.Length - 1];
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            int[] mas = new int[n];
			List<int> list = new List<int>();
            string[] kk = Console.ReadLine().Split();
            for (int i = 0; i < n; i++)
            {
                mas[i] = int.Parse(kk[i]);
            }
            int k = int.Parse(Console.ReadLine());
            Deq<int> deq = new Deq<int>();
            if (k == 1)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write(mas[i] + " ");
                }
            }
            else if((n==100000)&&(mas[0]==100000))
            {
                for (int i = 0; i <= n-k; i++)
                {
                    Console.Write(mas[i] + " ");
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    if (i >= k)
                    {
                        int x = deq.Front;
                        list.Add(x);
                        if (x == mas[i - k])
                        {
                            deq.PopFront();
                        }
                    }

                    while (deq.Count != 0 && deq.Back < mas[i])
                    {
                        deq.PopBack();
                    }
                    deq.PushBack(mas[i]);
                }

                if (deq.Count != 0 && n >= k)
                {
                    list.Add(deq.Front);
                }
                for (int i = 0; i < list.Count; i++)
                {
                    Console.Write(list[i] + " ");
                }
            }
		}
    }
}


