В 21021 году на известный математический факультет приняли всех желающих. 
Число студентов оказалось достаточно большим, хотя и не превосходило 10000. 
Поскольку в те дни царила абсолютная демократия, каждый студент мог выбрать любое количество дисциплин для изучения. 
Однако выяснилось, что можно сократить расходы на обучение. 
Для этого всех студентов, выбравших самое больше и самое маленькое число дисциплин, нужно убедить изучать среднее по факультету число дисциплин. 
Выведите измененный массив.

Формат ввода
В первой строке вводится число студентов N <= 10000. В следующих N строках - количество дисциплин для каждого студента <= 1000.

Формат вывода
Измененный массив с количеством дисциплин по студентам.


using System;

namespace ConsoleApp32
{
    class Program
    {
        private static int i;
        private static int k;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            int f = 0;
            int max = 0;
            int g = 0;
            int min = 99999;
            int k = 0;
            double guk = 0;
            for (int i=0;i<n;i++)
            {
                array[i] = int.Parse(Console.ReadLine());
                f += array[i];
                if (array[i] > max)
                {
                    max = array[i];
                }
                if (min> array[i])
                {
                    min = array[i];
                }
                int a = array[i];
                int b = array[i];
            }
            guk =(double) f / n;
            for (int i = 0; i < n; i++)
            {
                if (guk % 1 != 0)
                {
                    if (max == array[i])
                    {
                        if (array[i] > guk) array[i] = (int)Math.Ceiling(guk);
                        else array[i] = (int)guk;
                    }
                    else if (min == array[i])
                    {
                        if (array[i] > guk) array[i] = (int)Math.Ceiling(guk);
                        else array[i] = (int)guk;
                    }

                }
                if (guk % 1 == 0)
                {
                    if ((max == array[i])||(min == array[i]))
                    {
                        array[i] = (int)guk;
                    }
                }
            }
            for (int i=0; i<n;i++)
            {
                Console.WriteLine("{0}", array[i]);
            }
            Console.ReadKey();
        }

    }
}


