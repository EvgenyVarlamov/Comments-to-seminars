/* Конвертер валют. У пользователя есть баланс в каждой из представленных валют. 
С помощью команд он может попросить сконвертировать одну валюту в другую. 
Курс конвертации просто описать в программе. 
Программа заканчивает свою работу в тот момент, когда решит пользователь. */

/* Комментарии: Сама конвертация сделана довольно неудобно. Нужно обязательно 
указать сколько я хочу конвертировать каждой валюты в целевую. Обычно переводится одна в другую.
Понятными названиями можно избавиться от комментариев */

string[] money = { "RUB", "CNY", "BRL", "INR", "ZAR" };
double[] balance = new double[money.Length];
string[] commandList = { "Баланс", "Конвертация", "Помощь", "Выход" };
string[] exchange = { "RUB", "CNY", "BRL", "INR", "ZAR", "Выход" };
//////////////////////////////RUB   CNY   BRL   INR   ZAR
double[,] exchangeRates = {{ 1, 0.103, 0.077, 1.16, 0.246 },    // RUB
                           { 9.708, 1, 0.754, 11.2, 2.39 },     // CNY
                           { 12.987, 1.326, 1, 11.84, 3.16 },   // BRL
                           { 0.862, 0.089, 0.084, 1, 0.214 },   // INR
                           { 4.065, 0.418, 0.316, 4.672, 1 }};  // ZAR

string message = "Вы можете узнать свой текущий баланс, а также произвести конвертацию имеющихся валют на любую доступную сумму.";

MoneyTransfer(balance);

string? password = "123";
int tryOpen = 3;
Console.WriteLine("Введите пароль: ");

for (int i = 1; i <= tryOpen; i++)
{
    Console.Write($"Ваша {i}-я попытка: ");
    if (Console.ReadLine() == password)
    {
        Console.WriteLine("Пароль введен правильно");
        Console.WriteLine();
        Console.WriteLine("Личный кабинет:");
        Console.WriteLine();
        while (true)
        {
            Console.Write("Главное меню > ");
            int command = MenuCommandList("", commandList);
            Console.WriteLine();
            if (command == 0)
            {
                PrintBalanse(money, balance);
            }
            else if (command == 1)
            {
                while (true)
                {
                    PrintBalanse(money, balance);
                    Console.Write("Подменю конвертации > ");
                    int convertCommandTo = MenuCommandList(" для выбора конвертации в валюту", exchange);
                    Console.WriteLine();
                    if (convertCommandTo == exchange.Length - 1)
                    {
                        Console.WriteLine("Выход из подменю конвертации");
                        Console.WriteLine();
                        break;
                    }
                    Console.Write("Подменю конвертации > ");
                    int convertCommandFrom = MenuCommandList(" для конвертации из валюты", exchange);
                    Console.WriteLine();
                    if (convertCommandFrom == exchange.Length - 1)
                    {
                        Console.WriteLine("Выход из подменю конвертации");
                        Console.WriteLine();
                        break;
                    }
                    else if (convertCommandTo < exchange.Length)
                    {
                        double amountTo = CheckInput($"Введите сумму валюты {money[convertCommandFrom]}: ", money, balance, convertCommandFrom);
                        CurrencyConverter(balance, exchangeRates, convertCommandTo, amountTo, convertCommandFrom);
                        Console.WriteLine("Конвертация завершена");
                        Console.WriteLine();
                    }
                }
            }
            else if (command == 2)
            {
                Console.WriteLine(message);
                Console.WriteLine();
            }
            else if (command == 3)
            {
                Console.WriteLine("Работа с программой завершена");
                break;
            }
        }
        break;
    }
    else if (i == tryOpen)
    {
        Console.WriteLine("Доступ заблокирован");
    }
}

void MoneyTransfer(double[] moneyBalance)
{
    for (int i = 0; i < moneyBalance.Length; i++)
    {
        moneyBalance[i] = Math.Round(new Random().NextDouble() * 1000000, 2);
    }
}

void PrintBalanse(string[] moneyNames, double[] moneyBalance)
{
    Console.WriteLine("Ваш баланс:");
    for (int i = 0; i < moneyNames.Length; i++)
    {
        Console.WriteLine(moneyNames[i] + ": " + Math.Round(moneyBalance[i], 2));
    }
    Console.WriteLine();
}

int MenuCommandList(string data, string[] commands)
{
    int subCommand = 0;
    while (true)
    {
        Console.WriteLine($"Список команд{data}:");

        for (int i = 0; i < commands.Length; i++)
        {
            Console.Write($"<{commands[i]}({i})> ");
        }
        Console.WriteLine();
        Console.Write($"Введите номер команды (указан в скобках): ");
        subCommand = Convert.ToInt32(Console.ReadLine());
        if (subCommand > commands.Length - 1)
        {
            Console.WriteLine($"Такой команды не существует");
        }
        else
        {
            break;
        }
    }
    return subCommand;
}

double CheckInput(string data, string[] moneyNames, double[] moneyBalance, int moneyCodeFrom)
{
    double amount = 0;
    while (true)
    {
        Console.Write(data);
        amount = Convert.ToDouble(Console.ReadLine());
        if (amount > moneyBalance[moneyCodeFrom])
        {
            Console.WriteLine($"Ваш баланс: {moneyNames[moneyCodeFrom]}: {moneyBalance[moneyCodeFrom]}");
        }
        else
        {
            break;
        }
    }
    return amount;
}

void CurrencyConverter(double[] moneyBalance, double[,] rates, int moneyCodeTo, double amount, int moneyCodeFrom)
{
    moneyBalance[moneyCodeTo] += rates[moneyCodeTo, moneyCodeFrom] * amount;
    moneyBalance[moneyCodeFrom] -= amount;
}