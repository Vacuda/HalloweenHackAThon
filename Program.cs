using System;
using System.Collections.Generic;
using HauntedHouse.Models;

namespace HauntedHouse {
    class Program {
        static void Main (string[] args) {

            ////////

            //A
            Room creepy_foyer = new Room(
                "Creepy Foyer",
                "A",
                "This place is gorgeous!  There's a lovely lamp over there.  AND SUDDENLY! a lizard walks into the CENTER OF THE ROOM!"
                );
                creepy_foyer._Enemies.Add(new Lizard());
                creepy_foyer._ForwardPaths.Add("A");
                creepy_foyer._ForwardPaths.Add("B");

            //B
            Room computer_Room = new Room(
                "Computer Room",
                "B",
                "----"
                );
            computer_Room._Enemies.Add(new Unorganized());
            computer_Room._ForwardPaths.Add("D");
            computer_Room._ForwardPaths.Add("E");

            //C
            Room lovely_living_room = new Room(
                "Lovely Living Room",
                "C",
                "It smells like burning diapers in here, but it looks cozy.  Maybe I can find some gold in here?  Just then, a very traditional ghost attacks you.  It is the source of the smell... "
                );
            creepy_foyer._Enemies.Add(new Ghost());
            creepy_foyer._ForwardPaths.Add("E");
            creepy_foyer._ForwardPaths.Add("F");

            //D
            Room banquet_hall = new Room(
                "Banquet Hall",
                "D",
                "-----"
                );
            banquet_hall._Enemies.Add(new SmilingPolitician());
            banquet_hall._ForwardPaths.Add("G");

            //E
            Room boiler_room = new Room(
                "Boiler Room",
                "E",
                "----"
                );
            boiler_room._Enemies.Add(new Bat());
            boiler_room._Enemies.Add(new Bat());
            boiler_room._Enemies.Add(new Bat());
            boiler_room._ForwardPaths.Add("H");
            boiler_room._ForwardPaths.Add("G");

            //F
            Room garden_terrace = new Room(
                "Garden Terrace",
                "F",
                "A beautiful terrace overlooking a lush garden. They have pumpkins! Oh my there's a Deadly, Venomous Scarecrow! (and a lizard)"
                );
            garden_terrace._Enemies.Add(new Scarecrow());
            garden_terrace._Enemies.Add(new Lizard());
            garden_terrace._ForwardPaths.Add("H");

            //G
            Room lab = new Room(
                "Lab",
                "G",
                "-----"
                );
            lab._Enemies.Add(new BallofEnergy());
            lab._ForwardPaths.Add("I");

            //H
            Room kids_room = new Room(
                "Kid's Room",
                "H",
                "There's this pretty cool kids room.  It's actually very clean and colorful.  Except, there's a dead zombie Kreepy Kid named Zach staring at you.  He attacks!"
                );
            kids_room._Enemies.Add(new KreepyChild());
            kids_room._ForwardPaths.Add("I");

            //I
            Room basement_dungeon = new Room(
                "Basement Dungeon",
                "I",
                "----"
                );
            basement_dungeon._Enemies.Add(new DeadZombieAdrian());

    // ///////
















            // BuildRooms(); <-- UNCOMMENT THIS :D
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
            Room current_room = creepy_foyer;
            while (!end) {
                if (room_advance == true){
                Console.WriteLine ($"You have entered {current_room._Name}");
                Console.WriteLine($"{current_room._Description}");
                room_advance = false;
                ///CHANGE ROOMS HERE!!!!
                }else{ //battle logic
                    List<Enemy> Enemies = current_room._Enemies;

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
                        for(var x =1; x<=5 ;x++){ ///COUNT OF ROOMS HERE PLEASE!!!!!!!!!!!!
                            Console.Write ("Type {x} to advance to room {Placeholder} "); //decide room
                        }
                        Console.WriteLine();
                        while (!int.TryParse (Console.ReadLine (), out room_selection)) {
                            Console.WriteLine ("Please enter an above integer.");
                        }
                        if(room_selection >= 0 && room_selection < current_room._ForwardPaths.Count ){
                            //current_room = current_room._ForwardPaths[room_selection];
                        }else{
                            //default room!    
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
        public static List<Hero> check_dead_heroes (List<Hero> Heroes) {
            //foreach(Hero hero in Heroes){
            //}
            
            for (int x = 0; x < Heroes.Count; x++) {
                if(Heroes[x].CheckDead()){
                    Console.WriteLine(Heroes[x]._Name); 
                    Heroes.RemoveAt(x);
                }
            }
            return Heroes;
        }
        public static List<Enemy> check_dead_enemies (List<Enemy> Enemies) {
            for (int x = 0; x < Enemies.Count; x++) {
                if(Enemies[x].CheckDead()){
                    Console.WriteLine(Enemies[x]._Name); 
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

        static void BuildRooms(){

    //A
    Room creepy_foyer = new Room(
        "Creepy Foyer",
        "A",
        "This place is gorgeous!  There's a lovely lamp over there.  AND SUDDENLY! a lizard walks into the CENTER OF THE ROOM!"
        );
        creepy_foyer._Enemies.Add(new Lizard());
        creepy_foyer._ForwardPaths.Add("A");
        creepy_foyer._ForwardPaths.Add("B");

    //B
    Room computer_Room = new Room(
        "Computer Room",
        "B",
        "----"
        );
    computer_Room._Enemies.Add(new Unorganized());
    computer_Room._ForwardPaths.Add("D");
    computer_Room._ForwardPaths.Add("E");

    //C
    Room lovely_living_room = new Room(
        "Lovely Living Room",
        "C",
        "It smells like burning diapers in here, but it looks cozy.  Maybe I can find some gold in here?  Just then, a very traditional ghost attacks you.  It is the source of the smell... "
        );
    creepy_foyer._Enemies.Add(new Ghost());
    creepy_foyer._ForwardPaths.Add("E");
    creepy_foyer._ForwardPaths.Add("F");

    //D
    Room banquet_hall = new Room(
        "Banquet Hall",
        "D",
        "-----"
        );
    banquet_hall._Enemies.Add(new SmilingPolitician());
    banquet_hall._ForwardPaths.Add("G");

    //E
    Room boiler_room = new Room(
        "Boiler Room",
        "E",
        "----"
        );
    boiler_room._Enemies.Add(new Bat());
    boiler_room._Enemies.Add(new Bat());
    boiler_room._Enemies.Add(new Bat());
    boiler_room._ForwardPaths.Add("H");
    boiler_room._ForwardPaths.Add("G");

    //F
    Room garden_terrace = new Room(
        "Garden Terrace",
        "F",
        "A beautiful terrace overlooking a lush garden. They have pumpkins! Oh my there's a Deadly, Venomous Scarecrow! (and a lizard)"
        );
    garden_terrace._Enemies.Add(new Scarecrow());
    garden_terrace._Enemies.Add(new Lizard());
    garden_terrace._ForwardPaths.Add("H");

    //G
    Room lab = new Room(
        "Lab",
        "G",
        "-----"
        );
    lab._Enemies.Add(new BallofEnergy());
    lab._ForwardPaths.Add("I");

    //H
    Room kids_room = new Room(
        "Kid's Room",
        "H",
        "There's this pretty cool kids room.  It's actually very clean and colorful.  Except, there's a dead zombie Kreepy Kid named Zach staring at you.  He attacks!"
        );
    kids_room._Enemies.Add(new KreepyChild());
    kids_room._ForwardPaths.Add("I");

    //I
    Room basement_dungeon = new Room(
        "Basement Dungeon",
        "I",
        "----"
        );
    basement_dungeon._Enemies.Add(new DeadZombieAdrian());





}

    }
}