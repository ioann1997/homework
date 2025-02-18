using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Unior.Thems6.HomeWork8
{
    internal class HomeWork8
    {
        public static void павп()
        {

        }
    }

    class Warrior
    {
        //private int _name;
        private int _health;
        private protected int _damage;
        private int _armor;

        public int Damage { get { return _damage; } }

        public Warrior(int armor, int health, int damage)
        {
            _armor = armor;
            _health = health;
            _damage = damage;
        }

        public Warrior()
        {
            _armor = 10;
            _health = 200;
            _damage = 25;
        }

        public void TakeDamage(int damage)
        {
            _damage -= damage - _armor;
        }
    }

    class Warrior1 : Warrior 
    {
        private int _criticalDamage = 2;
        private double _criticalChanceDamage = 0.34;
        public Warrior1()
        {
            _damage = AttackDamage();
        }

        private  int AttackDamage()
        {
            if (UserUtils.GenerateRandomDoubleNumber() < _criticalChanceDamage)
            {
                return Damage * _criticalDamage;
            }
            return Damage;
        }
    }

    class Warrior2 : Warrior
    {
        private int countAttack = 3;
        public Warrior2()
        {

        }
        //private int AttackDamage()
        //{
        //    if (UserUtils.GenerateRandomDoubleNumber() < _criticalChanceDamage)
        //    {
        //        return Damage * _criticalDamage;
        //    }
        //    return Damage;
        //}
    }

    internal class UserUtils
    {
        private static Random s_random = new Random();

        public static int GenerateRandomNumber(int max, int min = 0)
        {
            return s_random.Next(min, max+1);
        }

        public static double GenerateRandomDoubleNumber()
        {
            return s_random.NextDouble();
        }
    }
}
