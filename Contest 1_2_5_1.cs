Первокурсник Петя придумал новую компьютерную игру. В этой игре игрок выставляет в линию шарики разных цветов. 
Когда образуется непрерывная цепочка из трех и более шариков одного цвета, она удаляется из линии.
Все шарики при этом сдвигаются друг к другу, и ситуация может повториться.
Напишите программу, которая по данной ситуации определяет, сколько шариков будет сейчас уничтожено. 
Естественно, непрерывных цепочек из трех и более одноцветных шаров в начальный момент может быть не более одной.

Формат ввода
Даны количество шариков в цепочке (не более 109 ) и цвета шариков (от 0 до 9, каждому цвету соответствует свое целое число).

Формат вывода
Требуется вывести количество шариков, которое будет уничтожено.






using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp133
{
    class Program
    {
        static void Main(string[] args)
        {
            string h;
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                h = sr.ReadToEnd();
            }
            int count = 0;
            string a = Convert.ToString('z');
            int count1 = 1;
            string[] lexem = h.Split(new char[] { ' ', '\t' },
                StringSplitOptions.RemoveEmptyEntries);
            Stack<string> stack = new Stack<string>();
            Stack<string> stack1 = new Stack<string>();
            stack.Push(lexem[0]);
            for (int l=1;l<lexem.Length;l++)
            {
                if (lexem[l] == stack.Peek())
                {
                    count1++;
                    stack.Push(lexem[l]);
                }
                else if (count1 > 2)
                {
                    while (1 > 0)
                    {
                        if (count1 > 2)
                        {
                            while (count1 > 0)
                            {
                                stack.Pop();
                                count1--;
                                count++;
                            }
                            if (l < lexem.Length)
                            {
                                stack.Push(lexem[l]);
                                string j = stack.Peek();
                                count1 = 0;
                                l++;
                                while ((stack.Count!=0)&&(j == stack.Peek()))
                                {
                                    count1++;
                                    stack1.Push(stack.Pop());
                                }
                                for (int i = 0; i < count1; i++)
                                {
                                    stack.Push(stack1.Pop());
                                }
                                while ((l < lexem.Length) && (lexem[l] == j))
                                {
                                    count1++;
                                    stack.Push(j);
                                    l++;
                                }
                            }
                            else
                            {
                                if (stack.Count != 0)
                                {
                                    string x = stack.Peek();
                                    count1 = 0;
                                    while ((stack.Count != 0) && (h == stack.Peek()))
                                    {
                                        count1++;
                                        stack1.Push(stack.Pop());
                                    }
                                    for (int i = 0; i < count1; i++)
                                    {
                                        stack.Push(stack1.Pop());
                                    }
                                }
                            }
                        }
                        else { l--; break; }
                    }
                }
                else
                {
                    count1 = 1;
                    stack.Push(lexem[l]);
                }
            }
            while (1 > 0)
            {
                if (count1 > 2)
                {
                    if (count1 == stack.Count)
                    {
                        break;
                    }
                    while (count1 > 0)
                    {
                        stack.Pop();
                        count1--;
                        count++;
                    }
                    if (stack.Count != 0)
                    {
                        string x = stack.Peek();
                        count1 = 0;
                        while ((stack.Count != 0) && (h == stack.Peek()))
                        {
                            count1++;
                            stack1.Push(stack.Pop());
                        }
                        for (int i = 0; i < count1; i++)
                        {
                            stack.Push(stack1.Pop());
                        }
                    }
                }
                else break;
            }
            Console.WriteLine(count);
        }
    }
}
