/*Написать программу со следующими командами:
- SetNumbers – пользователь вводит числа через пробел, а программа запоминает их в массив
- AddNumbers – пользователь вводит числа, которые добавятся к уже существующему массиву
- RemoveNumbers -  пользователь вводит числа, которые если  найдутся в массиве, то будут удалены
- Numbers – ввывод текущего массива
- Sum – найдется сумма всех элементов чисел*/

using System.Linq;

int[] numbers = SetNumbers("Введите элементы мавссива через пробел: ");
Numbers(numbers);
numbers = AddNumbers("Добавьте элементы массива через пробел: ", numbers);
Numbers(numbers);
numbers = RemoveNumbers("Введите числа для удаления из массива через пробел: ", numbers);
Numbers(numbers);
Console.WriteLine("Сумма элементов массива равна " + Sum(numbers));

int[] SetNumbers(string data)
{
    Console.Write(data);
    string input = Console.ReadLine() + "";
    int[] array = input.Split(" ").Select(int.Parse).ToArray();
    return array;
}

int[] AddNumbers(string data, int[] array)
{
    Console.Write(data);
    string input = Console.ReadLine() + "";
    int[] tempArray = input.Split(" ").Select(int.Parse).ToArray();
    int[] newArray = new int[array.Length + tempArray.Length];
    for (int i = 0; i < newArray.Length; i++)
    {
        if (i < array.Length)
        {
            newArray[i] = array[i];
        }
        else
        {
            newArray[i] = tempArray[i - array.Length];
        }
    }
    return newArray;
}

int[] RemoveNumbers(string data, int[] array)
{
    Console.Write(data);
    string input = Console.ReadLine() + "";
    int[] tempArray = input.Split(" ").Select(int.Parse).ToArray();
    int count = 0;
    int temp = -2147483648;
    for (int i = 0; i < tempArray.Length; i++)
    {
        for (int j = 0; j < array.Length; j++)
        {
            if (tempArray[i] == array[j])
            {
                array[j] = temp;
                count++;
            }
        }
    }

    int[] newArray = new int[array.Length - count];
    count = 0;

    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] != temp)
        {
            newArray[count] = array[i];
            count++;
        }
    }
    return newArray;
}

void Numbers(int[] array)
{
    Console.Write("{ ");
    for (int i = 0; i < array.Length - 1; i++)
    {
        Console.Write(array[i] + ", ");
    }
    Console.Write(array[array.Length - 1] + " }");
    Console.WriteLine();
}

int Sum(int[] array)
{
    int Sum = 0;
    for (int i = 0; i < array.Length; i++)
    {
        Sum += array[i];
    }
    return Sum;
}