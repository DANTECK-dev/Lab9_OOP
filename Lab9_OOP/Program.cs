using System;
using System.ComponentModel.DataAnnotations;
using System.Net.NetworkInformation;

namespace Lab9_OOP
{
	class Program
	{
		delegate bool CheckNum(int num);
		static void Main(string[] args)
		{
			Task1();
			Task2();
		}

		static void Task1()
		{
			CheckNum checkNum;
			bool GetEven(int num) => num % 2 == 0 ? true : false;
			bool GetPositive(int num) => num > 0 ? true : false;
			int Counting(int[] masNum, CheckNum checkNum, out int count)
			{
				count = 0;
				for (int i = 0; i < masNum.Length; i++)
				{
					if (checkNum(masNum[i]))
					{
						count++;
					}
				}
				return count;
			}
			CheckNum GetPrevious()
			{
				Console.Write("Введите для выполнения 3-й проверки (Числа меньше n - заданного):");
				int numLess = Convert.ToInt32(Console.ReadLine());
				bool check;
				bool Less(int num)
				{
					check = false;
					check = num < numLess ? true : false;
					return check;
				}
				return Less;
			}

			checkNum = GetEven;
			int[] mas = new int[10];
			Random rand = new Random();

			Console.Write("Массив [");
			for (int i = 0; i < mas.Length; i++)
			{
				mas[i] = rand.Next(-10, 10);
				Console.Write($" {mas[i]} ");
			}
			Console.WriteLine("]");


			Console.WriteLine("Чётных чисел: " + Counting(mas, checkNum, out int count));
			checkNum = GetPositive;
			Console.WriteLine($"Положительные числа: " + Counting(mas, checkNum, out count));
			checkNum = GetPrevious();
			Console.WriteLine("Числа меньше введенного: " + Counting(mas, checkNum, out count));
			Console.ReadKey();
		}
		static void Task2()
		{
			void PrintEvent(string mes) => Console.WriteLine(mes);
			int size = -5;

			while (size < 0)
			{
				Console.Write("Введите размер массива:");
				size = Convert.ToInt32(Console.ReadLine());
				if (size < 0)
				{
					Console.WriteLine("Введён некорректный размер (Требуется ввести число больше 0)");
				}
			}

			UniqIntMas obj = new UniqIntMas(size);
			obj.Handeve += PrintEvent;

			int choice = -5;
			while (choice != 0)
			{
				Console.Clear();
				Console.WriteLine("1 - Добавить запись");
				Console.WriteLine("2 - Удалить запись");
				Console.WriteLine("3 - Вывести");
				Console.Write("Введите номер действия:");
				choice = Convert.ToInt32(Console.ReadLine());
				switch (choice)
				{
					case 1:
						{
							Console.Clear();
							Console.Write("Введите число которое нужно добавить:");
							int num = Convert.ToInt32(Console.ReadLine());
							obj.Add(num);
							Console.ReadKey();
							break;
						}
					case 2:
						{
							Console.Clear();
							Console.Write("Введите число которое нужно удалить:");
							int num = Convert.ToInt32(Console.ReadLine());
							obj.Remove(num);
							Console.ReadKey();
							break;
						}
					case 3:
						{
							Console.Clear();
							Console.WriteLine("Массив:");
							obj.Print();
							Console.ReadKey();
							break;
						}
					default:
						{
							Console.Clear();
							Console.WriteLine("Введено неверное значение");
							Console.ReadKey();
							break;
						}
				}
			}
		}
	}
}
