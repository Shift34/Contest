Какой студент матфака не мечтает о мощном компьютере!!! 
Вася Простаков пошел выбирать себе новый компьютер, но тот, что с мощной видеокартой, SSD диском, быстрым процессором стоит 100 тысяч рублей. 
Расстроился Вася и стал жаловаться продавцу. А тот ему и говорит:"Тронули меня твои речи, Вася. Давай так. Бери компьютер. И заплати только за его клавиатуру. 
В рассрочку. В первый день - k копеек за 1ю клавишу, во второй - qk копейки, в третий - q2 k копеек за третью клавишу и т.д. пока за все клавиши на клавиатуре не заплатишь". 
Обрадовался Вася, отдал k копеек менеджеру и побежал с новым компьютером домой, скорей-скорей (в Doom играть) контест решать. 
Посчитайте, сколько Вася заплатит за новый компьютер, если на клавиатуре n клавиш. Не забудьте описать класс геометрическая прогрессия, объекты которого:

• отображали бы геометрическую прогрессию с заданным начальным членом и знаменателем;

• позволяли получить сумму начальных n-членов прогрессии.

Формат ввода
В файле в одной строке через пробел даны три числа q, k, n. q и k вещественные положительные числа, n - целое положительное число.

Формат вывода
Вывести одно число - сумму, которую заплатит Вася в РУБЛЯХ.






using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    class Progression
    {
        public double q;
        public double k;
        public int n;
        public double summa;
        public double lastnumber;
        public Progression(double q,double k, int n)
        {
            this.q = q;
            this.k = k;
            this.n = n;
        }
        public ulong Summa()
        {
            lastnumber = this.k;
            for(int i = 0; i <= this.n-1; i++)
            {
                summa += lastnumber;
                lastnumber *=q;
            }
            return (ulong)Math.Round(summa/100);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Progression progression = new Progression(double.Parse(input[0]), double.Parse(input[1]), int.Parse(input[2]));
            Console.WriteLine(progression.Summa());
        }
    }
}
