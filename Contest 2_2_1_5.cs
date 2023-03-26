Все помнят легенду о лабиринте на острове Крит, где Минотавр съедал своих жертв?

В нашей задаче будет альтернативная история. Ариадна отдала Тесею не клубок ниток и меч, а только карту лабиринта. 
Герой знает, где находится вход и где выход. Также известно, что лабиринт ограничен сплошной стеной по периметру.

Проблема в том, что в лабиринте живет Минотавр. 
Он обладает очень тонким обонянием, то есть Минотавр может понять, где находится человек в любой момент времени, а значит может в кратчайшее время настигнуть Тесея и съесть, если только он достижим.

Схема лабиринта представлена в виде таблицы N×M. 
Вход находится в левой верхней клетке(1,1). В этом же месте находится герой в начальный момент времени. 
Выход из лабиринта находится в правой нижней клетке (n-2, m-2).
Гарантируется, что от входа до выхода существует путь и что Минотавр находится в свободной клетке.

Необходимо определить длину кратчайшего пути героя до выхода, и сможет ли Тесей гарантированно выбраться из лабиринта живым, если за единицу времени как герой, так и Минотавр, могут переместиться в соседнюю по стороне клетку в произвольном свободном направлении (то есть туда, где нет стены).

Формат ввода
Первая строка входного файла input.txt содержит два числа: N и M – длина и ширина лабиринта (4 ≤ N, M ≤ 1000). 
Далее следует N строк по M символов – описание лабиринта. 
Символ «#» означает стену, а символ «.» - свободное пространство, «T» - положение Минотавра в начальный момент времени.

Формат вывода
В первой строке файла output.txt выведите целое число – длину кратчайшего пути героя, во второй строке выведите «Yes», если Тесей гарантированно сможет добраться до выхода, и «No» в противном случае.




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
        public class AlgorithmTecey
        {
            static public Queue<Picks> queue = new Queue<Picks>();
            static int count2 = 0;
            public static int Run(Graph graph)
            {
                queue.Enqueue(graph.piks[1, 1]);
                graph.piks[1, 1].state = false;
                int count = 1;
                int newways = 1;
                bool solution = false;
                while (true)
                {
                    count2 = 0;
                    for (int i = 0; i < newways; i++)
                    {
                        if (AlgorithmTecey.CellCheck(graph.piks[queue.Peek().Y + 1, queue.Peek().X], graph)) solution = true;
                        if (AlgorithmTecey.CellCheck(graph.piks[queue.Peek().Y - 1, queue.Peek().X], graph)) solution = true;
                        if (AlgorithmTecey.CellCheck(graph.piks[queue.Peek().Y, queue.Peek().X + 1], graph)) solution = true;
                        if (AlgorithmTecey.CellCheck(graph.piks[queue.Peek().Y, queue.Peek().X - 1], graph)) solution = true;
                        queue.Dequeue();
                    }
                    if (solution) break;
                    newways = count2;
                    count++;
                }
                using (StreamWriter sw = new StreamWriter("output.txt", false))
                {
                    sw.WriteLine(count);
                }
                queue = null;
                return count;
            }
            public static bool CellCheck(Picks picks, Graph graph)
            {
                if (picks != null&&picks.state)
                {
                    queue.Enqueue(picks);
                    picks.state = false;
                    count2++;
                    if (picks == graph.piks[graph.numlines - 2, graph.numcolomns - 2]) return true;
                }
                return false;
            }
        }
        public class AlgorithmMinotabr
        {
            static public Queue<Picks> queue = new Queue<Picks>();
            static int count2 = 0;

            public static int Run(Graph graph)
            {
                queue.Enqueue(graph.Minotavr);
                queue.Peek().state = false;
                int count = 1;
                int newways = 1;
                bool solution = false;
                while (true)
                {
                    count2 = 0;
                    for (int i = 0; i < newways; i++)
                    {
                        if (AlgorithmMinotabr.CellCheck(graph.piks[queue.Peek().Y + 1, queue.Peek().X], graph)) solution = true;
                        if (AlgorithmMinotabr.CellCheck(graph.piks[queue.Peek().Y - 1, queue.Peek().X], graph)) solution = true;
                        if (AlgorithmMinotabr.CellCheck(graph.piks[queue.Peek().Y, queue.Peek().X + 1], graph)) solution = true;
                        if (AlgorithmMinotabr.CellCheck(graph.piks[queue.Peek().Y, queue.Peek().X - 1], graph)) solution = true;
                        queue.Dequeue();
                    }
                    if (solution) break;
                    newways = count2;
                    count++;
                }
                return count;
            }
            public static bool CellCheck(Picks picks, Graph graph)
            {
                if (picks != null && picks.state)
                {
                    queue.Enqueue(picks);
                    picks.state = false;
                    count2++;
                    if (picks == graph.piks[graph.numlines - 2, graph.numcolomns - 2]) return true;
                }
                return false;
            }
        }


        public class Graph
        {
            public Picks[,] piks;
            public Picks Minotavr;
            public int numlines;
            public int numcolomns;
            public Graph(string String)
            {
                StreamReader sr = new StreamReader(String);
                string line = sr.ReadLine();
                string[] input = line.Split();
                piks = new Picks[int.Parse(input[0]), int.Parse(input[1])];
                numlines = int.Parse(input[0]);
                numcolomns = int.Parse(input[1]);
                for (int i = 0; i < numlines; i++)
                {
                    line = sr.ReadLine();
                    for (int j = 0; j < numcolomns; j++)
                    {
                        if (line[j].ToString() != "#")
                        {
                            piks[i, j] = new Picks(line[j].ToString(), i, j);
                            if (line[j].ToString() == "T")
                            {
                                Minotavr = piks[i, j];
                            }
                        }
                    }
                }
            }
        }

        public class Picks
        {
            public bool state;
            public string symbol;
            public int X;
            public int Y;
            public Picks(string input, int i, int j)
            {
                 state = true;
                symbol = input;
                X = j;
                Y = i;
            }
        }

        static void Main(string[] args)
        {
            Graph graph = new Graph("input.txt");
            int countT = AlgorithmTecey.Run(graph);
            graph = null;
            graph = new Graph("input.txt");
            int countM = AlgorithmMinotabr.Run(graph);
            using (StreamWriter sw = new StreamWriter("output.txt", true))
            {
                if (countT < countM) sw.WriteLine("Yes");
                else sw.WriteLine("No");
            }
        }
    }
}









