using System;

namespace RockScissorsPaper.Services
{
    public interface IBoard
    {
        Winner PlayRock();
    }

    public class Board : IBoard
    {
        private readonly IRandomizer _randomizer;

        public Board(IRandomizer randomizer)
        {
            _randomizer = randomizer;
        }

        public Winner PlayRock()
        {
            Symbols computer = _randomizer.Next();
            if (computer == Symbols.Paper)
                return Winner.Computer;
            if (computer == Symbols.Scissors)
                return Winner.User;
            return Winner.None;
        }
    }

    public interface IRandomizer
    {
        Symbols Next();
    }

    class Randomizer : IRandomizer
    {
        public Symbols Next()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            return (Symbols)random.Next(1, 3);
        }
    }

    public enum Symbols
    {
        None,
        Rock,
        Scissors,
        Paper
    }

    public enum Winner
    {
        None,
        User,
        Computer
    }
}