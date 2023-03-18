Тетушка Марта решила испечь свой фирменный лимонный пирог. 
Она замесила тесто, выложила его в форму, положила начинку и - внезапный звонок по телефону от любимой подружки. 
Украсить пирог кружочками лимона и поставить в духовку тетушка Марта доверила своему племяннику Васе.

Когда пирог достали из духовки, тетушка Марта очень сильно огорчилась, ведь несколько кружочков лимона попало на корку пирога!!!
Пирог представляет собой круг радиуса r, с центром в начале координат. 
Пирог состоит из основной части — круга радиуса r - d с центром в начале координат, и корки вокруг основной части ширины d. 
Ломтики лимона тоже представляют собой круги. Радиус i-го ломтика лимона равен ri, а центр задается в виде пары(xi, yi).

Тетушка Марта просит вас помочь определить количество ломтиков лимона, попавших на корку. Ломтик лимона попал на корку, если он полностью лежит на корке.

Внимание!!! Наличие класса, описывающего пирог, с методом проверки попадания обязательно!!! Или класса окружность.

Формат ввода
Первая строка содержит два целых числа r и d (0 ≤ d < r ≤ 500), обозначающие радиус пирога и толщину корки соответственно.

Следующая строка содержит одно целое число n (1 ≤ n ≤ 105), обозначающее количество ломтиков лимона.

Следующие n строк содержат по три целых числа xi, yi и ri ( - 500 ≤ xi, yi ≤ 500, 0 ≤ ri ≤ 500), где xi и yi — координаты центра i-го ломтика лимона, ri — радиус i-го ломтика лимона.

Формат вывода
Выведите количество ломтиков лимона, попавших на корочку.







using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    class Pie
    {
        public int r;
        public int d;
        public Pie(int r, int d)
        {
            this.r = r;
            this.d = d;
        }
        public int Examination(Circle circle)
        {
            if (Range(circle.x, circle.y + circle.r) & Range(circle.x, circle.y - circle.r) & Range(circle.x + circle.r, circle.y) & Range(circle.x - circle.r, circle.y) & Range(circle.x,circle.y)) return 1;
            else return 0;
        }
        public bool Range(int x,int y) 
        {
            if ((Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)) <= r) & ((Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2))) >= r - d)) return true;
            else return false;
        }

    }
    class Circle
    {
        public int x;
        public int y;
        public int r;
        public Circle(int x, int y,int r)
        {
            this.x = x;
            this.y = y;
            this.r = r;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split();
            Pie pie = new Pie(int.Parse(inputs[0]), int.Parse(inputs[1]));
            int n = int.Parse(Console.ReadLine());
            int k = 0;
            Circle[] circle = new Circle[n];
            for(int i = 0; i < n; i++)
            {
                string[] inputs1 = Console.ReadLine().Split();
                circle[i] = new Circle(int.Parse(inputs1[0]), int.Parse(inputs1[1]), int.Parse(inputs1[2]));
                k += pie.Examination(circle[i]);
            }
            Console.WriteLine(k);
        }
    }

}
