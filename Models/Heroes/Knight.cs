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
            System.Console.WriteLine ($"{_Name} shashed with a sword for {TotalDmg} Damage. ");
            }
            if (AttkMethodNum == 3) {
                target.health -= TotalDmg;
            System.Console.WriteLine ($"{_Name} jabbed with sword hilt for {TotalDmg} Damage. ");
            }
            if (AttkMethodNum > 3) {
                target.health -= TotalDmg;
            System.Console.WriteLine ($"{_Name} headbutted with an iron helmet for {TotalDmg} Damage. ");
            }
            System.Threading.Thread.Sleep(5000);
        }
        // public override void Special(Enemy target){

        // }
    }
}