using System;

class Program
{
    static void Main()
    {
        // Блок объявления всех переменных
        int size;                // Размер квадратной матрицы
        double[,] identityMatrix; // Единичная матрица E
        double[,] userMatrix;     // Пользовательская матрица P
        double[,] result;         // Результат умножения E * P

        
        // Основной код программы
        

        // Ввод размера матрицы
        Console.Write("Введите размер квадратной матрицы: ");
        while (!int.TryParse(Console.ReadLine(), out size) || size <= 0)
        {
            Console.WriteLine("Ошибка! Введите целое положительное число: ");
        }

        // Инициализация единичной матрицы
        identityMatrix = new double[size, size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                identityMatrix[i, j] = (i == j) ? 1 : 0;
            }
        }

        // Ввод элементов матрицы P
        userMatrix = new double[size, size];
        Console.WriteLine("Введите элементы матрицы P:");
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                Console.Write($"Элемент [{i + 1},{j + 1}]: ");
                while (!double.TryParse(Console.ReadLine(), out userMatrix[i, j]))
                {
                    Console.WriteLine("Ошибка! Введите число: ");
                }
            }
        }

        // Вычисление результата
        result = new double[size, size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                result[i, j] = identityMatrix[i, j] * userMatrix[i, j];
            }
        }

        // Вывод результатов
        
        Console.WriteLine("Исходная матрица P:");
        for (int i = 0; i < size; i++)
        {
            Console.Write("|");
            for (int j = 0; j < size; j++)
            {
                Console.Write($"{userMatrix[i, j],6:F2}");
            }
            Console.WriteLine(" |");
        }

        Console.WriteLine("\nРезультат умножения E * P:");
        for (int i = 0; i < size; i++)
        {
            Console.Write("|");
            for (int j = 0; j < size; j++)
            {
                Console.Write($"{result[i, j],6:F2}");
            }
            Console.WriteLine(" |");
        }

        Console.ReadKey(true);
    }
}