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

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write ($"You, ");
            for(var x=0; x<Heroes.Count;x++){
                Console.Write ($" {Heroes[x]._Name}, ");
                if (x == Heroes.Count-2){
                    Console.Write(" and ");
                }
            }
            Console.WriteLine (" have been summoned to Dojo Manor by Count Brakula,\nwho is not a vampire, to exterminate the spooky entities that dwell inside.\nYou are supicious of Count Brakula, but accept the job anyway.\nPress Enter/Return to begin...");
            Console.WriteLine("---------------------------------------------");
            Console.ResetColor ();

            ConsoleKey key = Console.ReadKey (true).Key;
            while (key != ConsoleKey.Enter) {
                key = Console.ReadKey (true).Key;
            }
            bool room_advance = true;
            bool end = false;
            int room_selection;
            Room current_room = rooms[rooms.Count - 1]; //first room
            List<Room> possible_rooms = new List<Room>();
            List<Enemy> Enemies = current_room._Enemies; //Populated for the first room only

            while (!end) { //Main loop starts here
                if (room_advance == true){
                    if(Enemies.Count >= 1){
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine ($"You have entered {current_room._Name}");
                        Console.WriteLine($"{current_room._Description}");
                        Console.ResetColor ();
                    }
                room_advance = false;
                ///CHANGE ROOMS HERE!!!!
                }else{ //battle logic
                    
                    if (Enemies.Count > 0) { //are there enemies???
                        Console.WriteLine("---------------------------------------------"); //begin battle turn
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine ($"There are {Enemies.Count} enemies in the room!");
                        foreach(Enemy enemy in Enemies){
                            Console.WriteLine($"A {enemy._Name} with {enemy.health} Health!");
                        }
                        Console.ResetColor ();
                        Console.ForegroundColor = ConsoleColor.Green;
                        foreach (Hero hero in Heroes) { //attack loop
                            hero.Attack (Enemies[rand.Next (0, Enemies.Count)]);
                        }
                        Console.ResetColor ();
                        Console.ForegroundColor = ConsoleColor.Red;
                        foreach (Enemy enemy in Enemies) {
                            enemy.Attack (Heroes[rand.Next (0, Heroes.Count)]);
                        }
                        Console.ResetColor ();
                        check_dead_enemies(Enemies);
                        check_dead_heroes(Heroes);
                        Console.WriteLine("---------------------------------------------"); //end battle turn
                    } else { //you can advance!!
                        Console.ForegroundColor=ConsoleColor.Cyan;
                        Console.WriteLine ($"     There are no enemies in the room.");
                        System.Console.WriteLine("         .................");
                        Console.ResetColor();
                        foreach(Hero hero in Heroes){
                        Console.ForegroundColor=ConsoleColor.Cyan;
                            Console.WriteLine($"--{hero._Name} is left standing with {hero.health} health left");
                            Console.ResetColor();
                        }
                        Console.WriteLine ("---------------------------------------------");
                        if(current_room == rooms[0]){ //check win condition. First room in list the last room in the game.
                            Console.WriteLine($"---------Your Party Escaped with their lives!!!!!!!----------");
                            Console.WriteLine ("The End!");
                            end = true; //that's all folks.
                        }else{ //continue game.
                            for(var x =0; x< current_room._ForwardPaths.Count ;x++){ 
                                Console.ForegroundColor=ConsoleColor.Yellow;
                                Console.Write ($"Type {x+1} to advance to room {current_room._ForwardPaths[x]._Name} "); //decide room
                                Console.ResetColor();
                                System.Console.WriteLine();
                            }
                            while (!int.TryParse (Console.ReadLine (), out room_selection)) {
                                Console.WriteLine ("Please enter an above integer.");
                                Console.WriteLine ("---------------------------------------------");
                            }
                            if(room_selection >= 0 && room_selection < current_room._ForwardPaths.Count ){
                                current_room = current_room._ForwardPaths[room_selection];
                                Enemies = current_room._Enemies;
                            }else{
                                current_room = current_room._ForwardPaths[0];
                                Enemies = current_room._Enemies;    
                            }
                            room_advance = true;
                        }
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
            
            for (int x = 0; x < Heroes.Count; x++) {
                // Console.WriteLine($"{Heroes[x]._Name} Has {Heroes[x].health} health left!");
                if(Heroes[x].CheckDead() == true){
                    Console.WriteLine($"Our hero {Heroes[x]._Name} has fallen!"); 
                    Heroes.RemoveAt(x);
                }
            }
            return Heroes;
        }
        public static List<Enemy> check_dead_enemies(List<Enemy> Enemies) {
            for (int x = 0; x < Enemies.Count; x++) {
                if(Enemies[x].CheckDead() == true){
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine($"***A {Enemies[x]._Name} Has been slain!***"); 
                    Console.ResetColor();
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
                Archer archer = new Archer (name);
                return archer;
            }
            if (choice == 2) {
                Knight knight = new Knight (name);
                return knight;
            }
            if (choice == 3) {
                Wizard wizard = new Wizard (name);
                return wizard;
            } else {
                return new Wizard ("Jeff");
            }
        }
    }
}