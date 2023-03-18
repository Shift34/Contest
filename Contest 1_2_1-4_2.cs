Однажды неловкая секретарша перепутала личные дела учащихся. Теперь их снова необходимо упорядочить сначала по классам, а внутри класса по фамилиям.

Формат ввода
В первой строке дано число N (1 ≤ N ≤ 1000) – количество личных дел. 
Далее для каждого из N учащихся следующие данные (каждое в своей строке): фамилия и имя, класс, дата рождения. Фамилия и имя – строки не более чем из 20 символов, класс – строка состоящая из числа (от 1 до 11) и латинской буквы (от "A" до "Z" ), дата рождения – дата в формате "ДД.ММ.ГГ". 
Гарантируется, что внутри одного класса нет однофамильцев.

Формат вывода
В выходной файл требуется вывести N строк, в каждой из которых записаны данные по одному учащемуся. 
Строки должны быть упорядочены сначала по классам, а затем по фамилиям.





using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp130
{
    struct person
    {
        public string Class;
        public string SurName;
        public string Name;
        public string Date;
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            person [] a = new person[n];
            for (int i = 0; i < n; i++)
            {
                a[i].SurName = Console.ReadLine();
                a[i].Name = Console.ReadLine();
                a[i].Class = Console.ReadLine();
                a[i].Date = Console.ReadLine();
            }
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n - 1; j++)
                {
                    int o = 0;
                    int o1 = 0;
                    string h = null;
                    string f = a[j].Class;
                    for (int l = 0; l < f.Length; l++)
                    {
                        if (Char.IsLetter(f[l]))
                        {
                            break;
                        }
                        else
                        {
                            h += f[l];
                            o++;
                        }
                    }
                    string h1 = null;
                    string f1 = a[j+1].Class;
                    for (int l = 0; l < f1.Length; l++)
                    {
                        if (Char.IsLetter(f1[l]))
                        {
                            break;
                        }
                        else
                        {
                            h1 += f1[l];
                            o1++;
                        }
                    }
                    if (int.Parse(h) > int.Parse(h1))
                    {
                        person temp;
                        temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                    }
                    else if(int.Parse(h) == int.Parse(h1))
                    {
                        if (String.Compare(f.Substring(o), f1.Substring(o1)) == 1)
                        {
                            person temp;
                            temp = a[j];
                            a[j] = a[j + 1];
                            a[j + 1] = temp;
                        }
                        else if(f.Substring(o)==f1.Substring(o1))
                        {
                            if (String.Compare(a[j].SurName, a[j+1].SurName) == 1)
                            {
                                person temp;
                                temp = a[j];
                                a[j] = a[j + 1];
                                a[j + 1] = temp;
                            }
                        }
                    }
                }
            for (int i = 0; i < n; i++)
            {
                Console.Write(a[i].Class + ' ');
                Console.Write(a[i].SurName + ' ');
                Console.Write(a[i].Name + ' ');
                Console.WriteLine(a[i].Date);
            }
        }
    }
}
