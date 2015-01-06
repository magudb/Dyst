using Dyst.Domain;
using Dyst.Engine.Services;

namespace Dyst.Engine.Factory
{
    public class GameFactory
    {
        private readonly IPasswordGenerator _passwordGenerator;

        public GameFactory(IPasswordGenerator passwordGenerator)
        {
            _passwordGenerator = passwordGenerator;
        }

        public Game Create(string gameMaster, string gameName)
        {
            return new Game(gameMaster, _passwordGenerator.Generate(8), gameName);
        }
    }
}
