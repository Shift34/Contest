При регистрации на портале интернет-олимпиады все участники заполняют регистрационную форму, где они указывают название школы, в которой они учатся. 
Разные участники могут по-разному писать название школы, например, «Физико-математическая школа №18», «ФМШ №18».
Организаторам олимпиады предоставлена информация о названиях школ, которые написали регистрируемые участники олимпиады. 
Точно известно, что цифры в названии школы встречаются только в номере школы, а число в записи названия школы встречается ровно один раз и оно однозначно определяет номер школы. 
Номер школы положителен и не может начинаться с нуля.
Требуется написать программу для сайта интернет-олимпиады, которая поможет организаторам олимпиады получить следующую информацию: количество школ и номера школ, из которых зарегистрировалось не более пяти участников.

Формат ввода
Первая строка входного файла содержит одно целое число n (1 ≤ n ≤ 1000) – количество названий школ, указанных всеми участниками при регистрации.
Последующие n строк содержат названия школ, указанные участниками. Название школы содержит только заглавные и строчные буквы латинского алфавита, цифры и пробелы, длина названия не превышает 100 символов.

Формат вывода
Первая строка выходного файла должна содержать одно число m – количество школ, от которых на олимпиаду зарегистрировалось от одного до пяти участников. 
Последующие m строк должны содержать только номера таких школ, при этом номера должны располагаться по одному в строке в произвольном порядке.





using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp135
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] filename = File.ReadAllLines("schools.in");
            int n = int.Parse(filename[0]);
            int count = 0;
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                string[] kk = filename[i + 1].Split();
                int y = 0;
                string j = null;
                while (j == null)
                {
                    string s = kk[y];
                    int u = 0;
                    while (u < s.Length)
                    {
                        if (!char.IsLetter(s[u]))
                        {
                            j += s[u];
                            u++;
                        }
                        else if(char.IsLetter(s[u]) &&j!=null)
                        {
                            break;
                        }
                        else
                        {
                            u++;
                        }
                    }
                    y++;
                }
                if (dictionary.ContainsKey(j)) dictionary[j]++;
                else dictionary.Add(j, 1);
            }
            using (StreamWriter sw = new StreamWriter("schools.out", false))
            {
                foreach (var item in dictionary)
                {
                    if (item.Value >= 1 && item.Value <= 5) count++;
                }
                sw.WriteLine(count);
                foreach (var item in dictionary)
                {
                    if (item.Value >= 1 && item.Value <= 5) sw.WriteLine(item.Key);
                }
            }
        }
    }
}


