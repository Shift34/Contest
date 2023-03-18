Хороший охотник убивает двух зайцев одним выстрелом. Конечно же это может быть легко сделано, поскольку через любые две точки можно провести прямую. 
Но убить трёх и более зайцев одним выстрелом — намного более сложная задача. 
Чтобы стать лучшим охотником в мире, нужно уметь убить максимально возможное количество зайцев. Представим зайца точкой на плоскости. 
Точка задаётся целочисленными координатами x и y. 
Вам нужно найти максимальное число зайцев, которые могут быть убиты одним выстрелом, то есть максимальное количество точек заданного множества, лежащих точно на одной прямой. 
Никакие два зайца не находятся в одной точке.

Ваша программа обязательно должна иметь класс прямая, класс точка. В классе прямая должен быть метод проверки принадлежности точки прямой.

Формат ввода
Первая строка ввода содержит целое число N (3 ≤ N ≤ 200) — количество зайцев. 
Каждая из следующих N строк содержит x и y координаты (в таком порядке), разделённые пробелом (−2000 ≤ x, y ≤ 2000).

Формат вывода
Выведите максимальное число зайцев, находящихся на одной прямой.






using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16
{
    class Point
    {
        public int x;
        public int y;
        public Point(int x, int y) { this.x = x; this.y = y; }
    }
    class Straight
    {
        public int count = 2;
        public Point Point1;
        public Point Point2;
        public Straight(Point point1, Point point2)
        {
            this.Point1 = point1;
            this.Point2 = point2;
        }
        public void PointOnALine(Point point3)
        {
            if (point3.x * (this.Point2.y - this.Point1.y) - point3.y * (this.Point2.x - this.Point1.x) == this.Point1.x * this.Point2.y - this.Point2.x * this.Point1.y) count++; 
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Point[] point = new Point[n];
            int count = 2;
            int h = -1;
            List<Straight>list = new List<Straight>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                point[i] = new Point(int.Parse(input[0]), int.Parse(input[1]));
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    list.Add(new Straight(point[i], point[j]));
                    h++;
                    for (int z = j + 1; z < n; z++)
                    {
                        list[h].PointOnALine(point[z]);
                    }
                }
            }
            foreach(Straight s in list)
            {
                if (s.count > count) count = s.count;
            }
            Console.WriteLine(count);
        }
    }
}


