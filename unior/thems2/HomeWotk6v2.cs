using System;

namespace unior
{
    internal class HomeWork6v2
    {
        public static void Main()
        {
            const string CommandDollarToRuble = "1";
            const string CommandDollarToTugriki = "2";
            const string CommandRubleToTugriki = "3";
            const string CommandRubleToDollar = "4";
            const string CommandTugrikiTodollar = "5";
            const string CommandTugrikiToRuble = "6";

            Console.Write($"Введите свой баланс RUB: ");
            double balanceRUB = double.Parse(Console.ReadLine());

            Console.Write($"Введите свой баланс USD: ");
            double balanceUSD = double.Parse(Console.ReadLine());

            Console.Write($"Введите свой баланс MNT: ");
            double balanceMNT = double.Parse(Console.ReadLine());

            string stopWord = "exit";
            string input = "";
            double ratioDollrToRuble = 97.97;
            double ratioRubleToTugriki = 35.18;
            double ratioDollarToTugriki = 3446;
            double ratioRubleToDollar = 1 / ratioDollrToRuble;
            double ratioTugrikiToRuble = 1 / ratioRubleToTugriki;
            double ratioTugrikiToDollar = 1 / ratioDollarToTugriki;

            while (input != stopWord)
            {
                Console.WriteLine($"Выберите что хотите конвертировать : \n" +
                    $"DollarToRuble - {CommandDollarToRuble}\n DollarToTugriki - {CommandDollarToTugriki}\n" +
                    $"RubleToTugriki - {CommandRubleToTugriki}\n RubleToDollar - {CommandRubleToDollar}\n" +
                    $"TugrikiTodollar - {CommandTugrikiTodollar}\n TugrikiToRuble - {CommandTugrikiToRuble}\n");
                Console.WriteLine($"Если хотите выйти введите {stopWord}");
                input = Console.ReadLine();
                double wantConvert = 0;

                switch (input)
                {
                    case CommandDollarToRuble:
                        Console.Write($"Сколько хотите перевести? ");
                        wantConvert = double.Parse(Console.ReadLine());

                        if (balanceUSD < wantConvert)
                        {
                            Console.WriteLine("Баланс не может быть меньше 0\n" +
                                $"Текущий баланс: {balanceUSD}  Введите сумму конвертации Заново");
                        }
                        else
                        {
                            balanceUSD -= wantConvert;
                            balanceRUB = wantConvert * ratioDollrToRuble;
                            Console.WriteLine($"Ваш баланс {balanceRUB} RUB {balanceUSD}" +
                                $" USD {balanceMNT} MNT\n");
                        }
                        break;

                    case CommandRubleToDollar:
                        Console.Write($"Сколько хотите перевести? ");
                        wantConvert = double.Parse(Console.ReadLine());

                        if (balanceRUB < wantConvert)
                        {
                            Console.WriteLine("Баланс не может быть меньше 0\n" +
                                $"Текущий баланс: {balanceRUB}  Введите сумму конвертации Заново");
                        }
                        else
                        {
                            balanceRUB -= wantConvert;
                            balanceUSD = wantConvert * ratioRubleToDollar;
                            Console.WriteLine($"Ваш баланс {balanceRUB} RUB {balanceUSD}" +
                                $" USD {balanceMNT} MNT\n");
                        }
                        break;

                    case CommandDollarToTugriki:
                        Console.Write($"Сколько хотите перевести? ");
                        wantConvert = double.Parse(Console.ReadLine());

                        if (balanceUSD < wantConvert)
                        {
                            Console.WriteLine("Баланс не может быть меньше 0\n" +
                                $"Текущий баланс: {balanceUSD}  Введите сумму конвертации Заново");
                        }
                        else
                        {
                            balanceUSD -= wantConvert;
                            balanceMNT = wantConvert * ratioDollarToTugriki;
                            Console.WriteLine($"Ваш баланс {balanceRUB} RUB {balanceUSD}" +
                                $" USD {balanceMNT} MNT\n");
                        }
                        break;

                    case CommandTugrikiTodollar:
                        Console.Write($"Сколько хотите перевести? ");
                        wantConvert = double.Parse(Console.ReadLine());

                        if (balanceMNT < wantConvert)
                        {
                            Console.WriteLine("Баланс не может быть меньше 0\n" +
                                $"Текущий баланс: {balanceMNT}  Введите сумму конвертации Заново");
                        }
                        else
                        {
                            balanceMNT -= wantConvert;
                            balanceUSD = wantConvert / ratioTugrikiToDollar;
                            Console.WriteLine($"Ваш баланс {balanceRUB} RUB {balanceUSD}" +
                                $" USD {balanceMNT} MNT\n");
                        }
                        break;

                    case CommandTugrikiToRuble:
                        Console.Write($"Сколько хотите перевести? ");
                        wantConvert = double.Parse(Console.ReadLine());

                        if (balanceMNT < wantConvert)
                        {
                            Console.WriteLine("Баланс не может быть меньше 0\n" +
                                $"Текущий баланс: {balanceMNT}  Введите сумму конвертации Заново");
                        }
                        else
                        {
                            balanceMNT -= wantConvert;
                            balanceRUB = wantConvert * ratioTugrikiToRuble;
                            Console.WriteLine($"Ваш баланс {balanceRUB} RUB {balanceUSD}" +
                                $" USD {balanceMNT} MNT\n");
                        }
                        break;

                    case CommandRubleToTugriki:
                        Console.Write($"Сколько хотите перевести? ");
                        wantConvert = double.Parse(Console.ReadLine());

                        if (balanceRUB < wantConvert)
                        {
                            Console.WriteLine("Баланс не может быть меньше 0\n" +
                                $"Текущий баланс: {balanceMNT}  Введите сумму конвертации Заново");
                        }
                        else
                        {
                            balanceRUB -= wantConvert;
                            balanceMNT = wantConvert * ratioRubleToTugriki;
                            Console.WriteLine($"Ваш баланс {balanceRUB} RUB {balanceUSD}" +
                                $" USD {balanceMNT} MNT\n");
                        }
                        break;
                }
            }
        }
    }
}

