using System;


namespace unior
{
    internal class HomeWork6v2
    {
        public static void Main()
        {
            const string CommandDollarToRuble = "DollarToRuble";
            const string CommandDollarToTugriki = "DollarToTugriki";
            const string CommandRubleToTugriki = "RubleToTugriki";
            const string CommandRubleToDollar = "RubleToDollar";
            const string CommandTugrikiTodollar = "TugrikiTodollar";
            const string CommandTugrikiToRuble = "TugrikiToRuble";

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
                    $"{CommandDollarToRuble}\n{CommandDollarToTugriki}\n" +
                    $"{CommandRubleToTugriki}\n{CommandRubleToDollar}\n" +
                    $"{CommandTugrikiTodollar}\n{CommandTugrikiToRuble}\n");
                Console.WriteLine($"Если хотите выйти введите {stopWord}");
                input = Console.ReadLine();
                double wantConvert = 0;

                switch (input)
                {
                    case CommandDollarToRuble:
                        Console.Write($"Сколько хотите перевести? ");
                        wantConvert = double.Parse(Console.ReadLine());

                        if (IsBalancLessZero(balanceUSD, wantConvert))
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

                        if (IsBalancLessZero(balanceRUB, wantConvert))
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

                        if (IsBalancLessZero(balanceUSD, wantConvert))
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

                        if (IsBalancLessZero(balanceMNT, wantConvert))
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

                        if (IsBalancLessZero(balanceMNT, wantConvert))
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

                        if (IsBalancLessZero(balanceRUB, wantConvert))
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
        public static bool IsBalancLessZero(double balance, double stepBalance)
        {
            if (balance - stepBalance < 0)
            {
                Console.WriteLine("Баланс не может быть меньше 0\n" +
                    $"Текущий баланс: {balance}  Введите сумму конвертации Заново");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

