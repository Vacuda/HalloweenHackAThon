using System;

namespace HauntedHouse.Models
{
    public class Wizard : Hero
    {
        //Fields

        //Constructor
        public Wizard(string name) : base (name){
            //8
            _Attack = 3;
            _Defense = 5;
            _Health = 200;
            _Hat = "Pointy Hat With A Moon On It";
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
            System.Console.WriteLine ($"{_Name} launched a fireball for {TotalDmg} Damage. ");
            }
            if (AttkMethodNum == 3) {
                target.health -= TotalDmg;
            System.Console.WriteLine ($"{_Name} peppered the target with electric sparks for {TotalDmg} Damage. ");
            }
            if (AttkMethodNum > 3) {
                target.health -= TotalDmg;
            System.Console.WriteLine ($"{_Name} surged forward a lightening bolt for {TotalDmg} Damage. ");
            }
            System.Threading.Thread.Sleep(5000);
        }
        // public override void Special(Hero target){
            
        // }
    }
}