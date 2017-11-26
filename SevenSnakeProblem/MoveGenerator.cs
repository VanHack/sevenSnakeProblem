using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SevenSnakeProblem
{
    public static class MoveGenerator
    {
        // Invalid moves that are ignored.
        private static List<List<Direction>> invalidMoves = new List<List<Direction>>() {
            new List<Direction> { Direction.UP, Direction.DOWN },
            new List<Direction> { Direction.DOWN, Direction.UP },
            new List<Direction> { Direction.LEFT, Direction.RIGHT },
            new List<Direction> { Direction.RIGHT, Direction.LEFT },
            new List<Direction> { Direction.DOWN, Direction.LEFT, Direction.UP },
            new List<Direction> { Direction.DOWN, Direction.RIGHT, Direction.UP },
            new List<Direction> { Direction.UP, Direction.LEFT, Direction.DOWN },
            new List<Direction> { Direction.UP, Direction.RIGHT, Direction.DOWN },
            new List<Direction> { Direction.LEFT, Direction.UP, Direction.RIGHT },
            new List<Direction> { Direction.LEFT, Direction.DOWN, Direction.RIGHT },
            new List<Direction> { Direction.RIGHT, Direction.UP, Direction.LEFT },
            new List<Direction> { Direction.RIGHT, Direction.DOWN, Direction.LEFT }
        };

        /**
         * Generates all movements combinations, ignoring invalid moves.
         */
        public static List<List<Direction>> GenerateValidMoves()
        {
            List<List<Direction>> resultList = new List<List<Direction>>();
            Array directionsArr = Enum.GetValues(typeof(Direction));

            foreach (Direction i in directionsArr)
            {
                foreach (Direction j in directionsArr)
                {
                    foreach (Direction k in directionsArr)
                    {
                        foreach (Direction l in directionsArr)
                        {
                            foreach (Direction m in directionsArr)
                            {
                                foreach (Direction n in directionsArr)
                                {
                                    foreach (Direction o in directionsArr)
                                    {
                                        List<Direction> list = new List<Direction> { i, j, k, l, m, n, o };

                                        // adds only valid moves
                                        bool validMove = true;
                                        foreach (List<Direction> move in invalidMoves)
                                        {
                                            if (MoveGenerator.ContainsSequence<Direction>(list, move))
                                            {
                                                validMove = false;
                                                break;
                                            }
                                        }
                                        if (validMove)
                                        {
                                            resultList.Add(list);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return resultList;
        }

        /**
         * Checks if a list contains a given sublist.
         */
        private static bool ContainsSequence<T>(this IEnumerable<T> source,
                                       IEnumerable<T> other)
        {
            int count = other.Count();
            while (source.Any())
            {
                if (source.Take(count).SequenceEqual(other))
                {
                    return true;
                }
                source = source.Skip(1);
            }
            return false;
        }
    }
}
