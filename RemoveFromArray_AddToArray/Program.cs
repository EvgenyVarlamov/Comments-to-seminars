/* Написать 2 функции для работы с массивом: AddToArray И RemoveFromArray – первая 
добавляет к числовому массиву значение, тем самым увеличивая массив, 
а вторая удаляет элемент под нужным индексом и уменьшает массив на 1. */

/*Комментарий: С добавлением все более менее хорошо
Удаление очень смешанная команда. Она и проверку делает и вывод. По сути три маленьких команды под одним именем.
Методы понадобятся в дальнейших доп задачах, поэтому удобнее всего сигнатура: void RemoveFromArray/AddToArray (array, index, value).
А проверки и выводы уходят под ответственность других команд или основной программы
На самом деле выглядит так, будто когда вы писали последний метод, решили дописать в нем всю остальную программу.*/

Console.WriteLine();
int length = Input("Введите размер массива: ");
int[] arrayCurrent = new int[length];

FillArray(arrayCurrent);
Console.WriteLine("Текущий массив: ");
PrintArray(arrayCurrent);

Console.WriteLine();
int newValue = Input("Введите значение нового элемента массива: ");
int addElement = 1;
int position = CheckInput("Введите индекс нового элемента массива: ", arrayCurrent, addElement);
Console.WriteLine("Увеличеный массив: ");
arrayCurrent = AddToArray(arrayCurrent, position, newValue);
PrintArray(arrayCurrent);

Console.WriteLine();
addElement = 0;
position = CheckInput("Введите индекс элемента массива, который нужно удалить: ", arrayCurrent, addElement);
Console.WriteLine("Сокращенный массив: ");
arrayCurrent = RemoveFromArray(arrayCurrent, position);
Console.WriteLine();
PrintArray(arrayCurrent);

int Input(string data)
{
    Console.Write(data);
    return Convert.ToInt32(Console.ReadLine());
}

int CheckInput(string data, int[] array, int add)
{
    int index = 0;
    while (true)
    {
        Console.Write(data);
        index = Convert.ToInt32(Console.ReadLine());
        if (index >= array.Length + add)
        {
            Console.WriteLine($"Индекс не должен быть больше {array.Length}");
        }
        else
        {
            break;
        }
    }
    return index;
}

void FillArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        array[i] = new Random().Next(0, 10);
    }
}

void PrintArray(int[] array)
{
    Console.Write("{ ");
    for (int i = 0; i < array.Length - 1; i++)
    {
        Console.Write(array[i] + ", ");
    }
    Console.Write(array[array.Length - 1] + " }");
    Console.WriteLine();
}

int[] AddToArray(int[] array, int index, int value)
{
    int[] arrayPlus = new int[array.Length + 1];
    int increase = 0;
    for (int i = 0; i < arrayPlus.Length; i++)
    {
        if (i == index)
        {
            arrayPlus[index] = value;
            increase = 1;
            continue;
        }
        else
        {
            arrayPlus[i] = array[i - increase];
        }
    }

    return arrayPlus;
}

int[] RemoveFromArray(int[] array, int index)
{
    int[] arrayMinus = new int[array.Length - 1];
    int count = 0;

    for (int i = 0; i < array.Length; i++)
    {
        if (i == index)
        {
            continue;
        }
        arrayMinus[count] = array[i];
        count++;
    }
    return arrayMinus;
}