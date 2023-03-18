Ваша цель - реализовать симулятор обработки сетевых пакетов. 
Для i-го пакета известно время его поступления arrivali, а также время durationi, необходимое на его обработку. 
В вашем распоряжении имеется один процессор, который обрабатывает задачи в порядке их поступления. 
Если процессор начинает орбабатывать пакет i(что занимает время durationi), он не прерывается и не останавливается до тех пор, пока не обработает пакет.
У компьютера. обрабатывающего пакеты, имеется сетевой буфер размера size. 
До начала обработки пакеты хранятся в буфере. 
Если буфер полностью заполнен в момент поступления пакета (есть size пакетов, поступивших ранее, которые до сих пор не обработаны), этот пакет отбрасывается и уже не будет обработан. 
Если несколько пакетов поступают в одно и то же время, они все будут сперва сохранены в буфер(несколько последних из них могут быть отброшены, если буфер заполниться).
Компьютер обрабатывает пакеты в порядке их поступления. Он начинает обрабатывать следующий пакет из буфера сразу после того, как обработает текущий пакет. 
Компьютер может простаивать, если все пакеты уже обработаны и в буфере нет пакетов. Пакет освобождает место в буфере сразу же, как компьютер заканчивает обработку.

Формат ввода
Первая строка входа содержит размер буфера size и число пакетов n. 
Каждая из следующих строк содержит два числа: время arrivali, прибытия i-ого пакета и время durationi, необходимое на его обработку. 
Гарантируется, что arrival1 <= arrival2 <= ... <= arrivaln. При это может оказаться, что arrivali-1 = arrivali. 
В таком случае считаем, что пакет i-1 поступил раньше пакета i.
Ограничения.
Все числа на входе целые.
1 <= size <= 105; 1 <= n <= 105; 0 <= arrivali <= 106; 0 <= durationi <= 103; arrivali <= arrivali+1 для всех 1 <= i <= n - 1.

Формат вывода
Для каждого из n пакетов выведите время, когда процессор начал его обрабатывать, или -1, если пакет был отброшен.




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp134
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();
            List<int> list = new List<int>();
            int x = 0;
            string[] hh = Console.ReadLine().Split();
            int size = int.Parse(hh[0]);
            int n = int.Parse(hh[1]);
            for (int i = 0; i < n; i++)
            {
                string[] hh1 = Console.ReadLine().Split();
                int bremyprinytya = int.Parse(hh1[0]);
                int bremynaobrabotky = int.Parse(hh1[1]);
                if (queue.Count < size)
                {
                    if (queue.Count == 0)
                    {
                        queue.Enqueue(bremynaobrabotky + bremyprinytya + x);
                        list.Add(bremyprinytya);
                        x = bremynaobrabotky + bremyprinytya + x;
                    }
                    else
                    {
                        if (bremyprinytya >= x)
                        {
                            queue.Enqueue(bremynaobrabotky + bremyprinytya);
                            list.Add(bremyprinytya);
                            x = bremynaobrabotky + bremyprinytya;
                        }
                        else
                        {
                            queue.Enqueue(bremynaobrabotky + x);
                            list.Add(x);
                            x = bremynaobrabotky + x;
                        }
                    }
                }
                else
                {
                    if (bremyprinytya >= queue.Peek())
                    {
                        queue.Dequeue();
                        if (bremyprinytya >= x)
                        {
                            queue.Enqueue(bremynaobrabotky + bremyprinytya);
                            list.Add(bremyprinytya);
                            x = bremynaobrabotky + bremyprinytya;
                        }
                        else
                        {
                            queue.Enqueue(bremynaobrabotky + x);
                            list.Add(x);
                            x = bremynaobrabotky + x;
                        }
                    }
                    else
                    {
                        list.Add(-1);
                    }
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
    }
}

