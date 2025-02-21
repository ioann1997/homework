using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace Unior.Thems6.HomeWork8
{
    internal class HomeWork8
    {
        public static void hm()
        {
            Fighter[] fighters =
            {
                new Fighter("Женя", 10, 200, 35, new CriticalAttack()),
                new Fighter("Коля", 10, 200, 35, new DoubleAttack()),
                new Fighter("Ваня", 10, 200, 35, new Dodge()),
                new Fighter("Петя", 10, 200, 35, new FireBall()),
                new Fighter("Иоанн", 10, 200, 35, new FuryHeal())
            };

            Console.WriteLine("choose");
            foreach (var fighter in fighters)
            {
                Console.WriteLine(fighter);
            }

            Arena arena = new Arena();

            //int input = int.Parse(Console.ReadLine());

            Fighter fighter1 = arena.ChooseFighter();
            Fighter fighter2 = arena.ChooseFighter();

            Console.WriteLine("War");

            while (fighter1.Health > 0 && fighter2.Health > 0)
            {
                fighter1.Attack(fighter2);
                fighter2.Attack(fighter1);
            }


        }
    }

    internal class Arena
    {
        private Fighter[] fighters = {
                new Fighter("Женя", 10, 200, 35, new CriticalAttack()),
                new Fighter("Коля", 10, 200, 35, new DoubleAttack()),
                new Fighter("Ваня", 10, 200, 35, new Dodge()),
                new Fighter("Петя", 10, 200, 35, new FireBall()),
                new Fighter("Иоанн", 10, 200, 35, new FuryHeal())
            };

        public void ShowFighters()
        {
            foreach (var fighter in fighters)
            {
                Console.WriteLine(fighter);
            }
        }

        public Fighter ChooseFighter()
        { 
            Console.WriteLine("Введите номер бойца: ");

            int index = ReadIndex("Ведите индекс: ", fighters);
            Fighter fighter = (Fighter)fighters[index].Clone();

            return fighter;
        }
    
        public int ReadIndex<T>(string info, T[] values)
        {
            int index = UserUtils.ReadInt(info);

            while (index < 0 || index >= values.Count())
            {
                Console.WriteLine("Такого индекса нет.");
                index = UserUtils.ReadInt(info);
            }

            return index;
        }
    }

    internal interface ISkill : ICloneable
    {
        public int ModifyDamage(int damage)
        {
            return damage;
        }

        public int OnDamageTaken(Fighter fighter, int damage) 
        {
            return damage;
        }

        public int GetAttackCount()
        {
            return 1;
        }
    }

    internal class Dodge : ISkill
    {
        private int _damage = 0;
        private double _chance = 0.4;

        public int OnDamageTaken(Fighter fighter, int damage)
        {
            if (UserUtils.GenerateRandomDoubleNumber() <= _chance)
            {
                Console.WriteLine($"{fighter.Name} уклонился");

                return _damage;
            }
            else
            {
                return damage;
            }
        }

        public object Clone()
        {
            return new Dodge();
        }
    }


    internal class FireBall : ISkill
    {
        private int _mana = 30;
        private int _manaCost = 10;
        private int _fireBallDamage = 50;

        public int ModifyDamage(int damage)
        {
            if (_mana >= _manaCost)
            {
                Console.WriteLine($"Летит Огненный шар нанося {_fireBallDamage} урона");
                _mana -= _manaCost;

                return _fireBallDamage;
            }
            else
            {
                return damage;
            }    
        }

        public object Clone()
        {
            return new FireBall();
        }
    }

    internal class FuryHeal : ISkill
    {
        private int fury = 0;
        private int maxFury = 100;

        public int OnDamageTaken(Fighter fighter, int damage)
        {
            fury += damage;
            if (fury >= maxFury)
            {
                fighter.Health += maxFury / 2;
                fury = 0;
                Console.WriteLine($"{fighter.Name} использовал лечение! Здоровье: {fighter.Health}");
            }

            return damage;
        }

        public object Clone()
        {
            return new FuryHeal();
        }
    }

        internal class CriticalAttack : ISkill
    {
        private int _criticalDamage = 2;
        private double _criticalChanceDamage = 0.4;

        public int ModifyDamage(int damdage)
        {
            if (UserUtils.GenerateRandomDoubleNumber() < _criticalChanceDamage)
            {
                Console.WriteLine("Сработал двойной урон");

                return damdage * _criticalDamage;
            }
            return damdage;
        }

        public object Clone()
        {
            return new CriticalAttack();
        }
    }

    internal class DoubleAttack : ISkill
    {
        private int _attackCounter = 1;

        public int GetAttackCount()
        {
            _attackCounter++;
            if (_attackCounter % 3 == 0)
            {
                Console.WriteLine("Сработал двойная атака");
            }

            return _attackCounter % 3 == 0 ? 2 : 1;
        }

        public object Clone()
        {
            return new DoubleAttack();
        }
    }

    internal class Fighter : ICloneable
    {
        private string _name;
        private int _health;
        private int _damage;
        private int _armor;
        private ISkill _skill;

        public int Damage { get { return _damage; }  set { _damage = value; } }
        public int Health { get { return _health; } set { _health = value; }  }
        public string Name { get { return _name; } }

        public Fighter(string name, int armor, int health, int damage, ISkill skill)
        {
            _name = name;
            _armor = armor;
            _health = health;
            _damage = damage;
            _skill = skill;
        }

        public void Attack(Fighter enemy)
        {
            for (int i = 0; i < _skill.GetAttackCount(); i++)
            {
                int damageDealt = Damage - enemy._armor;
                if (damageDealt < 0)
                {
                    damageDealt = 0;
                }

                int finalDamage = _skill.ModifyDamage(damageDealt);
                enemy.TakeDamage(finalDamage);

                //Console.WriteLine($"{_name} атакует {enemy.Name}, нанося {finalDamage} урона.");
            }
        }

        public void TakeDamage(int damage)
        {
            damage = _skill.OnDamageTaken(this, damage);
            _health -= damage;

            Console.WriteLine($"{_name} получает {damage} урона. Здоровье: {_health}");
            if (Health <= 0)
            {
                Console.WriteLine($"{_name} повержен!");
            }
        }
        public object Clone()
        {
            return new Fighter(_name, _damage, _health, _armor, (ISkill)_skill.Clone());
        }
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

        public static int ReadInt(string info = "")
        {
            int number = 0;
            Console.Write(info);

            while (int.TryParse(Console.ReadLine(), out number) == false)
            {
                Console.WriteLine("Вы ввели не число");
            }

            return number;
        }
    }
}
