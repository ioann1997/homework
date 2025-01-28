using System;


namespace unior
{
    internal class HomeWork6
    {
        public static void Main()
        {
            Console.Write($"Введите свой баланс {Currency.RUB}: ");
            double balanceRub = double.Parse(Console.ReadLine());
            
            Console.Write($"Введите свой баланс {Currency.USD}: ");
            double balanceUsd = double.Parse(Console.ReadLine()); 

            Console.Write($"Введите свой баланс {Currency.MNT}: ");
            double balanceMnt = double.Parse(Console.ReadLine());

            string stopWord = "exit";
            string commandStop = "";
            double ratioDollrToRuble = 97.97;
            double ratioRubleToTugriki = 35.18;
            double ratioDollarToTugriki = 3446;
            double ratioRubleToDollar = 1/ ratioDollrToRuble;
            double ratioTugrikiToRuble = 1/ ratioRubleToTugriki;
            double ratioTugrikiToDollar = 1/ ratioDollarToTugriki;
            

            while (commandStop != stopWord)
            {
                Console.WriteLine($"Выберите что хотите конвертировать : \n" +
                    $"{Converter.DollarToRuble}\n{Converter.DollarToTugriki}\n" +
                    $"{Converter.RubleToTugriki}\n{Converter.RubleToDollar}\n" +
                    $"{Converter.TugrikiTodollar}\n{Converter.TugrikiToRuble}\n");
                string input = Console.ReadLine();

                Converter converter = (Converter)Enum.Parse(typeof(Converter), input);

                Console.Write($"Сколько хотите перевести? ");
                double wantConvert = double.Parse(Console.ReadLine());
                
                switch (converter)
                {
                    case Converter.DollarToRuble:

                        if (CheckBalanceZero(balanceUsd, wantConvert))
                        {
                            balanceUsd -= wantConvert;
                            balanceRub = wantConvert * ratioDollrToRuble;
                            Console.WriteLine($"Ваш баланс {balanceRub} {Currency.RUB} {balanceUsd}" +
                                $" {Currency.USD} {balanceMnt} {Currency.MNT}\n");
                        }
                        break;

                    case Converter.RubleToDollar:

                        if (CheckBalanceZero(balanceRub, wantConvert))
                        {
                            balanceRub -= wantConvert;
                            balanceUsd = wantConvert * ratioRubleToDollar;
                            Console.WriteLine($"Ваш баланс {balanceRub} {Currency.RUB} {balanceUsd}" +
                                $" {Currency.USD} {balanceMnt} {Currency.MNT}\n");
                        }
                        break;

                    case Converter.DollarToTugriki:

                        if (CheckBalanceZero(balanceUsd, wantConvert))
                        {
                            balanceUsd -= wantConvert;
                            balanceMnt = wantConvert * ratioDollarToTugriki;
                            Console.WriteLine($"Ваш баланс {balanceRub} {Currency.RUB} {balanceUsd}" +
                                $" {Currency.USD} {balanceMnt} {Currency.MNT}\n");
                        }
                        break;

                    case Converter.TugrikiTodollar:

                        if (CheckBalanceZero(balanceMnt, wantConvert))
                        {
                            balanceMnt -= wantConvert;
                            balanceUsd = wantConvert / ratioTugrikiToDollar;
                            Console.WriteLine($"Ваш баланс {balanceRub} {Currency.RUB} {balanceUsd}" +
                                $" {Currency.USD} {balanceMnt} {Currency.MNT}\n");
                        }
                        break;

                    case Converter.TugrikiToRuble:

                        if (CheckBalanceZero(balanceMnt, wantConvert))
                        {
                            balanceMnt -= wantConvert;
                            balanceRub = wantConvert * ratioTugrikiToRuble;
                            Console.WriteLine($"Ваш баланс {balanceRub} {Currency.RUB} {balanceUsd}" +
                                $" {Currency.USD} {balanceMnt} {Currency.MNT}\n");
                        }
                        break;

                    case Converter.RubleToTugriki:

                        if (CheckBalanceZero(balanceRub, wantConvert))
                        {
                            balanceRub -= wantConvert;
                            balanceMnt = wantConvert * ratioRubleToTugriki;
                            Console.WriteLine($"Ваш баланс {balanceRub} {Currency.RUB} {balanceUsd}" +
                                $" {Currency.USD} {balanceMnt} {Currency.MNT}\n");
                        }
                        break;
                }
                Console.WriteLine($"Если хотите выйти введите {stopWord}");
                commandStop = Console.ReadLine();
            }
        }
        public static bool CheckBalanceZero(double  balance, double stepBalance)
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
enum Converter { RubleToDollar, DollarToRuble, TugrikiToRuble, RubleToTugriki, DollarToTugriki, TugrikiTodollar }
enum Currency { RUB, USD, MNT }
