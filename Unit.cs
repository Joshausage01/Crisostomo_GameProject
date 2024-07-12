using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crisostomo_GameProject
{
    public class Unit
    {
        //unit characteristics
        public string unitName;
        public int maxHealthPoints;
        public int currentHealthPoints;
        public int attackPower;
        public int healPower;
        public Random random;
        
        //Unit read-only properties (Encapsulation)
        public int HP { get { return currentHealthPoints; } }      //return the current health points of the units
        public int AP { get { return attackPower; } }      //return the current atttack power of the units
        public int HealPR { get { return healPower; } }     //return the heal power of the units
        public bool IsDead { get { return currentHealthPoints <= 0; } }    //return method confirmation of the units' status

        public Unit(int maxHealthPoints, int attackPower, int healPower, string unitName)   //class constructor
        {
            this.maxHealthPoints = maxHealthPoints;
            this.currentHealthPoints = maxHealthPoints;
            this.attackPower = attackPower;
            this.healPower = healPower;
            this.unitName = unitName;
            this.random = new Random();
        }

        public void Attacking(Unit unitToAttack)
        {
            double rngChances = random.NextDouble();    //generate random numbers ranging from 0 to 1
            rngChances = rngChances / 2 + 0.75f;
            int randomDamage = (int)(attackPower * rngChances);

            //select unit to attack
            unitToAttack.TakeDamage(randomDamage);
            
            //prompt damage
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{unitName} attacks {unitToAttack.unitName} and deals {randomDamage} damage!");
            Console.ResetColor();
        }

        public void TakeDamage(int damage)
        {
            //inflict damage
            currentHealthPoints -= damage;

            //prompt 
            if (IsDead)
            {
                Console.WriteLine($"{unitName} has been defeated!");
            }
        }

        public void Heal()
        {
            double rngChances = random.NextDouble();    //generate random numbers ranging from 0 to 1
            rngChances = rngChances / 2 + 0.75f;
            int randomHeal = (int)(healPower * rngChances);

            //assigning hp values. If current hp is healed and is greater than max HP then just display the max HP.
            currentHealthPoints = randomHeal + currentHealthPoints > maxHealthPoints ? maxHealthPoints : currentHealthPoints + randomHeal;

            //prompt heal
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{unitName} heals {randomHeal} health points!!!");
            Console.ResetColor();
        }

        public void StatsUP(Unit unitToLevelUp)
        {
            //stats increase
            unitToLevelUp.IncreaseHealth(20);
            unitToLevelUp.IncreaseAttack(4);
            unitToLevelUp.IncreaseHeal(4);
            Console.WriteLine($"\n>> {Program.playerUnit.unitName}'s stats increased! <<");
        }

        public void IncreaseHealth(int value)
        {
            //increase in health points
            maxHealthPoints += value;
            currentHealthPoints += value;
        }

        public void IncreaseAttack(int value)
        {
            //increase in attack power
            attackPower += value;
        }

        public void IncreaseHeal(int value)
        {
            //increase in heal power
            healPower += value;
        }
    }
}
