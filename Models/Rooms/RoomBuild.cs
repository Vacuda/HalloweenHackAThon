using System.Collections.Generic;
using HauntedHouse.Models;

namespace HauntedHouse.Models
{

    class Program2
    {   
        public static List<Room> RoomBuilds(){

            List<Room> rooms = new List<Room>();

            //I
            Room basement_dungeon = new Room(
                "Basement Dungeon",
                "I",
                "----"
                );
            basement_dungeon._Enemies.Add(new DeadZombieAdrian());
            rooms.Add(basement_dungeon);

            //H
            Room kids_room = new Room(
                "Kid's Room",
                "H",
                "There's this pretty cool kids room.  It's actually very clean and colorful.  Except, there's a dead zombie Kreepy Kid named Zach staring at you.  He attacks!"
                );
            kids_room._Enemies.Add(new KreepyChild());
            kids_room._ForwardPaths.Add(basement_dungeon);
            rooms.Add(kids_room);

            //G
            Room lab = new Room(
                "Lab",
                "G",
                "-----"
                );
            lab._Enemies.Add(new BallofEnergy());
            lab._ForwardPaths.Add(basement_dungeon);
            rooms.Add(lab);

            //F
            Room garden_terrace = new Room(
                "Garden Terrace",
                "F",
                "A beautiful terrace overlooking a lush garden. They have pumpkins! Oh my there's a Deadly, Venomous Scarecrow! (and a lizard)"
                );
            garden_terrace._Enemies.Add(new Scarecrow());
            garden_terrace._Enemies.Add(new Lizard());
            garden_terrace._ForwardPaths.Add(kids_room);
            rooms.Add(garden_terrace);

            //E
            Room boiler_room = new Room(
                "Boiler Room",
                "E",
                "----"
                );
            boiler_room._Enemies.Add(new Bat());
            boiler_room._Enemies.Add(new Bat());
            boiler_room._Enemies.Add(new Bat());
            boiler_room._ForwardPaths.Add(kids_room);
            boiler_room._ForwardPaths.Add(lab);
            rooms.Add(boiler_room);

            //D
            Room banquet_hall = new Room(
                "Banquet Hall",
                "D",
                "-----"
                );
            banquet_hall._Enemies.Add(new SmilingPolitician());
            banquet_hall._ForwardPaths.Add(lab);
            rooms.Add(banquet_hall);

            //C
            Room lovely_living_room = new Room(
                "Lovely Living Room",
                "C",
                "It smells like burning diapers in here, but it looks cozy.  Maybe I can find some gold in here?  Just then, a very traditional ghost attacks you.  It is the source of the smell... "
                );
            lovely_living_room._Enemies.Add(new Ghost());
            lovely_living_room._ForwardPaths.Add(boiler_room);
            lovely_living_room._ForwardPaths.Add(garden_terrace);
            rooms.Add(lovely_living_room);

            //B
            Room computer_room = new Room(
                "Computer Room",
                "B",
                "----"
                );
            computer_room._Enemies.Add(new Unorganized());
            computer_room._ForwardPaths.Add(banquet_hall);
            computer_room._ForwardPaths.Add(boiler_room);
            rooms.Add(computer_room);

            //A
            Room creepy_foyer = new Room(
                "Creepy Foyer",
                "A",
                "This place is gorgeous!  There's a lovely lamp over there.  AND SUDDENLY! a lizard walks into the CENTER OF THE ROOM!"
                );
            creepy_foyer._Enemies.Add(new Lizard());
            creepy_foyer._ForwardPaths.Add(computer_room);
            creepy_foyer._ForwardPaths.Add(lovely_living_room);
            rooms.Add(creepy_foyer);

            return rooms;
        }

    }
}