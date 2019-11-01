using System;
using System.Collections.Generic;
using HauntedHouse.Models;

namespace HauntedHouse {
    class Program {
        static void Main (string[] args) {
            List<Room> rooms = Program2.RoomBuilds();
            Console.WriteLine($"Rooms: {rooms.Count}");
            Random rand = new Random ();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine ("************WELCOME TO HAUNTED HOUSE************");
            Console.ResetColor ();
            List<Hero> Heroes = new List<Hero> (); //select your heroes
            for (int x = 1; x <= 3; x++) {
                Console.WriteLine ($"-----------Hero {x} Selection!-----------");
                Heroes.Add (ChooseHero ());
            }
            //List<Enemy> Enemies = new List<Enemy> (); //enemies list declaration


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write ($"You, ");
            // for(var x=0; x<Heroes.Count;x++){
            // if Heroes[x] == 1{

            // }
            foreach (Hero hero in Heroes) {
                Console.Write ($" {hero._Name} ");
            }
            Console.WriteLine (", have been summoned to Dojo Manor by Count Brakula,\nwho is not a vampire, to exterminate the spooky entities that dwell inside.\nYou are supicious of Count Brakula, but accept the job anyway.\nPress Enter/Return to begin...");
            Console.ResetColor ();

            ConsoleKey key = Console.ReadKey (true).Key;
            while (key != ConsoleKey.Enter) {
                key = Console.ReadKey (true).Key;
            }
            //Console.WriteLine("BEGIN YOUR ADVENTURE HERE!!!");
            bool room_advance = true;
            bool end = false;
            int room_selection;
            Room current_room = rooms[rooms.Count - 1]; //first room
            List<Room> possible_rooms = new List<Room>();
            List<Enemy> Enemies = current_room._Enemies; //first room only

            while (!end) {
                if (room_advance == true){
                    if(Enemies.Count >= 1){
                        Console.WriteLine ($"You have entered {current_room._Name}");
                        Console.WriteLine($"{current_room._Description}");
                    }
                room_advance = false;
                ///CHANGE ROOMS HERE!!!!
                }else{ //battle logic
                    Enemies = current_room._Enemies;

                    if (Enemies.Count > 0) { //are there enemies???
                        Console.WriteLine ($"There are {Enemies.Count} enemies in the room!");
                    foreach (Hero hero in Heroes) { //attack loop
                        hero.Attack (Enemies[rand.Next (0, Enemies.Count)]);
                        }

                    foreach (Enemy enemy in Enemies) {
                        enemy.Attack (Heroes[rand.Next (0, Heroes.Count)]);
                        }
                        check_dead_enemies(Enemies);
                        check_dead_heroes(Heroes);
                    } else { //you can advance!!
                        Console.WriteLine ($"There are no enemies in the room.");
                        Console.WriteLine ("---------------------------------------------");
                        for(var x =0; x< current_room._ForwardPaths.Count ;x++){ 
                            Console.Write ($"Type {x+1} to advance to room {current_room._ForwardPaths[x]._Name} "); //decide room
                        }
                        Console.WriteLine();
                        while (!int.TryParse (Console.ReadLine (), out room_selection)) {
                            Console.WriteLine ("Please enter an above integer.");
                        }
                        if(room_selection >= 0 && room_selection < current_room._ForwardPaths.Count ){
                            current_room = current_room._ForwardPaths[room_selection];
                        }else{
                            current_room = current_room._ForwardPaths[0];    
                        }

                        room_advance = true;
                    }

                    // Heroes = new List<Hero> (); //TESTING!!!!!!!!!!!!
                    if (Heroes.Count < 1) { //loss end condition
                        Console.WriteLine ("----------------------------");
                        Console.WriteLine ("All Heroes Have Perished!!!");
                        Console.WriteLine ("----------X_x---------------");
                        end = true;
                        Console.WriteLine ("The End!");
                    }
                    if(Enemies.Count < 1){
                        room_advance = true;
                    }
                }
            }
        }
        public static List<Hero> check_dead_heroes(List<Hero> Heroes) {
            //foreach(Hero hero in Heroes){
            //}
            
            for (int x = 0; x < Heroes.Count; x++) {
                Console.WriteLine($"{Heroes[x]._Name} Has {Heroes[x].health} health left!");
                if(Heroes[x].CheckDead() == true){
                    Console.WriteLine(Heroes[x]._Name); 
                    Heroes.RemoveAt(x);
                }
            }
            return Heroes;
        }
        public static List<Enemy> check_dead_enemies(List<Enemy> Enemies) {
            for (int x = 0; x < Enemies.Count; x++) {
                if(Enemies[x].CheckDead() == true){
                    Console.WriteLine($"A {Enemies[x]._Name} Has been slain!"); 
                    Enemies.RemoveAt(x);
                }
            }
            return Enemies;
        }
        public static Hero ChooseHero () {
            Console.WriteLine ("Choose which type of hero you would like to be and press enter...");
            Console.WriteLine ("1 : Archer.");
            Console.WriteLine ("2 : Knight.");
            Console.WriteLine ("3 : Wizard.");
            Console.WriteLine ("Type the number of the corresponding hero...");
            int choice;
            while (!int.TryParse (Console.ReadLine (), out choice)) {
                Console.WriteLine ("Please enter an above integer.");
            }

            Console.WriteLine ("What is your character's name?");
            string name = Console.ReadLine();
            if (choice == 1) {
                //CREATE ATTACK HERO
                Archer archer = new Archer (name);
                return archer;
            }
            if (choice == 2) {
                //CREATE ATTACK HERO
                Knight knight = new Knight (name);
                return knight;
            }
            if (choice == 3) {
                //CREATE ATTACK HERO
                Wizard wizard = new Wizard (name);
                return wizard;
            } else {
                return new Wizard ("Jeff");
            }
        }

    }
}