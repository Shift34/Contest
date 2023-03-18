У председателя профбюро матфака очень большой кабинет, в котором кроме него работают и его заместители руководители различных направлений. 
У каждого заместителя, как и у председателя профбюро, есть свой стол уникального цвета. 
Каждый стол представляет собой прямоугольник, стороны которого параллельны стенам кабинета. 
В один прекрасный день председатель профбюро решил учредить собрание, в которое будут входить все его заместители. 
К сожалению, председатель профбюро не помнит их количества, однако помнит, что стол каждого заместителя находится рядом с его столом, то есть имеет общую сторону ненулевой длины.

План кабинета председателя профбюро представляет собой матрицу из n строк и m столбцов. Каждая клетка плана либо пуста, либо содержит часть стола. 
Цвет стола задается прописной буквой латинского алфавита, которая обозначает цвет. Пустая клетка обозначается символом «точка» («.»).

Формат ввода
В первой строке содержатся два разделенных пробелом целых числа n, m (1 ≤ n, m ≤ 100) — длина и ширина комнаты председателя профбюро, и символ c — цвет стола председателя. 
В следующих n строках находятся по m символов — описание комнаты. 
Гарантируется, что цвет каждого стола уникален, и каждый стол представляет собой сплошной подпрямоугольник заданной матрицы. 
Все цвета обозначаются прописными буквами латинского алфавита.

Формат вывода
Выведите единственное число — количество заместителей председателей.




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp91
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] filename = File.ReadAllLines("input.txt");
            string h = filename[0];
            int count = 0;
            int w= 0;
            string[] s_arr = h.Split();
            int k = int.Parse(s_arr[0]); 
            int m = int.Parse(s_arr[1]);
            string n = s_arr[2];
            char c = Convert.ToChar(n);
            char[] hh = new char[k * m];
            int p = 1;
            int zxc = 0;
            string[] y = new string[k];
            for (int i = 0; i < k; i++)
            {
                y[i] = filename[p];
                p++;
            }
            char[] massage = new char[m];
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (y[i][j] == c)
                    {
                        for (int u = 0; u < k; u++)
                        {
                            count = 0;
                            if (y[u][j] == '.') continue;
                            else if (u == i) continue;
                            else
                            {
                                for (int a = 0; a < m * k; a++)
                                {
                                    if (y[u][j] == c)
                                    {
                                        count += 1;
                                        break;
                                    }
                                    if (y[u][j] == hh[a])
                                    {
                                        count += 1;
                                        break;
                                    }
                                }
                                if (count == 0)
                                {
                                    if (u + 1 == i)
                                    {
                                        zxc += 1;
                                        hh[w] = y[u][j];
                                        w += 1;
                                    }
                                    if (u - 1 == i)
                                    {
                                        zxc += 1;
                                        hh[w] = y[u][j];
                                        w += 1;
                                    }
                                }
                            }
                        }
                        for (int u = 0; u < m; u++)
                        {
                            count = 0;
                            if (y[i][u] == '.') continue;
                            else if (u == j) continue;
                            else
                            {
                                for (int a = 0; a < m * k; a++)
                                {
                                    if (y[i][u] == c)
                                    {
                                        count += 1;
                                        break;
                                    }
                                    if (y[i][u] == hh[a])
                                    {
                                        count += 1;
                                        break;
                                    }
                                }
                                if (count == 0)
                                {
                                    if (u + 1 == j)
                                    {
                                        zxc += 1;
                                        hh[w] = y[i][u];
                                        w += 1;
                                    }
                                    if (u - 1 == j)
                                    {
                                        zxc += 1;
                                        hh[w] = y[i][u];
                                        w += 1;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            string myString = zxc.ToString();
            File.WriteAllText("output.txt", myString);
        }
    }
}


