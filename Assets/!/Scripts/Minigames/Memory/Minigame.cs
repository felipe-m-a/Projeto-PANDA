using System.Collections.Generic;
using UnityEngine.Assertions;

namespace Panda.Minigames.Memory
{
    public class Minigame
    {
        public readonly int Rows;
        public readonly int Columns;
        public readonly int Pairs;
        public readonly IReadOnlyList<int> Symbols;

        private int _matchedPairs;

        private Minigame(int rows, int columns, IReadOnlyList<int> symbols)
        {
            Rows = rows;
            Columns = columns;
            Pairs = symbols.Count / 2;
            Symbols = symbols;
        }

        public void AddMatch()
        {
            _matchedPairs++;
        }

        public bool IsSolved()
        {
            return _matchedPairs == Pairs;
        }

        public static Minigame Generate(int rows, int columns)
        {
            Assert.IsTrue(rows * columns % 2 == 0, "A quantidade de cartas tem que ser par");

            var symbols = new List<int>();
            for (var i = 0; i < rows * columns / 2; i++)
            {
                symbols.Add(i);
                symbols.Add(i);
            }

            Utils.Shuffle(symbols);

            return new Minigame(rows, columns, symbols);
        }
    }
}