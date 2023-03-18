В файле data.xml в рабочей директории находится сгенерированный документ.
<root>  
  <front>  
    <compare>  
      <travel>686087340</travel>  
      <known>-445465298.0899868</known>  
      <worry>wood</worry>  
      <helpful>pattern</helpful>  
      <coming>-809362101.732235</coming>  
      <flies>1749133086</flies>  
    </compare>  
    <vegetable>1341522841.189114</vegetable>  
    <essential>-1377022739.0090337</essential>  
    <brought>dark</brought>  
    <suddenly>physical</suddenly>  
    <balloon>action</balloon>  
  </front>  
  <riding>-1679667973.9509425</riding>  
  <layers>-1214645280.7049522</layers>  
  <chose>your</chose>  
  <level>knife</level>  
  <broke>-749766845.1950908</broke>  
</root>
Определите наибольшую глубину вложенности тегов.

Формат вывода
Выведите одно число – наибольшая глубина вложенности тегов.






using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int count = -1;
            int maxcount = 0;
            Stack<string> stack = new Stack<string>();
            using (StreamReader sr = new StreamReader("data.xml"))
            {
                string line;
                while ((line = sr.ReadLine()) != null && !string.IsNullOrWhiteSpace(line))
                {
                    string word = null;
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (line[i] == '<')
                        {
                            i++;
                            if (line[i] == '/')
                            {
                                stack.Pop();
                                count--;
                                break;
                            }
                            else
                            {
                                count++;
                                if (count>= maxcount) maxcount = count;
                                while (line[i] == '>')
                                {
                                    word += line[i];
                                    i++;
                                }
                                stack.Push(word);
                            }
                        }
                    }
                }

            }
            Console.WriteLine(maxcount);
        }
    }
}

