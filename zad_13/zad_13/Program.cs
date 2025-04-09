using System;

namespace WeekDaysEnum
{
    // Перечисление дней недели с обратными значениями идентификаторов
    enum WeekDays
    {
        Monday = 7,
        Tuesday = 6,
        Wednesday = 5,
        Thursday = 4,
        Friday = 3,
        Saturday = 2,
        Sunday = 1
    }

    class Program
    {
        static void Main(string[] args)
        {
            int currentDay = 7; // Начинаем с понедельника (значение 7)

            // Цикл с предусловием: выполняется, пока currentDay >= 1
            while (currentDay >= 1)
            {
                // Преобразование числа в элемент перечисления WeekDays
                WeekDays day = (WeekDays)currentDay;
                // Вывод названия дня
                Console.WriteLine(day);
                // Уменьшение значения для перехода к следующему дню
                currentDay--;
            }
        }
    }
}