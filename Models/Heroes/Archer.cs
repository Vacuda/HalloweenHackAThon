using System;


namespace HauntedHouse.Models
{
    public class Archer : Hero
    {
        //Fields

        //Constructor
        public Archer(string name) : base (name){
            //12
            _Attack = 10;
            _Defense = 2;
            _Health = 100;
            _Hat = "Headband Of Courage";
        }
        //Properties

        //Methods
        public override bool CheckDead(){
            bool isDead = false;
            if(_Health < 0){
                isDead=true;
            }
            return isDead;
        }
        public override void Attack(Enemy target){
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
        }
        // public override void Special(Enemy target){

        // }
    }
}