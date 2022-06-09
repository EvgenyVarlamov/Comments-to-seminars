/* Задача 50. Напишите программу, которая на вход принимает
позиции элемента в двумерном массиве, и возвращает значение
этого элемента иле же указание, что такого элемента нет.
1 4 7 2
5 9 2 3
8 4 2 4
1,7 -> такого числа в массиве нет */

/* Комментарий: Тоже вычисления из вывода лучше вынести в отдельные переменные
 Комментарии всегда можно заменить на методы с понятными названиями https://gb.ru/lessons/226643/homework */


int m = Input("Введите столбец, от 0 и выше: ");
int n = Input("Введите строку, от 0 и выше: ");
int columns = new Random().Next(2, 10);
int rows = new Random().Next(2, 10);
int[,] matrix = new int[columns, rows];

FillArray(matrix);
PrintArray(matrix);
CheckAndCalculation(matrix, m, n);

int Input(string size)
{
    Console.Write(size);
    return Convert.ToInt32(Console.ReadLine());
}

void FillArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = new Random().Next(1, 10);
        }
    }
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i, j] + " ");
        }
        Console.WriteLine();
    }
}

void CheckAndCalculation(int[,] array, int column, int row)
{
    if (column < array.GetLength(0) && row < array.GetLength(1))
    {
        Console.WriteLine($"Элемент массива [{column},{row}] = {array[column, row]}");
    }
    else
    {
        Console.WriteLine($"Размер массива {array.GetLength(0)}x{array.GetLength(1)}");
        Console.Write($"Последний элемент массива [{array.GetLength(0) - 1},{array.GetLength(1) - 1}]");
        Console.WriteLine($" = {array[array.GetLength(0) - 1, array.GetLength(1) - 1]}");
        Console.WriteLine($"Введенной вами позиции [{column},{row}] в массиве не существует");
    }
}