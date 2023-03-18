Предприятие производит оптовую закупку некоторых изделий A и B, на которую выделена определённая сумма денег. 
У поставщика есть в наличии партии этих изделий различных модификаций по различной цене. 
На выделенные деньги необходимо приобрести как можно больше изделий одного из видов независимо от модификации. 
Если у поставщика закончатся изделия этого вида, то на оставшиеся деньги необходимо приобрести как можно больше изделий второго вида. 
Известны выделенная для закупки сумма и вид изделий, которые приобретаются в первую очередь, а также количество и цена различных модификаций данных изделий у поставщика. 
Необходимо определить, сколько будет закуплено изделий второго вида и какая сумма останется неиспользованной.

Формат ввода
Первая строка входного файла содержит два целых числа: N – общее количество партий изделий у поставщика и M – сумма выделенных на закупку денег (в рублях), а также символ (латинская буква A или B) вид изделий, покупаемых в первую очередь. 
Каждая из следующих N строк описывает одну партию и содержит два целых числа (цена одного изделия в рублях и количество изделий в партии) и один символ (латинская буква A или B), определяющий вид изделия. 
Все данные в строках входного файла отделены одним пробелом.

Формат вывода
В ответе запишите два целых числа: сначала количество закупленных изделий второго вида, затем оставшуюся неиспользованной сумму денег.





using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp130
{
    struct person
    {
        public string Class;
        public int kol;
        public int value;
    }
    class Program
    {
        static void Main(string[] args)
        {
            string[] filename = File.ReadAllLines("input.txt");
            string h = filename[0];
            string[] pp = h.Split();
            int n = int.Parse(pp[0]);
            int f = int.Parse(pp[1]);
            string s = pp[2];
            int zx = 0;
            person [] a = new person[n];
            for (int i = 0; i < n; i++)
            {
                string h1 = filename[i+1];
                string[] pp1 = h1.Split();
                a[i].value = int.Parse(pp1[0]);
                a[i].kol = int.Parse(pp1[1]);
                a[i].Class = pp1[2];
                if (a[i].Class == s) zx++;
            }
            int q = 0;
            int[] ll = new int[zx];
            int[] ll1 = new int[zx];
            for (int i = 0; i < n; i++)
            {
                if (a[i].Class == s)
                {
                    ll[q] = a[i].value;
                    ll1[q] = a[i].kol;
                    q++;
                }
            }
            Array.Sort(ll, ll1);
            for (int i = 0; i < zx; i++)
            {
                if (f < ll[i]) break;
                else
                {
                    int t = f / ll[i];
                    if (t >= ll1[i])
                    {
                        f -= ll1[i] * ll[i];
                    }
                    else
                    {
                        f -= ll[i] * t;
                    }
                }
            }
            int w = 0;
            int[] jj = new int[n-zx];
            int[] jj1 = new int[n-zx];
            for (int i = 0; i < n; i++)
            {
                if (a[i].Class != s)
                {
                    jj[w] = a[i].value;
                    jj1[w] = a[i].kol;
                    w++;
                }
            }
            Array.Sort(jj, jj1);
            int count = 0;
            for(int i = 0; i < n - zx; i++)
            {
                if (f < jj[i]) break;
                else
                {
                    int t = f / jj[i];
                    if (t >= jj1[i])
                    {
                        f -= jj1[i] * jj[i];
                        count += jj1[i];
                    }
                    else
                    {
                        f -= jj[i] * t;
                        count += t;
                    }
                }
            }
            string p = f.ToString();
            string r = count.ToString();
            File.WriteAllText("output.txt", r + ' ' + p);
        }
    }
}

