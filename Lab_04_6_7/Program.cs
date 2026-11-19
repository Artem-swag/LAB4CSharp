namespace Lab_04_6_7
{
    internal class Program
    {
        static void Main()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("   ЛАБОРАТОРНАЯ РАБОТА №4 (Задания 6-7)");
                Console.WriteLine("   Класс: LineSegment (Отрезок)");
                Console.WriteLine("1. Задание 6 (Класс: конструкторы, свойства, метод)");
                Console.WriteLine("2. Задание 7 (Перегрузка операторов)");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите пункт меню: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        RunTask6();
                        break;
                    case "2":
                        RunTask7();
                        break;
                    case "0":
                        exit = true;
                        Console.WriteLine("Выход...");
                        break;
                    default:
                        Console.WriteLine("Неверный выбор.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
                    Console.ReadKey();
                }
            }
        }

        static void RunTask6()
        {
            Console.WriteLine("\n Задание 6: Тестирование класса ");

            Console.WriteLine("\n[Конструкторы]");
            LineSegment segDefault = new LineSegment();
            Console.WriteLine("По умолчанию: " + segDefault.ToString());

            double x = ReadDouble("Введите x начала отрезка: ");
            double y = ReadDouble("Введите y конца отрезка: ");
            LineSegment seg = new LineSegment(x, y);
            Console.WriteLine("С параметрами: " + seg.ToString());

            LineSegment segCopy = new LineSegment(seg);
            Console.WriteLine("Копия: " + segCopy.ToString());
            Console.WriteLine("Оригинал == Копия? " + (seg == segCopy));

            Console.WriteLine("\n[Свойства]");
            Console.WriteLine($"Текущие значения: X = {seg.X}, Y = {seg.Y}");
            double newX = ReadDouble("Введите новое значение для свойства X: ");
            seg.X = newX;
            Console.WriteLine("После изменения X: " + seg.ToString());

            Console.WriteLine("\n[Метод Contains]");
            double num = ReadDouble("Введите число для проверки попадания в отрезок: ");
            bool isContains = seg.Contains(num);
            Console.WriteLine($"Попадает ли {num} в отрезок {seg}? -> {isContains}");
        }

        static void RunTask7()
        {
            Console.WriteLine("\n Задание 7: Перегрузка операторов ");

            double x = ReadDouble("Введите x начала отрезка: ");
            double y = ReadDouble("Введите y конца отрезка: ");
            LineSegment seg = new LineSegment(x, y);
            Console.WriteLine($"Исходный отрезок: {seg}\n");

            Console.WriteLine("[Унарные операции]");
            Console.WriteLine($"Длина отрезка (!seg): {!seg}");

            LineSegment segInc = seg++;
            Console.WriteLine($"После ++ (сдвиг границ на 1): {segInc}");

            Console.WriteLine("\n[Приведение типов]");
            int intVal = (int)seg;     
            double doubleVal = seg;     
            Console.WriteLine($"Явное к int (целая часть x): {intVal}");
            Console.WriteLine($"Неявное к double (значение y): {doubleVal}");

            Console.WriteLine("\n[Бинарные операции]");
            int d = ReadInt("Введите целое число d для сдвига: ", -1000, 1000);

            LineSegment resRight = seg + d;
            LineSegment resLeft = d + seg;
            Console.WriteLine($"seg + {d} = {resRight}");
            Console.WriteLine($"{d} + seg = {resLeft}");

            int checkNum = ReadInt("\nВведите целое число для проверки попадания (оператор <): ", -1000, 1000);
            bool isContains = seg < checkNum;
            bool isNotContains = seg > checkNum;
            Console.WriteLine($"Попадает ли {checkNum} в отрезок (seg < {checkNum})? -> {isContains}");
            Console.WriteLine($"Не попадает (seg > {checkNum})? -> {isNotContains}");
        }

        static double ReadDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                double res;
                if (double.TryParse(input, out res)) return res;
                Console.WriteLine("Ошибка! Введите корректное дробное число.");
            }
        }

        static int ReadInt(string prompt, int min, int max)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();
                int res;
                if (int.TryParse(input, out res) && res >= min && res <= max) return res;
                Console.WriteLine($"Ошибка! Введите целое число от {min} до {max}.");
            }
        }
    }
}
