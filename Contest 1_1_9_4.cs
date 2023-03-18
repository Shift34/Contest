





using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp89
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] filename = File.ReadAllLines("input.txt");
            int k = Convert.ToInt32(filename[0]);
            int p = 1;
            int z = 0;
            int q = 1;
            int u = 0;
            int count = 0;
            string[] y = new string[k];
            int[] jj = new int[k*k];
            int[] jj1 = new int[k * k];
            for (int i = 0; i < k; i++)
            {
                y[i] = filename[p];
                p++;
            }
            char[] massage = new char[k*k];
            using (StreamWriter sw = new StreamWriter("output.txt", false))
            {
                for (int i = 0; i < k; i++)
                {
                    string[] s_arr = y[i].Split();
                    for (int m = 0; m < k; m++)
                    {
                        jj[z] = int.Parse(s_arr[m]);
                        z++;
                    }
                }
                Array.Sort(jj);
                Array.Reverse(jj);
                z = 1;
                for (int i = 0; i < k; i++)
                {
                    string[] s_arr = y[i].Split();
                    for (int m = 0; m < k; m++)
                    {
                        jj1[u] = int.Parse(s_arr[m]);
                        if (jj1[u] != 0)
                        {
                            sw.Write(jj1[u]);
                            sw.Write(" ");
                        }
                        else
                        {
                            count = 0;
                            while (count == 0)
                            {
                                for (int h = 0; h < k * k; h++)
                                {
                                    if (jj[h] == z)
                                    {
                                        z += 1;
                                        h = -1;
                                    }
                                    count += 1;
                                }
                                sw.Write(z);
                                sw.Write(" ");
                                z += 1;
                            }
                        }
                    }
                    sw.WriteLine();
                }
            }
        }
    }
}
