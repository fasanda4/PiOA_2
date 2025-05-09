using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Lab12_Variant1
{
    class Program
    {
        // Константа — количество строк, выводимых на одну "страницу" консоли
        const int pageSize = 10;

        static void Main()
        {
            string choice = ""; // Переменная для хранения выбора пользователя

            // Бесконечный цикл для отображения текстового меню
            while (true)
            {
                Console.Clear(); // Очистка экрана перед выводом меню

                // Вывод пунктов меню
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Прочитать файл и вывести предложения в обратном порядке");
                Console.WriteLine("2. Выйти");
                Console.Write("Выберите пункт меню: ");

                choice = Console.ReadLine(); // Считывание выбора пользователя

                // Обработка выбора пользователя
                switch (choice)
                {
                    case "1":
                        ReadFileAndDisplay(); // Вызов метода для чтения и отображения файла
                        break;
                    case "2":
                        Console.WriteLine("Завершение...");
                        return; // Завершение работы программы
                    default:
                        // Обработка неправильного ввода
                        Console.WriteLine("Неверный выбор. Нажмите любую клавишу...");
                        Console.ReadKey(); // Ожидание ввода перед повтором
                        break;
                }
            }
        }

        // Метод для чтения строк из файла и вывода их в консоль в обратном порядке
        static void ReadFileAndDisplay()
        {
            Console.Clear();

            string filePath = ""; // Полный путь к файлу
            string fileName = ""; // Имя файла, введённое пользователем
            string line = "";     // Переменная для чтения строк из файла
            int i = 0;            // Счётчик для вывода постранично

            // Список строк, считанных из файла
            List<string> lines = new List<string>();

            // Цикл запроса имени файла до тех пор, пока файл действительно не будет найден
            while (true)
            {
                Console.Write("Введите имя файла без расширения (например, text_01): ");
                fileName = Console.ReadLine(); // Ввод имени файла без расширения
                filePath = Path.Combine(Environment.CurrentDirectory, fileName + ".txt"); // Полный путь к файлу

                if (File.Exists(filePath)) // Проверка существования файла
                    break;
                else
                    Console.WriteLine("Файл не найден. Повторите ввод."); // Предупреждение при ошибке
            }

            // Открываем файл на чтение с кодировкой Windows-1251 (ANSI)
            using (StreamReader reader = new StreamReader(filePath, Encoding.GetEncoding(1251)))
            {
                // Читаем файл построчно и добавляем строки в список
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            // Меняем порядок строк на обратный
            lines.Reverse();

            // Цикл постраничного вывода строк
            for (i = 0; i < lines.Count; i++)
            {
                Console.WriteLine(lines[i]); // Вывод строки

                // После вывода pageSize строк — пауза и очистка экрана
                if ((i + 1) % pageSize == 0 && i != lines.Count - 1)
                {
                    Console.WriteLine("Вывести текст далее... (нажмите любую клавишу)");
                    Console.ReadKey(); // Ожидание нажатия клавиши
                    Console.Clear();   // Очистка консоли перед следующей "страницей"
                }
            }

            // Завершающее сообщение
            Console.WriteLine("\nКонец файла. Нажмите любую клавишу для возврата в меню.");
            Console.ReadKey();
        }
    }
}
