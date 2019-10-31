using System.Collections.Generic;
using HauntedHouse.Models;

class Program
{   
    public static List<Room> RoomBuilds(){

        List<Room> rooms = new List<Room>();

        //A
        Room creepy_foyer = new Room(
            "Creepy Foyer",
            "A",
            "This place is gorgeous!  There's a lovely lamp over there.  AND SUDDENLY! a lizard walks into the CENTER OF THE ROOM!"
            );
        creepy_foyer._Enemies.Add(new Lizard());
        creepy_foyer._ForwardPaths.Add("B");
        creepy_foyer._ForwardPaths.Add("C");
        rooms.Add(creepy_foyer);

        //B
        Room computer_Room = new Room(
            "Computer Room",
            "B",
            "----"
            );
        computer_Room._Enemies.Add(new Unorganized());
        computer_Room._ForwardPaths.Add("D");
        computer_Room._ForwardPaths.Add("E");
        rooms.Add(creepy_foyer);

        //C
        Room lovely_living_room = new Room(
            "Lovely Living Room",
            "C",
            "It smells like burning diapers in here, but it looks cozy.  Maybe I can find some gold in here?  Just then, a very traditional ghost attacks you.  It is the source of the smell... "
            );
        creepy_foyer._Enemies.Add(new Ghost());
        creepy_foyer._ForwardPaths.Add("E");
        creepy_foyer._ForwardPaths.Add("F");
        rooms.Add(creepy_foyer);

        //D
        Room banquet_hall = new Room(
            "Banquet Hall",
            "D",
            "-----"
            );
        banquet_hall._Enemies.Add(new SmilingPolitician());
        banquet_hall._ForwardPaths.Add("G");
        rooms.Add(creepy_foyer);

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
        rooms.Add(creepy_foyer);

        //F
        Room garden_terrace = new Room(
            "Garden Terrace",
            "F",
            "A beautiful terrace overlooking a lush garden. They have pumpkins! Oh my there's a Deadly, Venomous Scarecrow! (and a lizard)"
            );
        garden_terrace._Enemies.Add(new Scarecrow());
        garden_terrace._Enemies.Add(new Lizard());
        garden_terrace._ForwardPaths.Add("H");
        rooms.Add(creepy_foyer);

        //G
        Room lab = new Room(
            "Lab",
            "G",
            "-----"
            );
        lab._Enemies.Add(new BallofEnergy());
        lab._ForwardPaths.Add("I");
        rooms.Add(creepy_foyer);

        //H
        Room kids_room = new Room(
            "Kid's Room",
            "H",
            "There's this pretty cool kids room.  It's actually very clean and colorful.  Except, there's a dead zombie Kreepy Kid named Zach staring at you.  He attacks!"
            );
        kids_room._Enemies.Add(new KreepyChild());
        kids_room._ForwardPaths.Add("I");
        rooms.Add(creepy_foyer);

        //I
        Room basement_dungeon = new Room(
            "Basement Dungeon",
            "I",
            "----"
            );
        basement_dungeon._Enemies.Add(new DeadZombieAdrian());
        rooms.Add(creepy_foyer);


        return rooms;
        }

}