Расстояние Левенштейна (также редакционное расстояние или дистанция редактирования) между двумя строками в теории информации и компьютерной лингвистике — это минимальное количество операций вставки одного символа, удаления одного символа и замены одного символа на другой, необходимых для превращения одной строки в другую. 
Вычислите расстояние Левенштейна двух данных непустых строк длины не более 102.

Формат ввода
Две не пустые строки длины не более 102.

Формат вывода
Одно число - расстояние Левенштейна двух данных непустых строк.






using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp129
{
    class Program
    {
        static public int Chet(int i, int j, string h, string h1, int[,] mat)
        {
            if ((i == 0) && (j == 0))
                return 0;
            if ((i > 0) && (j == 0))
                return i;
            if ((j > 0) && (i == 0))
                return j;
            int x = i - 1;
            int y = j-1;
            int m = 0;
            if (h.Substring(x, 1) == h1.Substring(y, 1)) m = 0;
            else m = 1;
            int min = mat[i,j - 1] + 1;
            if (mat[i - 1,j] + 1 < min) min = mat[i - 1,j] + 1;
            if (mat[i - 1,j-1] + m < min) min = mat[i - 1,j-1] + m;
            return min;
        }

        static public int fg(string h, string h1)
        {
            int n = h.Length;
            int m = h1.Length;
            int[,] mat = new int[n + 1,m+1];
            {
                for(int i = 0; i < n+1; i++)
                {
                    for(int j = 0; j < m+1; j++)
                    {
                        mat[i,j] = Chet(i, j, h, h1, mat);
                    }
                }
                return mat[n,m];
            }
            
        }
        static void Main(string[] args)
        {
            string h = Console.ReadLine();
            string h1 = Console.ReadLine();
            Console.WriteLine(fg(h, h1));
        }
    }
}
