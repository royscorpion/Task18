using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task18
{
    class Program
    {
        /// Проверка корректности расстановки скобок в введенной строке
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку, содержащую скобки трех видов (круглые, квадратные и фигурные) и любые другие символы");
            char[] charArray = Console.ReadLine().ToCharArray();

            #region Для проверки кода
            //char[] charArray = "(sdf5sd0+[frrger - dfwe)/{df-fg*yh})".ToCharArray();//некорректная расстановка
            //char[] charArray = "(sdf5sd0+[frrger - dfwe]/{df-fg*yh})".ToCharArray();//корректная расстановка
            #endregion

            //Однократный проход по символам введенной строки с использованием коллекции Stack
            Stack<string> stack = new Stack<string>();
            for (int i = 0; i < charArray.Length; i++)
            {
                string chr;
                switch (chr = charArray[i].ToString())
                {
                    //для каждой открывающей скобки в стек помещается соответствующая закрывающая
                    case "(":
                        stack.Push(")");
                        break;
                    case "[":
                        stack.Push("]");
                        break;
                    case "{":
                        stack.Push("}");
                        break;
                    default:
                        if (")]}".Contains(chr) && chr == stack.Peek()) //если скобка закрывающая и совпадает с первым элементом стека
                            stack.Pop(); //то извлечь первый элемент из стека (удалить)
                        break;
                }
            }
            //Вывод результата проверки
            if (stack.Count > 0) //если стек не пустой
                Console.WriteLine("Скобки расставлены некорректно.");
            else //стек пустой
                Console.WriteLine("Скобки расставлены корректно");

            Console.ReadKey();
        }
    }
}
