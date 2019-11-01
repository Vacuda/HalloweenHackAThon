using System;


namespace HauntedHouse.Models
{
    public class Archer : Hero
    {
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
                System.Console.WriteLine ($"{_Name} fired an arrow for {TotalDmg} Damage. ");
            }
            if (AttkMethodNum == 3) {
                target.health -= TotalDmg;
                System.Console.WriteLine ($"{_Name} clipped the target with a bow for {TotalDmg} Damage. ");
            }
            if (AttkMethodNum > 3) {
                target.health -= TotalDmg;
                System.Console.WriteLine ($"{_Name} fired a flaming arrow for {TotalDmg} Damage. ");
            }
            System.Threading.Thread.Sleep(5000);

        }
        // public override void Special(Enemy target){

        // }
    }
}