using System;

public class Str
{
    public static void Stri()
    {
        char genderMan = 'М';
        char genderWomen = 'Ж';
        Console.Write("Введите своё Имя ");
        string name = Console.ReadLine();
        Console.Write($"Введите свой пол {genderMan}/{genderWomen} ");
        char gender = char.Parse(Console.ReadLine());
        Console.Write("Сколько вам лет? ");
        string age = Console.ReadLine();
        if (gender == genderMan)
            Console.WriteLine("Приветсвую, Добрый путник {0} возрастом таким-то {1}", name, age);
        else if (gender == genderWomen)
            Console.WriteLine("Приветсвую, Добрую путницу {0} возрастом таким-то {1}", name, age);
    }

}
