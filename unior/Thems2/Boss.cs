using System;

namespace Unior
{
    internal class Boss
    {
        public static void Boss1()
        {
            // 1. Обычная атака
            int baseAttackDamage = 5;

            // 2. Огненный шар
            int fireballManaCost = 20;
            int fireballDamage = 12;   
            bool fireballUse = false;

            // 3. Взрыв
            int explosionDamage = 18;   

            // 4. Лечение
            int healAmountHP = 40;
            int healAmountMana = 15;
            int maxHealUses = 3;
            int healUsesRemaining = 0; 

            // Состояние героя
            int maxHealth = 100;
            int currentHealth = maxHealth;
            int maxMana = 30;
            int currentMana = maxMana;

            // Характеристики босса
            int maxHealthBoss = 100;
            int currentHealthBoss = maxHealthBoss;
            int bossAttackDamage = 10;

            const string CommandAttack = "1";
            const string CommandFireBall = "2";
            const string CommandRemaining = "3";
            const string CommandExplosion = "4";

            while (currentHealth>0 & currentHealthBoss >0)
            {
                Console.WriteLine($"{CommandAttack} - Attack\n{CommandFireBall} - FireBall\n" +
                    $"{CommandRemaining} - Remaining\n{CommandExplosion} - Explosion\n");
                string action = Console.ReadLine();

                switch (action)
                {
                    case CommandAttack:
                        currentHealthBoss -= baseAttackDamage;
                        break;

                    case CommandFireBall:
                        if (currentMana >= fireballManaCost)
                        {
                            currentMana -= fireballManaCost;
                            currentHealthBoss -= fireballDamage;
                            fireballUse = true;
                        }
                        break;

                    case CommandRemaining:
                        if (healUsesRemaining < maxHealUses)
                        {
                            currentMana += healAmountMana;

                            if (currentMana > maxMana)
                            {
                                currentMana = maxMana;
                            }
                            currentHealth += healAmountHP;
                            
                            if (currentHealth>maxHealth)
                            {
                                currentHealth = maxHealth;
                            }                          
                            healUsesRemaining++;
                        }
                        break;

                    case CommandExplosion:
                        if (fireballUse)
                        {
                            currentHealthBoss -= explosionDamage;
                            fireballUse = false;
                        }
                        break;
                }
                // Атака босса
                Console.WriteLine($"Босс нанёс {bossAttackDamage} урона");
                currentHealth -= bossAttackDamage;
                // info
                Console.WriteLine($"Стаутус:\n Здоровье {currentHealth} Мана {currentMana}\n Здоровье босса {currentHealthBoss}");

                if (currentHealth == currentHealthBoss && currentHealth == 0) 
                {
                    Console.WriteLine("Поздравляю! у вас ничья)");
                }
            }
        }
    }
}

