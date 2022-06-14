/*Программа для ведения досье работников. Есть 3 массива: фио, должность и зарплата.
В программе должна быть возможность добавить досье, вывести все досье в формате 
фио-должность-зп (Иванов Иван Иванович – кассир – 25 000), удалить досье
по номеру (номера начинаются с 1), поиск досье по фамилии.
Дополнительно: вывод всех досье с зп меньше или больше указанной,
вывод всех досье с указанной должностью. Можно придумать еще свои команды.*/

string[] name = { "Иванов Иван Иванович", "Гаджиева Милана Сергеевна", "Плиев Георгий Аланович", "Рафикова Альбина Ивановна", "Кумсишвили Мамука Иосифович" };
string[] position = { "кассир", "бухгалтер", "кассир", "финансист", "продавец-кассир" };
string[] salary = { "25 000", "29 999,99", "25 000", "32 999,99", "27 000" };

Console.WriteLine();
PrintDossier(name, position, salary);
Console.WriteLine();
name = AddDossier($"Введите ФИО сотрудника для добавления в досье: ", name);
position = AddDossier($"Введите должность: ", position);
salary = AddDossier($"Введите должностной оклад: ", salary);
Console.WriteLine();
SearchDossier(name, position, salary);
Console.WriteLine();
Console.Write("Введите номер сотрудника для удаления из досье: ");
int number = Convert.ToInt32(Console.ReadLine());
name = RemoveDossier(number, name);
position = RemoveDossier(number, position);
salary = RemoveDossier(number, salary);
PrintDossier(name, position, salary);
Console.WriteLine();
Console.Write("Введите размер оклада, выше которого нужно вывести досье: ");
double sal = Convert.ToInt32(Console.ReadLine());
FiltrIncreaseSalaryDossier(sal, name, position, salary);
Console.Write("Введите размер оклада, ниже которого нужно вывести досье: ");
Console.WriteLine();
sal = Convert.ToInt32(Console.ReadLine());
FiltrDecreaseSalaryDossier(sal, name, position, salary);
Console.WriteLine();
FiltrByPositionDossier(name, position, salary);
Console.WriteLine();
salary=Promotion(name, position, salary);
PrintDossier(name, position, salary);

void PrintDossier(string[] dossierName, string[] dossierPosition, string[] dossierSalary)
{
    for (int i = 0; i < dossierName.Length; i++)
    {
        Console.WriteLine($"{i + 1}) {dossierName[i]} - {dossierPosition[i]} - {dossierSalary[i]}");
    }
}

void SearchDossier(string[] dossierName, string[] dossierPosition, string[] dossierSalary)
{
    Console.Write($"Введите ФИО сотрудника, которого ищите: ");
    string searchName = Console.ReadLine() + "";
    int check = 0;
    for (int i = 0; i < name.Length; i++)
    {
        if (searchName == dossierName[i])
        {
            Console.WriteLine($"{i + 1}) {dossierName[i]} - {dossierPosition[i]} - {dossierSalary[i]}");
            check++;
        }
    }
    if (check == 0)
    {
        Console.WriteLine($"Сотрудник <{searchName}> не найден");
    }
}

string[] AddDossier(string data, string[] dossier)
{
    Console.Write(data);
    string input = Console.ReadLine() + "";
    Array.Resize(ref dossier, dossier.Length + 1);
    dossier[dossier.Length - 1] = input;
    return dossier;
}

string[] RemoveDossier(int input, string[] dossier)
{
    string[] newDossier = new string[dossier.Length - 1];
    int index = 0;
    for (int i = 0; i < dossier.Length; i++)
    {
        if (i != input - 1)
        {
            newDossier[index] = dossier[i];
            index++;
        }
        else
        {
            continue;
        }
    }
    return newDossier;
}

void FiltrIncreaseSalaryDossier(double input, string[] dossierName, string[] dossierPosition, string[] dossierSalary)
{
    int index = 0;
    for (int i = 0; i < dossierSalary.Length; i++)
    {
        if (input < Convert.ToDouble(dossierSalary[i]))
        {
            Console.WriteLine($"{index + 1}) {dossierName[i]} - {dossierPosition[i]} - {dossierSalary[i]}");
            index++;
        }
    }
}

void FiltrDecreaseSalaryDossier(double input, string[] dossierName, string[] dossierPosition, string[] dossierSalary)
{
    int index = 0;
    for (int i = 0; i < dossierSalary.Length; i++)
    {
        if (input > Convert.ToDouble(dossierSalary[i]))
        {
            Console.WriteLine($"{index + 1}) {dossierName[i]} - {dossierPosition[i]} - {dossierSalary[i]}");
            index++;
        }
    }
}

void FiltrByPositionDossier(string[] dossierName, string[] dossierPosition, string[] dossierSalary)
{
    Console.Write($"Введите должность, по которой нужно ввести досье: ");
    string searchPosition = Console.ReadLine() + "";
    int check = 0;
    for (int i = 0; i < name.Length; i++)
    {
        if (searchPosition == dossierPosition[i])
        {
            Console.WriteLine($"{i + 1}) {dossierName[i]} - {dossierPosition[i]} - {dossierSalary[i]}");
            check++;
        }
    }
    if (check == 0)
    {
        Console.WriteLine($"Должность <{searchPosition}> не найдена");
    }
}

string[] Promotion(string[] dossierName, string[] dossierPosition, string[] dossierSalary)
{
    Console.Write($"Введите ФИО сотрудника, которому нужно повысить зарплату: ");
    string searchName = Console.ReadLine() + "";
    Console.Write($"Введите новый размер оклада: ");
    string newSalary = Console.ReadLine() + "";
    int check = 0;
    for (int i = 0; i < name.Length; i++)
    {
        if (searchName == dossierName[i])
        {
            dossierSalary[i]=newSalary;
            Console.WriteLine($"{i + 1}) {dossierName[i]} - {dossierPosition[i]} - {dossierSalary[i]}");
            check++;
        }
    }
    if (check == 0)
    {
        Console.WriteLine($"Сотрудник <{searchName}> не найден");
    }
    return dossierSalary;
}