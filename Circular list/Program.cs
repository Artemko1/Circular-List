using System;

public class Program
{
    static void Main(string[] args)
    {
        List list = new List();
        bool isInt;
        bool stop = false;

        //Начальное добавление элементов
        Console.WriteLine("Введите элементы для заполнения списка по одному.");
        Console.WriteLine("Чтобы прекратить ввод введите не число.");
        do
        {
            Console.Write("Число: ");
            isInt = ParseInputToInt(out int data);
            if (isInt)
            {
                list.Add(data);
            }
        } while (isInt == true);
        Console.WriteLine("Ввод окончен.");

        do
        {
            Console.WriteLine();
            Console.WriteLine("Список элементов:");
            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            Console.WriteLine("Чтобы найти элемент, введите 'Найти'.");
            Console.WriteLine("Чтобы удалить элемент, введите 'Удалить'.");
            Console.WriteLine("Введите произвольный текст для выхода.");
            Console.Write("Команда: ");
            string str = Console.ReadLine();
            if (str == "Удалить")
            {
                Console.WriteLine("Выбрано Удаление. Напишите число для удаления.");
                Console.Write("Число: ");
                if (ParseInputToInt(out int data))
                {
                    list.Remove(data);
                }
            }
            else if (str == "Найти")
            {
                Console.WriteLine("Выбран Поиск. Напишите число для поиска.");
                Console.Write("Число: ");
                if (ParseInputToInt(out int data))
                {
                    if (list.Contains(data))
                    {
                        Console.WriteLine($"Число {data} присутствует в списке.");
                    }
                    else
                    {
                        Console.WriteLine($"Числа {data} нет в списке.");
                    }
                }
            }
            else
            {
                stop = true;
            }
        } while (!stop);

        Console.WriteLine("Нажмите любую клавишу для выхода.");
        Console.ReadKey(true);
    }

    private static bool ParseInputToInt(out int data)
    {
        string input = Console.ReadLine();

        return Int32.TryParse(input, out data);
    }


}