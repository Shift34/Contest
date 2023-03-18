Студенты и преподаватели математического факультета очень любят столовую 7 корпуса. Там очень вкусно готовят и не дорого.
Так как посетителей много, в столовой часто образутся очень длинные очереди. 
А поскольку много посетителей в одном месте быстро образуют шумную толпу, которая мешает работникам столовой обслуживать посетителей, последние решили установить некоторые правила касательно порядка в очереди. 
Студенты при посещении столовой должны вставать в конец очереди. 
Преподаватели встают ровно в ее середину, причем при нечетной длине очереди они встают сразу за центром. 
Так как студенты также широко известны своим непочтительным отношением ко всяческим правилам и законам, сотрудники столовой попросили вас написать программу, которая бы отслеживала правильное расположение посетителей в очереди.

Формат ввода
В первой строке входных данный записано число N (1 ≤ N ≤ 106) - количество запросов к программе.
Следующие N строк содержат описание запросов в формате:
• "+ i" - студент с номером i (1 ≤ i ≤ N) встает в конец очереди.
• "* i" - преподаватель с номером i встает в середину очереди.
• "-" - первый посетитель из очереди обслуживается работниками столовой.
Гарантируется, что на момент такого запроса очередь не пуста.

Формат вывода
Для каждого запроса типа "-" программа должна вывести номер посетителя, который должен быть обслужен работниками столовой.





using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp133
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string z = null;
            string[] matrix = new string[n];
            Queue<string> list1 = new Queue<string>();
            List<string> list = new List<string>();
            int w = 0;
            int f = 0;
            for (int i = 0; i < n; i++)
            {
                string[] kk = Console.ReadLine().Split();
                char x = Convert.ToChar(kk[0]);
                if (x == '-')
                {
                    w++;
                }
                else if (x == '+')
                {
                    list1.Enqueue(kk[1]);
                }
                else 
                {
                    matrix[f] = kk[1];
                    f++;
                }
                if (list1.Count+f > list.Count-w)
                {
                    if (f > 0)
                    {
                        z = matrix[f - 1];
                        list.Add(z);
                        f--;
                    }
                    else
                    {
                        z = list1.Dequeue();
                        list.Add(z);
                    }
                }
            }
            for(int i = 0; i < w; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
    }
}
