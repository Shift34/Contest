Классическая для городов Белории схема метрополитена представляет собой набор n станций, соединенных n переездами, каждый из которых соединяет ровно две станции и не проходит через какие-либо другие. 
Кроме того, в классической схеме с каждой станции можно добраться до любой другой, двигаясь по переездам. 
Переезды можно использовать в обе стороны для перемещения. Между каждой парой станций — не более одного переезда.

Недавно математики Белории доказали теорему, согласно которой в любой классической схеме существует кольцевая и притом ровно одна. 
Иными словами, в любой классической схеме можно найти единственный цикл из станций (в котором любые две соседние соединены переездом), и этот цикл не содержит никакую станцию более одного раза.

Это открытие имело мощный социальный эффект — ведь теперь станции можно было сравнивать по принципу их удаления от кольцевой. 
Например, один житель мог сказать: «я живу в трех переездах от кольцевой», а другой ему ответить: «неудачник, а — я в одном». 
В интернете стали появляться приложения, предлагающие рассчитать удаленность станции от кольцевой (пошлите смс на короткий номер...).

Правительство Белории решило положить конец этим беспорядкам и взять ситуацию в свои руки. 
Вам поручено написать программу, которая по схеме метрополитена города для каждой станции определит удаленность от кольцевой.

Формат ввода
В первой строке содержится целое число n (3 ≤ n ≤ 3000), n — количество станций (и одновременно переездов) в схеме метро. 
Далее в n строках содержатся описания переездов, по одному в строке. 
Каждая строка содержит пару целых исел xi, yi (1 ≤ xi, yi ≤ n), и обозначает наличие переезда со станции xi до станции yi. 
Станции пронумерованы от 1 до n в произвольном порядке. Гарантируется, что xi ≠ yi и то, что между каждой парой станций не более одного переезда. 
Переезды можно использовать для перемещения в обе стороны. Гарантируется, что заданное описание представляет собой классическую схему метрополитена.

Формат вывода
Выведите n чисел. Числа разделяйте пробелами, i-ое из них должно быть равно удалению i-ой станции от кольцевой. Для станций на кольцевой выводите число 0.





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
            public Stack<Picks> stack = new Stack<Picks>();
            public List<int> Cicle = new List<int>();
            public Algorithm() { }
            public  List<int> FindingCicle(Graph graph)
            {
                stack.Push(graph.piks[0]);
                Cicle.Add(graph.piks[0].number);
                graph.piks[0].state = false;
                while (stack.Count > 0)
                {
                    for (int i = 0; i < stack.Peek().connection.Count; i++)
                    {
                        if (graph.piks[stack.Peek().connection[i]].state)
                        {
                            graph.piks[stack.Peek().connection[i]].state = false;
                            stack.Push(graph.piks[stack.Peek().connection[i]]);
                            Cicle.Add(stack.Peek().number);
                            i = -1;
                            if (Cicle.Count > 2)
                            {
                                for (int j = 0; j < Cicle.Count - 2; j++)
                                {
                                    if (graph.piks[Cicle[j]].connection.Contains(Cicle[Cicle.Count - 1]))
                                    {
                                        Cicle.RemoveRange(0, j);
                                        return Cicle;
                                    }
                                }
                            }
                        }
                    }
                    stack.Pop();
                    Cicle.RemoveAt(Cicle.Count - 1);
                }
                return Cicle;
            }
            public static void Way(Graph graph , List<int> list)
            {
                Queue<Picks> queue = new Queue<Picks>();
                for (int i = 0; i < list.Count; i++)
                {
                    queue.Enqueue(graph.piks[list[i]]);
                    queue.Peek().state = false;
                    int count = 1;
                    while (queue.Count > 0)
                    {
                        for (int j = 0; j < queue.Peek().connection.Count; j++)
                        {
                            if (graph.piks[queue.Peek().connection[j]].state)
                            {
                                queue.Enqueue(graph.piks[queue.Peek().connection[j]]);
                                graph.piks[queue.Peek().connection[j]].state = false;
                                graph.piks[queue.Peek().connection[j]].count = count;
                            }
                        }
                        count++;
                        queue.Dequeue();
                    }
                }
                using( StreamWriter sw = new StreamWriter("output.txt"))
                {
                    foreach (var item in graph.piks)
                    {
                        sw.Write(item.count + " ");                
                    }
                }
            }
        }

        public class Graph
        {
            public Picks[] piks;
            public Graph(string String)
            {
                StreamReader sr = new StreamReader(String);
                string line = sr.ReadLine();
                int count1 = int.Parse(line);
                piks = new Picks[count1];
                Edge [] edge = new Edge[count1];
                for (int i = 0; i < count1; i++)
                {
                    line = sr.ReadLine();
                    string[] input = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    edge[i] = new Edge(input);
                    piks[i] = new Picks(i);
                }
                Array.Sort(edge);
                foreach (var item in edge)
                {
                    piks[item.firstpick - 1].connection.Add(item.secondpick - 1);
                    piks[item.secondpick - 1].connection.Add(item.firstpick - 1);
                }
            }
        }

        public class Picks
        {
            public bool state;
            public List<int> connection = new List<int>();
            public int number;
            public int count;
            public Picks(int number)
            {
                state = true;
                this.number = number;
                count = 0;
            }
        }
        public class Edge : IComparable<Edge>
        {
            public int firstpick;
            public int secondpick;
            public Edge(string[] input)
            {
                firstpick = int.Parse(input[0]);
                secondpick = int.Parse(input[1]);
            }

            public int CompareTo(Edge other)
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
                return 0;
            }
        }

        static void Main(string[] args)
        {
            Graph graph = new Graph("input.txt");
            Algorithm algorithm = new Algorithm();
            List<int> list = new List<int>();
            list = algorithm.FindingCicle(graph);
            foreach (var item in graph.piks)
            {
                if (list.Contains(item.number)) { }
                else item.state = true;
            }
            Algorithm.Way(graph, list);
        }
    }
}


