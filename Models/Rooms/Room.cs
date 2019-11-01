using System.Collections.Generic;

namespace HauntedHouse.Models
{
    public class Room
    {
        
        //Fields
        public string _Name;
        public string _Code;
        public string _Description;
        public List<Enemy> _Enemies;
        public List<Room> _ForwardPaths;

        //Constructors
        public Room(string name, string code, string description){
            _Name = name;
            _Code = code;
            _Description = description;
            _Enemies = new List<Enemy>();
            _ForwardPaths = new List<Room>();

        }

        //Properties

        //Methods





    }
}