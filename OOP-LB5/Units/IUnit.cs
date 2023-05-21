using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LB5.Units
{
    internal interface IUnit
    {
        string Name { get; }
        int Attack { get; }
        int Defence { get; set; }
        string Skill { get; }
        int HP { get; set; }
        string Race { get; }

        int makeDamage(int EnemyDefence);

        int takeDamage(int EnemyAttack);

        void useSkill(string Skill);
    }
}
