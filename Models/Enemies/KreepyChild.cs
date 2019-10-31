using System;

namespace HauntedHouse.Models {
    public class KreepyChild : Enemy {
        public KreepyChild () {
            _Name = "KreepyChild";
            Random health = new Random ();
            _Attack = 6;
            _Health = health.Next (15, 31);

        }

        public override bool CheckDead () {
            bool isDead = false;
            if (_Health < 0) {
                isDead = true;
            }
            return isDead;
        }

        public override void Attack (Hero target) {
            Random AttkMethod = new Random ();
            int AttkMethodNum = AttkMethod.Next (1, 5);
            int TotalDmg = _Attack + AttkMethodNum;
            if (AttkMethodNum < 3) {
                target.health -= TotalDmg;
            System.Console.WriteLine ($"{_Name} Ate You Hand For {TotalDmg} Damage. ");
            }
            if (AttkMethodNum == 3) {
                target.health -= TotalDmg;
            System.Console.WriteLine ($"{_Name} Ate You Hand For {TotalDmg} Damage. ");
            }
            if (AttkMethodNum > 3) {
                target.health -= TotalDmg;
            System.Console.WriteLine ($"{_Name} Ate You Hand For {TotalDmg} Damage. ");
            }
            System.Threading.Thread.Sleep(5000);
        }
    }
}