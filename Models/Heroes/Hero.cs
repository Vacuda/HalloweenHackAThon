namespace HauntedHouse.Models
{
    public abstract class Hero
    {
        //Fields
        public string _Name;
        public int _Attack;
        public int _Defense;
        protected int _Health;
        public string _Hat;
        public int _Special;

        //Constructor
        public Hero(string name)
        {
            _Name = name;
            _Attack = 0;
            _Defense = 0;
            _Health = 0;
            _Special = 3;
        }
        //Properties
        public int health{
            get{return _Health;}
            set{_Health = value;}
        }
        
        //Methods
        public abstract void Attack(Enemy target);

        // public abstract void Special();

        public abstract bool CheckDead();



    }
}