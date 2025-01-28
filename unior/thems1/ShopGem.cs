using System;


namespace unior.введение
{
    internal class ShopGem
    {
        public static void Gem1()
        {
            int gold = int.Parse(Console.ReadLine());
            int cost = int.Parse(Console.ReadLine());
            int gem = gold / cost;
            int leftGold = gold % cost;
            Console.WriteLine($"Кол-во кристаллов {gem}, остаток золота {leftGold}");
        }

    }
}
