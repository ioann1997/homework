using System;


namespace unior
{
    internal class Hospital
    {
        public static void Hospital1()
        {
            int minuteOfHours = 60;
            int countPeople = int.Parse(Console.ReadLine());
            int timeQueue = 10;
            int hours = timeQueue * countPeople / minuteOfHours;
            int minutes = timeQueue * hours % minuteOfHours;
            Console.WriteLine($"Вы должны отстоять в очереди {hours} часа и {minutes} минут.");
        }
    }
}
