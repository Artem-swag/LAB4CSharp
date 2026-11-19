namespace Lab_04_1_5
{
    internal class Program
    {
        static void Main()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("   ЛАБОРАТОРНАЯ РАБОТА №4 (Задания 1-5)");
                Console.WriteLine("   Вариант 5");
                Console.WriteLine("1. Задание 1 (List) - удалить все элементы E");
                Console.WriteLine("2. Задание 2 (LinkedList) - развернуть между E");
                Console.WriteLine("3. Задание 3 (HashSet) - фильмы зрителей");
                Console.WriteLine("4. Задание 4 (HashSet) - звонкие согласные");
                Console.WriteLine("5. Задание 5 (Dictionary) - телефоны сотрудников");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите пункт меню: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RunTask1();
                        break;
                    case "2":
                        RunTask2();
                        break;
                    case "3":
                        Lab4Tasks.Task3_Films();
                        break;
                    case "4":
                        Lab4Tasks.Task4_SonorantConsonants();
                        break;
                    case "5":
                        Lab4Tasks.Task5_AverageEmployees();
                        break;
                    case "0":
                        exit = true;
                        Console.WriteLine("Выход из программы...");
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Нажмите любую клавишу для продолжения...");
                        Console.ReadKey();
                        break;
                }

                if (!exit && choice != "0" && choice != "")
                {
                    Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
                    Console.ReadKey();
                }
            }
        }


        static void RunTask1()
        {
            Console.WriteLine("\n Задание 1 ");
            List<int> list = new List<int>();

            Console.WriteLine("Введите элементы списка через пробел (например: 1 2 3 2 4):");
            string input = Console.ReadLine();
            string[] parts = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string p in parts)
            {
                int val;
                if (int.TryParse(p, out val)) list.Add(val);
                else Console.WriteLine($"Пропущено некорректное значение: {p}");
            }

            Console.WriteLine("Текущий список: " + string.Join(", ", list));

            Console.Write("Введите значение E, которое нужно удалить: ");
            int e;
            while (!int.TryParse(Console.ReadLine(), out e))
            {
                Console.Write("Ошибка! Введите целое число: ");
            }

            Lab4Tasks.Task1_RemoveAllValue(list, e);
            Console.WriteLine("Список после удаления: " + string.Join(", ", list));
        }

        static void RunTask2()
        {
            Console.WriteLine("\n Задание 2 ");
            LinkedList<int> linked = new LinkedList<int>();

            Console.WriteLine("Введите элементы списка через пробел (например: 1 5 2 3 5):");
            string input = Console.ReadLine();
            string[] parts = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string p in parts)
            {
                int val;
                if (int.TryParse(p, out val)) linked.AddLast(val);
                else Console.WriteLine($"Пропущено некорректное значение: {p}");
            }

            Console.WriteLine("Текущий список: " + string.Join(", ", linked));

            Console.Write("Введите значение E (границы разворота): ");
            int e;
            while (!int.TryParse(Console.ReadLine(), out e))
            {
                Console.Write("Ошибка! Введите целое число: ");
            }

            Lab4Tasks.Task2_ReverseBetweenFirstAndLast(linked, e);
            Console.WriteLine("Список после разворота: " + string.Join(", ", linked));
        }
    }
}
