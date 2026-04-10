using System;

namespace DoublyLinkedListApp
{
    class Program
    {
        static CustomDoublyLinkedList GetList()
        {
            var list = new CustomDoublyLinkedList();

            Console.WriteLine("Оберіть спосіб заповнення списку:");
            Console.WriteLine("1 - Згенерувати випадковий масив");
            Console.WriteLine("2 - Задати вручну");
            Console.Write("-> ");

            string choice = Console.ReadLine();

            while (true)
            {
                if (choice == "1")
                {
                    Console.Write("Введіть кількість елементів -> ");
                    if (int.TryParse(Console.ReadLine(), out int n) && n > 0)
                    {
                        Random rnd = new Random();
                        for (int i = 0; i < n; i++)
                        {
                            double val = Math.Round(rnd.NextDouble() * 100 - 50, 2);
                            list.AddFirst(val);
                        }
                    }
                    break;
                }
                else if (choice == "2")
                {
                    Console.Write("Введіть числа (через пробіл). Кожне наступне число буде додаватись на ПОЧАТОК списку -> ");
                    string[] inputs = Console.ReadLine()?.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (inputs != null)
                    {
                        foreach (var input in inputs)
                        {
                            if (double.TryParse(input.Replace('.', ','), out double val))
                            {
                                list.AddFirst(val);
                            }
                        }
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Помилка! Будь ласка, введыть коректне значення!");
                }
            }

            return list;
        }

        static void Task1(TaskSolver solver, CustomDoublyLinkedList list)
        {
            var firstLessThanAvg = solver.FindFirstLessThanAverage();

            double avg = 0;
            foreach (var item in list) avg += item;
            avg /= list.Count;

            Console.WriteLine($"\n1. Середнє значення: {Math.Round(avg, 2)}");

            if (firstLessThanAvg.HasValue)
            {
                Console.WriteLine($"   Перше входження елементу меншого за середнє: {firstLessThanAvg.Value.Value}");
                Console.WriteLine($"   Індекс цього елементу: {firstLessThanAvg.Value.Index}");
            }
            else
            {
                Console.WriteLine("   Такого елементу не знайдено.");
            }
        }

        static void Task2(TaskSolver solver)
        {
            double sumAfterMax = solver.SumAfterMax();
            Console.WriteLine($"\n2. Сума елементів після максимального: {Math.Round(sumAfterMax, 2)}");
        }

        static void Task3(TaskSolver solver)
        {
            Console.Write("\n3. Введіть значення для фільтрації нового списку -> ");
            if (double.TryParse(Console.ReadLine()?.Replace('.', ','), out double threshold))
            {
                var newList = solver.GetListGreaterThan(threshold);
                Console.Write("   Створений список: ");
                newList.Print();
            }
        }

        static void Task4(TaskSolver solver, CustomDoublyLinkedList list)
        {
            Console.WriteLine("\n4. Видалення елементів, які розташовані до максимального");
            solver.RemoveBeforeMax();
            Console.Write("   Створений список: ");
            list.Print();
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            var list = GetList();

            Console.WriteLine("\n--- Поточний список ---");
            list.Print();

            var solver = new TaskSolver(list);

            Task1(solver, list);
            Task2(solver);
            Task3(solver);
            Task4(solver, list);
        }
    }
}