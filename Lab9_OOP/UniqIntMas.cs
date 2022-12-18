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
                mas[i] = null;
        }

        public void Add(int num)
        {
            if (mas.Any(x => x == num)) Console.WriteLine($"Добавить элемент ({num}) невозможно, так как он уже существует");
            else if (mas.All(x => x != null)) Console.WriteLine($"Добавить элемент ({num}) невозможно, так как массив уже полон");
            else
            {
                for(int i = 0; i < mas.Length; i++)
                {
                    if (mas[i] is null) 
                    {
                        mas[i] = num; 
                        break;
                    }
                }
            }
        }
        public void Remove(int num)
        {
            if (mas.All(x => x != num)) Console.WriteLine($"Удалить элемент ({num}) невозможно, так как его не существует");
            else if (mas.Any(x => x == num))
            {
                for (int i = 0; i < mas.Length; i++)
                {
                    if (mas[i] == num)
                    {
                        mas[i] = null;
                        Handeve.Invoke($"Удалён элемент ({num})");
                        break;
                    }
                }
            }
        }
        public void Print()
        {
            mas = mas.OrderBy(x => x).ToArray();
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i].HasValue)
                {
                    Console.Write($" {mas[i]} ");
                }
            }
        }
    }
}
