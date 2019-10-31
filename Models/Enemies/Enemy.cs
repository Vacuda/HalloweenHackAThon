namespace HauntedHouse.Models
{
    public abstract class Enemy
    {
        //Fields
        public string _Name;
        public int _Attack;
        protected int _Health;

        //Constructors

        //Properties
        public int health{
            get{return _Health;}
            set{_Health = value;}
        }
        //Methods
        public abstract void Attack(Hero target);

        public abstract bool CheckDead();

    }
}