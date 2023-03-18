Ваша задача построить минимальное остовное дерево графа методом с помощью алгоритма Краскала и вывести последовательность ребер графа в порядке добавления их в дерево.

Программа должна быть написана с соблюдением принципов ООП (должен быть класс граф, класс алгоритма обхода).

Формат ввода
В первой строке файла указано количество вершин n и ребер m в графе ( 1 ≤ n ≤ 1000, 1 ≤ m ≤ 100000). 
Далее m строк задают описание графа: в каждой строке располагается описание ребра в формате vi vj wij, где vi, vj -- номера вершин, а wij -- вес соответствующего ребра.

Формат вывода
В файл output.txt выводятся ребра остовного дерева графа( каждое ребро в отдельной строке) в порядке их добавления.

Предполагается, что при записи ответа номер первой вершины в ребре меньше номера второй.



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
            public static HashSet<int> hashset = new HashSet<int>();
            public static List<Edge> list = new List<Edge>();
            public static int i;
            public static int count;
            public static void Run(Graph graph)
            {
                i = 0;
                count = 0;
                while(graph.edge.Length>i)
                {
                    if (hashset.Contains(graph.edge[i].firstpick) && hashset.Contains(graph.edge[i].secondpick))
                    {
                        int group1 = 0;
                        int group2 = 0;
                        foreach (Edge edge in list)
                        {
                            if (edge.firstpick == graph.edge[i].firstpick | edge.secondpick == graph.edge[i].firstpick)
                                group1 = edge.number;
                        }
                        foreach (Edge edge in list)
                        {
                            if (edge.firstpick == graph.edge[i].secondpick | edge.secondpick == graph.edge[i].secondpick)
                                group2 = edge.number;
                        }
                        if (group1 != group2)
                        {
                            int max = Math.Max(group1, group2);
                            int min = Math.Min(group1, group2);
                            foreach (Edge edge in list)
                            {
                                if(edge.number == max) edge.number=min;
                            }
                            graph.edge[i].number = min;
                            list.Add(graph.edge[i]);
                        }

                    }
                    if (!hashset.Contains(graph.edge[i].firstpick) || !hashset.Contains(graph.edge[i].secondpick))
                    {
                        int group1 = 0;
                        int group2 = 0;
                        foreach (Edge edge in list)
                        {
                            if (edge.firstpick == graph.edge[i].firstpick | edge.secondpick == graph.edge[i].firstpick)
                                group1 = edge.number;
                        }
                        foreach (Edge edge in list)
                        {
                            if (edge.firstpick == graph.edge[i].secondpick | edge.secondpick == graph.edge[i].secondpick)
                                group2 = edge.number;
                        }
                        if (group1 == group2)
                        {
                            graph.edge[i].number =++count; 
                        }
                        else
                        {
                            graph.edge[i].number= Math.Max(group1, group2);
                        }
                        hashset.Add(graph.edge[i].firstpick);
                        hashset.Add(graph.edge[i].secondpick);
                        list.Add(graph.edge[i]);
                    }
                    i++;
                }
                using (StreamWriter sw = new StreamWriter("output.txt"))
                {
                    foreach (var item in list)
                    {
                        sw.WriteLine(item.firstpick + " " + item.secondpick);
                    }
                }
            }
        }

        public class Graph
        {
            public Edge[] edge;
            public string line;
            public string[] input;
            public int countpicks;
            public int count = 0;
            public Graph(string String)
            {
                StreamReader sr = new StreamReader(String);
                line = sr.ReadLine();
                input = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                countpicks = int.Parse(input[0]);
                edge = new Edge[int.Parse(input[1])];
                count = int.Parse(input[1]);
                for (int i = 0; i < count; i++)
                {
                    line = sr.ReadLine();
                    input = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    if (int.Parse(input[0]) > int.Parse(input[1]))
                    {
                        int temp = int.Parse(input[0]);
                        input[0] = input[1];
                        input[1] = temp.ToString();
                    }
                    edge[i] = new Edge(input);
                }
                Array.Sort(edge);
            }
        }

        public class Edge:IComparable<Edge>
        {
            public int firstpick;
            public int secondpick;
            public int length;
            public int number;
            public Edge(string [] input )
            {
                firstpick = int.Parse(input[0]);
                secondpick = int.Parse(input[1]);
                length=int.Parse(input[2]);
                number =0;
            }

            public int CompareTo(Edge other)
            {
                if (this.length > other.length)
                    return 1;
                if (this.length < other.length)
                    return -1;
                if (this.length == other.length)
                {
                    if (this.firstpick > other.firstpick)
                    {
                        return 1;
                    }
                    if (this.firstpick < other.firstpick)
                    {
                        return -1;
                    }
                    if (this.firstpick == other.firstpick)
                    {
                        if (this.secondpick > other.secondpick)
                        {
                            return 1;
                        }
                        if (this.secondpick < other.secondpick)
                        {
                            return -1;
                        }
                    }
                }
                return 0;
            }
        }

        static void Main(string[] args)
        {
            Graph graph = new Graph("input.txt");
            Algorithm.Run(graph);
        }
    }
}
