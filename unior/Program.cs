using System;

public class Str
{
    public static void Main()
    {
        Console.Write("Введите своё Имя ");
        string name = Console.ReadLine();
        Console.Write("Введите свой пол М/Ж ");
        char gender = char.Parse(Console.ReadLine());
        Console.Write("Сколько вам лет? ");
        string age = Console.ReadLine();
        if (gender == 'М')
            Console.WriteLine("Приветсвую, Добрый путник {0} возрастом таким-то {1}", name, age);
        else if (gender == 'Ж')
            Console.WriteLine("Приветсвую, Добрую путницу {0} возрастом таким-то {1}", name, age);



    }

}