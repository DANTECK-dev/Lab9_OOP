using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_OOP
{
    internal class UniqIntMas
    {

        public int?[] mas;
        public int size;
        public delegate void HandlerEvent(string mes);
        public event HandlerEvent? Handeve;

        public UniqIntMas(int size)
        {
            this.size = size;
            mas = new int?[size];
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = null;
            }
        }

        public void Add(int num)
        {
            int i;
            for (i = 0; mas[i].HasValue && i < mas.Length; i++)
            {
                if (mas[i] == num)
                {
                    Console.WriteLine($"Добавить элемент ({num}) невозможно, так как он уже существует");
                    return;
                }
            }
            if (i == mas.Length - 1) Console.WriteLine($"Добавить элемент ({num}) невозможно, так как массив уже полон");
            else
            {
                mas[i] = num;
                Handeve.Invoke($"Добавлен новый элемент ({num})");
            }
        }
        public void Remove(int num)
        {
            int i;
            for (i = 0; i < mas.Length; i++)
            {
                if (mas[i] == num)
                {
                    mas[i] = null;
                    Handeve.Invoke($"Удалён элемент ({num})");
                    return;
                }
            }
            if (i == mas.Length)
            {
                Console.WriteLine($"Удалить элемент ({num}) невозможно, так как его не существует");
            }
        }
        public void Print()
        {
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i].HasValue)
                {
                    Console.WriteLine($"{i + 1} Элемент = {mas[i]}");
                }
            }
        }
    }
}
