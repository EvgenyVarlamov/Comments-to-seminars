/* Задача 52. Задайте двумерный массив из целых чисел.
Найдите среднее арифметическое элементов в каждом столбце.
1 4 7 2
5 9 2 3
8 4 2 4
Среднее аривметическое каждого столбца 4,6 5,6 3,6 3 */

//Комментарий: Все те же самые комментарии

int m = Input("Введите количество столбцов массива: ");
int n = Input("Введите количество строк массива: ");

int[,] matrix = CreateArray(m, n);
PrintArray(matrix);
Average(matrix);

int Input(string size)
{
    Console.Write(size);
    return Convert.ToInt32(Console.ReadLine());
}

int[,] CreateArray(int column, int row)
{
    int[,] array = new int[column, row];

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = new Random().Next(0, 10);
        }
    }
    return array;
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

void Average(int[,] array)
{
    for (int i = 0; i < array.GetLength(1); i++)
    {
        float columnsSum = 0;
        for (int j = 0; j < array.GetLength(0); j++)
        {
            columnsSum += array[j, i];
        }
        float averageValue = Convert.ToSingle(Math.Round(columnsSum / array.GetLength(1), 1));
        Console.WriteLine("Среднее арифметическое столбца " + i + " равно " + averageValue);
    }
}