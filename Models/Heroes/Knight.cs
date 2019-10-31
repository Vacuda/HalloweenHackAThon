using System;


namespace HauntedHouse.Models
{
    public class Knight : Hero
    {
        //Fields

        //Constructor
        public Knight(string name) : base (name){
            //10
            _Attack = 5;
            _Defense = 5;
            _Health = 150;
            _Hat = "Fierce Metal Hat";
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