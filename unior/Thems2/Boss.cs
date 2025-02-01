using System;

namespace Unior
{
    internal class Boss
    {
        public static void Boss1()
        {
            const string CommandAttack = "1";
            const string CommandFireBall = "2";
            const string CommandRemaining = "3";
            const string CommandExplosion = "4";
            
            int baseAttackDamage = 5;

            int fireballManaCost = 20;
            int fireballDamage = 12;   
            bool isFireballUsed = false;

            int explosionDamage = 18;   

            int healAmountHealth = 40;
            int healAmountMana = 15;
            int maxHealUses = 3;
            int healUsesRemaining = 0; 

            int maxHealth = 100;
            int currentHealth = maxHealth;
            int maxMana = 30;
            int currentMana = maxMana;

            int maxHealthBoss = 100;
            int currentHealthBoss = maxHealthBoss;
            int bossAttackDamage = 10;

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
                            isFireballUsed = true;
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
                            
                            currentHealth += healAmountHealth;
                            
                            if (currentHealth>maxHealth)
                            {
                                currentHealth = maxHealth;
                            }    
                            
                            healUsesRemaining++;
                        }
                        break;

                    case CommandExplosion:
                        if (isFireballUsed)
                        {
                            currentHealthBoss -= explosionDamage;
                            isFireballUsed = false;
                        }
                        break;
                }
                
                Console.WriteLine($"Босс нанёс {bossAttackDamage} урона");
                currentHealth -= bossAttackDamage;
                Console.WriteLine($"Стаутус:\n Здоровье {currentHealth} Мана {currentMana}\n Здоровье босса {currentHealthBoss}");
            }
            
            if (currentHealth <= 0 && currentHealthBoss <= 0) 
            {
                Console.WriteLine("Поздравляю! у вас ничья)");
            }
            else if (currentHealth <= 0) 
            {
                Console.WriteLine("Жаль но вы проиграли(");
            }
            else
            {
                Console.WriteLine("Сокрушительная победа!!!");
            }
        }
    }
}

