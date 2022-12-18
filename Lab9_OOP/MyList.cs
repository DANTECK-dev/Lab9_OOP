namespace Lab9_OOP
{
    public class Person
    {
        private string[] Names = {
            "Алексей",
            "Иван",
            "Марьям",
            "Всеволод",
            "Роман",
            "Мирослав",
            "Серафима",
            "Иван",
            "Билал",
            "Александра",
            "Екатерина",
            "Диана",
            "Всеволод",
            "Ева"
        };
        private string[] Surnames = {
            "Андреев",     
            "Степанов",    
            "Платонова",   
            "Федоров",     
            "Муравьев",    
            "Макаров",     
            "Фомина",      
            "Казаков",     
            "Цветков",     
            "Попова",      
            "Вдовина",     
            "Петрова",     
            "Федоров",
            "Копылова",
        };
        private string[] Patronymics = {
            "Даниилович",
            "Павлович",
            "Максимовна",
            "Кириллович",
            "Сергеевич",
            "Артемьевич",
            "Германовна",
            "Кириллович",
            "Михайлович",
            "Фёдоровна",
            "Семёновна",
            "Ивановна",
            "Кириллович",
            "Юрьевна"
        };
        private string? Name { get; }
        private string? Surname { get; }
        private string? Patronymic { get; }

        public Person(string Name, string Surname, string Patronymic)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Patronymic = Patronymic;
        }
        public Person()
        {
            Random random = new();
            this.Name = Names[random.Next(0,14)];
            this.Surname = Surnames[random.Next(0, 14)];
            this.Patronymic = Names[random.Next(0, 14)];
        }
        public override string ToString()
        {
            return Name + " " + Surname + " " + Patronymic;
        }
    }
    public class Node
    {
        public Person? Data { get; set; }
        public Node? Next { get; set; }
        public Node? Prev { get; set; }
        public override string? ToString()
        {
            return Data?.ToString();
        }
    }
    public class ListQueue
    {
        void PrintEvent(string mes) => Console.WriteLine(mes);
        public delegate void HandlerEvent(string mes);
        public event HandlerEvent? Handeve;
        Action counter;

        private Node? head = null;
        private Node? tail = null;
        int count = 0;
        public int Count
        {
            get { return count; }
            private set
            {
                if (count < 0) throw new ArgumentNullException("count", "Счётчик не может быть меньше нуля");
                count = value;
            }
        }
        public ListQueue()
        {
            Handeve += PrintEvent;
            counter = Counter();
        }
        Action Counter()
        {
            int count = 1;
            void Inner()
            {
                if (count == 106)
                {
                    Console.Write("");
                }
                Handeve!.Invoke($"Номер операции ({count})");
                count++;
            }
            return Inner;
        }
        public void Add(Person person)
        {
            counter();
            for (int i = 0; i < Count; i++)
            {
                if (head is null || tail is null) break;
                if (Get(i) is null)
                {
                    Set(person, i);
                    Handeve!.Invoke($"Добавлен ({person.ToString()})");
                    return;
                }
            }
            Node? node = new()
            {
                Data = person
            };
            if (head is null)
                head = node;
            else if (head.Next is null)
                head.Next = node;

            if (tail is not null)
                tail.Next = node;
            node.Prev = tail;
            tail = node;

            count++;
            Handeve!.Invoke($"Добавлен ({person.ToString()})");
        }
        public Person? Remove()
        {
            counter();
            if (head is null || tail is null)
            {
            Handeve!.Invoke("Список пустой");
                tail = null;
                return null;
            }
            var person = head.Data;
            if (person == null)
            {
                Handeve!.Invoke("Список пустой");
                return null;
            }
            head = head.Next;
            head!.Prev = null;

            Handeve!.Invoke($"Удален ({person.ToString()})");
            count--;
            return person;
        }
        private Person? Get(int index)
        {
            //counter();
            if (head is null || tail is null)
            {
                Handeve!.Invoke("Список пустой");
                return null;
            }
            if (index >= count)
            {
                Handeve!.Invoke("Выход за пределы списка");
                return null;
            }

            Node? cur = head;
            for (int i = 0; i < count; i++)
            {
                if (index == i)
                {
                    return cur?.Data;
                }
                cur = cur?.Next;
            }
            return null;
        }
        private void Set(Person? person, int index)
        {
            //counter();
            if (person == null)
            {
                Handeve!.Invoke("Пустой человек");
                return;
            }
            if (head is null || tail is null)
            {
                Handeve!.Invoke("Список пустой");
                return;
            }
            if (index >= count)
            {
                Handeve!.Invoke("Выход за пределы списка");
                return;
            }

            Node? cur = head;
            for (int i = 0; i < count; i++)
            {
                if (index == i)
                {
                    cur!.Data = person;
                    return;
                }
                cur = cur?.Next;
            }
            return;
        }
        public void GetMassive()
        {
            counter();
            Sort();
            Print();
        }
        public Person? Null(int index)
        {
            counter();
            if (head is null || tail is null)
            {
                Handeve!.Invoke("Список пустой");
                return null;
            }
            if (index >= count)
            {
                Handeve!.Invoke("Выход за пределы списка");
                return null;
            }

            Node? cur = head;
            for (int i = 0; i < count; i++)
            {
                if (index == i)
                {
                    Person? person = cur?.Data;
                    Handeve!.Invoke($"Удален {person.ToString()}");
                    cur!.Data = null;
                    return person;
                }
                cur = cur?.Next;
            }
            return null;
        }
        private void Sort()
        {
            counter();
            Handeve!.Invoke("Сортировка списка");
            for (int i = 1; i < count; i++)
            {
                Person? cur = Get(i);

                if (cur is null) continue;

                for (int j = i; j >= 0; j--)
                {
                    if (Get(j - 1) is null || Get(j) is null) continue;
                    Set(Get(j - 1), j);
                    if (j == 0)
                    {
                        Set(cur, j);
                        break;
                    }
                    if (cur!.ToString()[0] > Get(j - 1)?.ToString()[0] || cur!.ToString()[0] == Get(j - 1)?.ToString()[0])
                    {
                        Set(cur, j);
                        break;
                    }
                }
            }   
        }
        public void Print()
        {
            counter();
            Console.WriteLine();
            Node? cur = head;
            for (int i = 0; i < count; i++)
            {
                if (cur?.Data == null) Console.WriteLine("Пусто");
                else Console.WriteLine(cur?.Data?.ToString());
                cur = cur?.Next;
            }
            Console.WriteLine();
        }
    }
}