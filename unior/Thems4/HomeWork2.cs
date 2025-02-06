using System;

namespace Unior.Thems4
{
    internal class HomeWork2
    {
        public static void Hm2()
        {
            ShowUIElement(30, 20, "Healthbar");
            ShowUIElement(60, 10, "Manabar");
        }

        public static void ShowUIElement(double percent, int lenght, string nameBar)
        {
            int shaded = (int)Math.Round(percent / 100 * lenght);
            int unpainted = lenght - shaded;
            string shadedArea = new String('#', shaded) ;
            string unpaintedArea = new String('_', unpainted) ;

            Console.WriteLine($"{nameBar} : {'[' + shadedArea +  unpaintedArea + ']'}");
        }
    }
}
