namespace Lab9_OOP
{
    class Program
    {
        delegate bool CheckNum(int num);
        static void Main(string[] args)
        {
            Task1();
            Task2();
            Indiv();
        }

        static void Task1()
        {
            bool GetEven(int num) => num % 2 == 0 ? true : false;
            bool GetPositive(int num) => num > 0 ? true : false;
            int Counting(List<int> masNum, CheckNum checkNum)
            {
                int count = 0;
                for (int i = 0; i < masNum.Count; i++)
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
                int numLess = ReadInt("Введите число: ");
                bool check;
                bool Less(int num)
                {
                    check = false;
                    check = num < numLess ? true : false;
                    return check;
                }
                return Less;
            }

            List<int> mass = new();
            Random rand = new();

            int len = ReadPositiveInt("Длина массива: ");
            for (int i = 0; i < len; i++)
                mass.Add(rand.Next(-10, 10));
            PrintList(mass);

            int choice;
            do
            {
                Console.Clear();
                PrintList(mass);
                choice = ReadInt("1 - Чётные числа\n2 - Положительные числа\n3 - Числа меньше заданого\n0 - Выход\nВведите номер действия: ");
                switch (choice)
                {
                    case 0: break;
                    case 1:
                        {
                            Console.WriteLine("Чётных чисел: " + Counting(mass, GetEven));
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine($"Положительные числа: " + Counting(mass, GetPositive));
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Числа меньше введенного: " + Counting(mass, GetPrevious()));
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Введено неверное значение");
                            break;
                        }
                }
                if (choice != 0) TheNext("Следующее действие, нажмите любую клавишу");
            } while (choice != 0);

            TheNext("Перейти ко второму заданию, нажмите любую клавишу");
        }
        static void Task2()
        {
            Console.Clear();
            void PrintEvent(string mes) => Console.WriteLine(mes);
            int size = ReadPositiveInt("Введите размер массива: ");

            UniqIntMas obj = new UniqIntMas(size);
            obj.Handeve += PrintEvent;

            int choice;
            do
            {
                Console.Clear();
                Console.Write("Массив [");
                obj.Print();
                Console.WriteLine("]");
                choice = ReadInt("1 - Добавить запись\n2 - Удалить запись\n0 - Выход\nВведите номер действия: ");
                switch (choice)
                {
                    case 0: break;
                    case 1:
                        {
                            int num = ReadInt("Введите число которое нужно добавить: ");
                            obj.Add(num);
                            break;
                        }
                    case 2:
                        {
                            int num = ReadInt("Введите число которое нужно удалить: ");
                            obj.Remove(num);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Введено неверное значение");
                            break;
                        }
                }
                if (choice != 0) TheNext("Следующее действие, нажмите любую клавишу");
            } while (choice != 0);
            TheNext("Перейти к индивидуальному заданию, нажмите любую клавишу");
        }
        static void Indiv()
        {
            Console.Clear();

            ListQueue listQueue = new ListQueue();
            for (int i = 0; i < 15; i++)
                listQueue.Add(new Person());

            listQueue.Null(3);
            listQueue.Null(5);
            listQueue.Null(6);
            listQueue.Null(2);
            listQueue.Null(7);
            listQueue.Null(20);

            listQueue.Print();
        }
        public static int ReadInt()
        {
            string str;

            do str = Console.ReadLine();
            while (!int.TryParse(str, out _));

            return int.Parse(str);
        }
        public static int ReadInt(string mess)
        {
            string str;

            do
            {
                Console.Write(mess);
                str = Console.ReadLine();
            }
            while (!int.TryParse(str, out _));

            return int.Parse(str);
        }
        public static int ReadPositiveInt(string mess)
        {
            int positiveInt;

            do positiveInt = ReadInt(mess);
            while (positiveInt < 0);

            return positiveInt;
        }
        public static void TheNext()
        {
            Console.Write("Чтобы продолжить, нажмите любую клавишу");
            Console.ReadKey();
        }
        public static void TheNext(string mess)
        {
            Console.Write(mess);
            Console.ReadKey();
            Console.WriteLine();
        }
        public static void PrintList<T>(List<T> list)
        {
            Console.Write("Массив [");
            list.ForEach(x => Console.Write($" {x} "));
            Console.WriteLine("]");
        }
    }
}
