using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LB5.Units
{
    internal class Beast : IUnit
    {
        public string Name { get; set; }

        public int Attack { get; set; }

        public int Defence { get; set; }

        public string Skill { get; set; }

        public int HP { get; set; }

        public string Race { get; set; }

        public Beast(string name, int attack, int defence, string skill, int hP, string race)
        {
            Name = name;
            Attack = attack;
            Defence = defence;
            Skill = skill;
            HP = hP;
            Race = race;
        }

        public int makeDamage(int EnemyDefence)
        {
            if (EnemyDefence >= this.Attack) return 0;
            else
            {
                return Attack - EnemyDefence;
            }
        }

        public int takeDamage(int EnemyAttack)
        {
            if (EnemyAttack <= this.Defence) return 0;
            else
            {
                this.HP -= EnemyAttack;
                return EnemyAttack - Defence;
            }
        }

        public void useSkill(string Skill)
        {
            throw new NotImplementedException();
        }
    }
}
