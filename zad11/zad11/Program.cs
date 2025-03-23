using System;

class Program
{
    static void Main()
    {
        // Инициализация переменных для хранения размеров массива
        int rows = 0, cols = 0;        // Количество строк и столбцов исходного массива
        bool increaseSize;             // Флаг направления изменения размерности (true - увеличение, false - уменьшение)
        double[,] originalArray = null;// Инициализация массива заданного размера (изначально null)

        // Ввод количества строк с проверкой корректности
        Console.WriteLine("Введите количество строк исходного массива:");
        // Цикл продолжается до тех пор, пока пользователь не введет целое положительное число
        while (!int.TryParse(Console.ReadLine(), out rows) || rows <= 0)
        {
            Console.WriteLine("Ошибка! Введите целое положительное число:");
        }

        // Ввод количества столбцов с аналогичной проверкой
        Console.WriteLine("Введите количество столбцов исходного массива:");
        while (!int.TryParse(Console.ReadLine(), out cols) || cols <= 0)
        {
            Console.WriteLine("Ошибка! Введите целое положительное число:");
        }

        // Создание двумерного массива и его заполнение
        originalArray = new double[rows, cols]; // Выделение памяти для массива после получения корректных размеров
        Console.WriteLine("Введите элементы массива (вещественные числа):");
        // Внешний цикл для перебора строк
        for (int i = 0; i < rows; i++)
        {
            // Внутренний цикл для перебора столбцов
            for (int j = 0; j < cols; j++)
            {
                // Проверка ввода: цикл продолжается, пока пользователь не введет вещественное число
                while (!double.TryParse(Console.ReadLine(), out originalArray[i, j]))
                {
                    Console.WriteLine("Ошибка! Введите вещественное число:");
                }
            }
        }

        // Ввод направления изменения размерности массива
        Console.WriteLine("Увеличить размерность? (true/false):");
        // Проверка ввода: только "true" или "false"
        while (!bool.TryParse(Console.ReadLine(), out increaseSize))
        {
            Console.WriteLine("Ошибка! Введите 'true' или 'false':");
        }

        // Вызов метода изменения размерности массива
        // Передача массива по ссылке (ref) позволяет изменить его внутри метода
        _aResizeArray(ref originalArray, increaseSize);

        // Вывод измененного массива с форматированием
        Console.WriteLine("Измененный массив:");
        // Цикл для перебора строк измененного массива
        for (int i = 0; i < originalArray.GetLength(0); i++)
        {
            string row = "| "; // Начало строки с левым разделителем
            // Цикл для перебора столбцов
            for (int j = 0; j < originalArray.GetLength(1); j++)
            {
                // Форматирование элемента: два знака после запятой (например, 5 → 5.00)
                row += $"{originalArray[i, j]:F2} ";
            }
            row = row.TrimEnd() + " |"; // Удаление последнего пробела и добавление правого разделителя
            Console.WriteLine(row);      // Вывод строки
        }
        Console.ReadKey(); // Ожидание нажатия клавиши для завершения
    }

    /// <summary>
    /// Изменяет размерность двумерного массива на +1 или -1 по каждому измерению.
    /// </summary>
    /// <param name="array">Исходный массив (передается по ссылке)</param>
    /// <param name="increase">true — увеличение размерности, false — уменьшение</param>
    static void _aResizeArray(ref double[,] array, bool increase)
    {
        // Проверка на null: если массив не существует, выводим ошибку и завершаем метод
        if (array == null)
        {
            Console.WriteLine("Ошибка: массив не существует!");
            return;
        }

        // Получение текущих размеров массива
        int oldRows = array.GetLength(0); // Количество строк
        int oldCols = array.GetLength(1); // Количество столбцов

        // Расчет новых размеров:
        // - При увеличении: добавляем 1 к каждому измерению
        // - При уменьшении: вычитаем 1, но не меньше 0 (защита от отрицательных значений)
        int newRows = increase ? oldRows + 1 : Math.Max(oldRows - 1, 0);
        int newCols = increase ? oldCols + 1 : Math.Max(oldCols - 1, 0);

        // Создание нового массива с вычисленными размерами
        double[,] newArray = new double[newRows, newCols];

        // Определение границ копирования:
        // Копируем столько строк и столбцов, сколько возможно (минимум из старого и нового размеров)
        int copyRows = Math.Min(oldRows, newRows);
        int copyCols = Math.Min(oldCols, newCols);

        // Копирование данных из старого массива в новый
        for (int i = 0; i < copyRows; i++)
        {
            for (int j = 0; j < copyCols; j++)
            {
                newArray[i, j] = array[i, j]; // Перенос элемента
            }
        }

        // Замена исходного массива новым (работает благодаря передаче по ссылке)
        array = newArray;
    }
}