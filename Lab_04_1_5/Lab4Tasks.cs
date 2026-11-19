using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_04_1_5
{
    public static class Lab4Tasks
    {
        public static List<int> Task1_RemoveAllValue(List<int> L, int value)
        {
            if (L == null) throw new ArgumentNullException(nameof(L));
            for (int i = L.Count - 1; i >= 0; i--)
            {
                if (L[i] == value) L.RemoveAt(i);
            }
            return L;
        }

        public static LinkedList<int> Task2_ReverseBetweenFirstAndLast(LinkedList<int> L, int E)
        {
            if (L == null) throw new ArgumentNullException(nameof(L));

            LinkedListNode<int> first = null;
            LinkedListNode<int> last = null;
            LinkedListNode<int> current = L.First;

            while (current != null)
            {
                if (current.Value == E)
                {
                    if (first == null) first = current;
                    last = current;
                }
                current = current.Next;
            }

            if (first == null || first == last) return L;

            List<int> between = new List<int>();
            current = first.Next;
            while (current != null && current != last)
            {
                between.Add(current.Value);
                current = current.Next;
            }

            current = first.Next;
            for (int i = between.Count - 1; i >= 0; i--)
            {
                current.Value = between[i];
                current = current.Next;
            }

            return L;
        }

        public static void Task3_Films()
        {
            HashSet<string> allFilms = new HashSet<string> { "Матрица", "Начало", "Интерстеллар", "Титаник", "Аватар" };
            int n = ReadInt("Введите количество зрителей: ", 1, 100);
            List<HashSet<string>> viewers = new List<HashSet<string>>();

            for (int i = 0; i < n; i++)
            {
                HashSet<string> userFilms = new HashSet<string>();
                Console.WriteLine($"Зритель {i + 1}. Вводите фильмы (Enter - завершить):");
                while (true)
                {
                    string input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input)) break;
                    if (allFilms.Contains(input)) userFilms.Add(input);
                    else Console.WriteLine("Такого фильма нет в перечне.");
                }
                viewers.Add(userFilms);
            }

            HashSet<string> all = new HashSet<string>(allFilms);
            HashSet<string> some = new HashSet<string>();

            foreach (var v in viewers)
            {
                all.IntersectWith(v);
                some.UnionWith(v);
            }

            HashSet<string> none = new HashSet<string>(allFilms);
            none.ExceptWith(some);

            Console.WriteLine("\nСмотрели ВСЕ: " + string.Join(", ", all));
            Console.WriteLine("Смотрел ХОТЯ БЫ ОДИН: " + string.Join(", ", some));
            Console.WriteLine("Не смотрел НИКТО: " + string.Join(", ", none));
        }

        public static void Task4_SonorantConsonants()
        {
            Console.WriteLine("Введите текст на русском языке:");
            string text = Console.ReadLine();

            string sonorant = "бвгджзлмнр";
            Dictionary<char, int> letterWordCount = new Dictionary<char, int>();
            foreach (char c in sonorant) letterWordCount[c] = 0;

            List<string> words = new List<string>();
            StringBuilder sb = new StringBuilder();
            foreach (char c in text)
            {
                if (char.IsLetter(c)) sb.Append(char.ToLower(c));
                else if (sb.Length > 0) { words.Add(sb.ToString()); sb.Clear(); }
            }
            if (sb.Length > 0) words.Add(sb.ToString());

            foreach (string word in words)
            {
                foreach (char c in sonorant)
                {
                    if (word.IndexOf(c) >= 0) letterWordCount[c]++;
                }
            }

            List<char> result = new List<char>();
            foreach (var kvp in letterWordCount)
            {
                if (kvp.Value > 1) result.Add(kvp.Key);
            }
            result.Sort();

            Console.WriteLine("Звонкие согласные, входящие более чем в одно слово:");
            foreach (char c in result) Console.Write(c + " ");
            Console.WriteLine();
        }

        public static void Task5_AverageEmployees()
        {
            Console.WriteLine("Введите количество сотрудников N:");
            int n = ReadInt("", 1, 10000);

            Dictionary<string, int> departments = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Сотрудник {i + 1}. Формат: Фамилия И.О. XXX-XX-XX");
                string line = Console.ReadLine();
                string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length != 3)
                {
                    Console.WriteLine("Ошибка: неверный формат. Повторите ввод.");
                    i--; continue;
                }

                string phone = parts[2];
                string digits = "";
                foreach (char c in phone)
                {
                    if (char.IsDigit(c)) digits += c;
                }

                if (digits.Length != 7)
                {
                    Console.WriteLine("Ошибка: в телефоне должно быть 7 цифр.");
                    i--; continue;
                }

                string deptKey = digits.Substring(0, 5);
                if (departments.ContainsKey(deptKey)) departments[deptKey]++;
                else departments[deptKey] = 1;
            }

            double average = (double)n / departments.Count;
            Console.WriteLine($"Среднее количество сотрудников: {average:F2}");
        }

        private static int ReadInt(string prompt, int min, int max)
        {
            while (true)
            {
                if (!string.IsNullOrEmpty(prompt)) Console.Write(prompt);
                string input = Console.ReadLine();
                int result;
                if (int.TryParse(input, out result) && result >= min && result <= max) return result;
                Console.WriteLine($"Некорректный ввод. Введите число от {min} до {max}.");
            }
        }
    }
}
