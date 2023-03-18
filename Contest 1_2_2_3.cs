«Одна голова хорошо, а две лучше. Одна лампочка хорошо, а две лучше!» - подумал Миша, и решил собрать фонарик с двумя лампочками. 
Теперь он хочет узнать, насколько фонарик с двумя лампочками лучше, чем фонарик с одной. Для этого Миша посветил фонариком на стену, и каждая из лампочек осветила на ней круг.

Эффективность фонарика Миша хочет оценить через площадь освещенной части стены. 
Миша догадался измерить координаты центров освещенных кругов и их радиусы (которые оказались одинаковыми). 
Причем, площадь, освещаемая фонариком с одной лампочкой известна, т.к. описана в документации, прилагаемой к фонарику. Но что делать дальше он не знает. 
Напишите программу, которая поможет Мише.

Формат ввода
В первых двух строчках входного файла INPUT.TXT содержатся координаты (x1,y1) и (x2,y2) - центры кругов от лампочек собранного Мишей фонарика. 
В третьей строке задан радиус r описанных выше кругов, а четвертая строка содержит площадь освещения s фонариком из одной лампочки. 
Все числа целые и удовлетворяют следующим ограничениям: 1 ≤ x1,y1,x2,y2,r ≤ 100, 1 ≤ s ≤ 105. 
Так же заметим, что площади, освещаемые разными фонариками, отличаются друг от друга более чем на 10-3.

Формат вывода
В выходной файл OUTPUT.TXT выведите «YES», если Мишин фонарик лучше старого (т.е. освещает большую площадь) и «NO» в противном случае.





using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp118
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] ii = Console.ReadLine().Split();
            int x1 = int.Parse(ii[0]);
            int y1 = int.Parse(ii[1]);
            String[] ii1 = Console.ReadLine().Split();
            int x2 = int.Parse(ii1[0]);
            int y2 = int.Parse(ii1[1]);
            int r = int.Parse(Console.ReadLine());
            int s = int.Parse(Console.ReadLine());
            double dist= Math.Sqrt(Math.Pow(x1 - x2,2) + Math.Pow(y1 - y2,2));
            if (dist >= 2 * r)
            {
                if (Math.PI * Math.Pow(r, 2) * 2 > s) Console.WriteLine("YES");
                else Console.WriteLine("NO");
            }
            else if (dist <= Math.Abs(r-r))
            {
                if (Math.PI * Math.Pow(r, 2) > s) Console.WriteLine("YES");
                else Console.WriteLine("NO");
            }
            else
            {
                double T1 = 2 * Math.Acos(Math.Pow(dist, 2) / (2 * r * dist));
                double h = (Math.Pow(r, 2) * (T1 - Math.Sin(T1)));
                if (Math.PI * Math.Pow(r, 2) * 2-h > s) Console.WriteLine("YES");
                else Console.WriteLine("NO");
            }
        }
    }
}
