Ваша задача осуществить обход графа методом "сначала вширь" и вывести последовательность вершин графа в порядке обхода. 
    Программа должна быть написана с соблюдением принципов ООП (должен быть класс граф, класс алгоритма обхода).

Формат ввода
В первой строке файла указано количество вершин n в графе ( 1 ≤ n ≤ 1000). 
    Далее n строк задают описание графа: в 1й строке располагаются номера вершин, смежных с нулевой вершиной, во 2-й - с первой вершиной и т.д.

В последней строке файла находится номер вершины графа k( 0≤ k ≤ n-1 ), с которой должен начинаться обход.

Формат вывода
В файл output.txt в одну строку через пробел выводятся номера вершин в порядке обхода

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp22
{
    internal class Program
    {
        public class Algorithm
        {
            public static Queue<Picks> queue = new Queue<Picks>();
            public static string input; 
            public static void Run(Graph graph)
            {
                queue.Enqueue(graph.piks[graph.elementary]);
                graph.piks[graph.elementary].state = false;
                while (queue.Count > 0)
                {
                    for (int i=0; i < queue.Peek().connection.Count; i++)
                    {
                        if (graph.piks[queue.Peek().connection[i]].state)
                        {
                            queue.Enqueue(graph.piks[queue.Peek().connection[i]]);
                            graph.piks[queue.Peek().connection[i]].state = false;
                        }
                    }
                    input += queue.Dequeue().number + " ";
                }
                using (StreamWriter sw = new StreamWriter("output.txt"))
                {
                    sw.WriteLine(input);
                } 
            }
        }

        public class Graph
        {
            public Picks[] piks;
            public string line;
            public int elementary;
            public Graph(string String)
            {
                StreamReader sr = new StreamReader(String);
                line = sr.ReadLine();
                int count = int.Parse(line);
                piks = new Picks[int.Parse(line)];
                for (int i = 0; i < count; i++)
                {
                    line = sr.ReadLine();
                    string []input = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    Array.Sort(input);
                    piks[i] = new Picks(input, i);
                }
                line = sr.ReadLine();
                elementary = int.Parse(line);
            }
        }

        public class Picks 
        {
            public bool state;
            public List<int> connection;
            public int number;
            public Picks(string [] input,int number )
            {
                connection = new List<int>();
                state = true;
                for (int j = 0; j < input.Length; j++)
                {
                    connection.Add(int.Parse(input[j]));
                }
                this.number = number;
            }
        }

        static void Main(string[] args)
        {
            Graph graph = new Graph("input.txt");
            Algorithm.Run(graph);
            Console.ReadKey();
        }
    }
}
