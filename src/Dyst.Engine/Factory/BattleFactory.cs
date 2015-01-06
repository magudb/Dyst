using Dyst.Domain;

namespace Dyst.Engine.Factory
{
    public class BattleFactory
    {
        private Battle Create(Knight firstKnight, Knight secondKnight)
        {
            return new Battle();
        }
    }
}
