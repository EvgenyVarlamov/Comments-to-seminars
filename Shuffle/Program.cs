/* Написать функцию Shuffle, которая перемешивает элементы массива в случайном порядке. */

//Комментарий: Тут тоже смешивание ответственности. Print вызывается в Shuffle. Тогда это уже ShuffleAndPrint.

string[] text = { "данная", "функция", "перемешивает", "элементы", "массива", "в", "случайном", "порядке" };

Console.WriteLine();
PrintArray(text);
Console.WriteLine();
Shuffle(text);
PrintArray(text);
Console.WriteLine();

void PrintArray(string[] arr)
{
    Console.Write("Массив: ");
    for (int i = 0; i < arr.Length; i++)
    {
        Console.Write(arr[i] + " ");
    }
    Console.WriteLine();
}

void Shuffle(string[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        int index = new Random().Next(0, array.Length);
        string temp = array[i];
        array[i] = array[index];
        array[index] = temp;
    }
}
