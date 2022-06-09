/* Задача 60: Сформируйте трёхмерный массив из неповторяющихся 
двузначных чисел. Напишите программу, которая будет построчно 
выводить массив, добавляя индексы каждого элемента.*/

//Комментарий: Числа повторяются

int length = Input("Введите длину масива: ");
int width = Input("Введите ширину масива: ");
int height = Input("Введите высоту масива: ");

double[,,] numbers = new double[height, width, length];

FillArray(numbers);
Console.WriteLine();
Console.WriteLine("Вывод массива:");
PrintArray(numbers);

int Input(string size)
{
    Console.Write(size);
    return Convert.ToInt32(Console.ReadLine());
}

void FillArray(double[,,] array)
{
    double count = 10.0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                array[i, j, k] = Math.Round(count, 1);
                count += 0.1;
            }
        }
    }
}

void PrintArray(double[,,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                Console.Write($"{array[i, j, k]}[{i},{j},{k}] ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}