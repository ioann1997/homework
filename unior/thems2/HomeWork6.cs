using System;


namespace unior
{
    internal class HomeWork6
    {
        public static void Hm6()
        {
            Console.Write($"Введите свой баланс {Currency.RUB}: ");
            double balanceRub = double.Parse(Console.ReadLine());
            
            Console.Write($"Введите свой баланс {Currency.USD}: ");
            double balanceUsd = double.Parse(Console.ReadLine()); 

            Console.Write($"Введите свой баланс {Currency.MNT}: ");
            double balanceMnt = double.Parse(Console.ReadLine());

            string stopWord = "exit";
            string input = "";
            double ratioDollrAndRuble = 97.97;
            double ratioRubleAndTugriki = 35.18;
            double ratioTugrikiAndDollar = 3446;

            while (input != stopWord)
            {
                Console.WriteLine($"Выберите что хотите конвертировать : \n" +
                    $"{Converter.DollarToRuble}\n{Converter.DollarToTugriki}\n" +
                    $"{Converter.RubleToTugriki}\n{Converter.RubleToDollar}\n" +
                    $"{Converter.TugrikiTodollar}\n{Converter.TugrikiToRuble}\n" +
                    $"Если хотите выйти введите {stopWord}\n");
                input = Console.ReadLine();

                if (input == stopWord) break;

                Converter converter = (Converter)Enum.Parse(typeof(Converter), input);

                Console.Write($"Сколько хотите перевести? ");
                double wantConvert = double.Parse(Console.ReadLine());
                
                switch (converter)
                {
                    case Converter.DollarToRuble:

                        if (CheckBalanceZero(balanceUsd, wantConvert))
                        {
                            balanceUsd -= wantConvert;
                            balanceRub = wantConvert * ratioDollrAndRuble;
                            Console.WriteLine($"Ваш баланс {balanceRub} {Currency.RUB} {balanceUsd}" +
                                $" {Currency.USD} {balanceMnt} {Currency.MNT}\n");
                        }
                        break;

                    case Converter.RubleToDollar:

                        if (CheckBalanceZero(balanceRub, wantConvert))
                        {
                            balanceRub -= wantConvert;
                            balanceUsd = wantConvert / ratioDollrAndRuble;
                            Console.WriteLine($"Ваш баланс {balanceRub} {Currency.RUB} {balanceUsd}" +
                                $" {Currency.USD} {balanceMnt} {Currency.MNT}\n");
                        }
                        break;

                    case Converter.DollarToTugriki:

                        if (CheckBalanceZero(balanceUsd, wantConvert))
                        {
                            balanceUsd -= wantConvert;
                            balanceMnt = wantConvert * ratioTugrikiAndDollar;
                            Console.WriteLine($"Ваш баланс {balanceRub} {Currency.RUB} {balanceUsd}" +
                                $" {Currency.USD} {balanceMnt} {Currency.MNT}\n");
                        }
                        break;

                    case Converter.TugrikiTodollar:

                        if (CheckBalanceZero(balanceMnt, wantConvert))
                        {
                            balanceMnt -= wantConvert;
                            balanceUsd = wantConvert / ratioTugrikiAndDollar;
                            Console.WriteLine($"Ваш баланс {balanceRub} {Currency.RUB} {balanceUsd}" +
                                $" {Currency.USD} {balanceMnt} {Currency.MNT}\n");
                        }
                        break;

                    case Converter.TugrikiToRuble:

                        if (CheckBalanceZero(balanceMnt, wantConvert))
                        {
                            balanceMnt -= wantConvert;
                            balanceRub = wantConvert / ratioRubleAndTugriki;
                            Console.WriteLine($"Ваш баланс {balanceRub} {Currency.RUB} {balanceUsd}" +
                                $" {Currency.USD} {balanceMnt} {Currency.MNT}\n");
                        }
                        break;

                    case Converter.RubleToTugriki:

                        if (CheckBalanceZero(balanceRub, wantConvert))
                        {
                            balanceRub -= wantConvert;
                            balanceMnt = wantConvert * ratioRubleAndTugriki;
                            Console.WriteLine($"Ваш баланс {balanceRub} {Currency.RUB} {balanceUsd}" +
                                $" {Currency.USD} {balanceMnt} {Currency.MNT}\n");
                        }
                        break;
                }
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
            else return true; 
        }
    }
}
enum Converter { RubleToDollar, DollarToRuble, TugrikiToRuble, RubleToTugriki, DollarToTugriki, TugrikiTodollar }
enum Currency { RUB, USD, MNT }
