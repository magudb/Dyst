namespace Dyst.Domain
{
    public class Player
    {
        public Player(string name)
        {
            Name = name;
        }

        public void AssignKnight(Knight knight)
        {
            Knight = knight;
        }

        public string Name { get; private set; }
        public Knight Knight { get; private set; }
    }
}
