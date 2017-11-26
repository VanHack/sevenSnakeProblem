using System;
using System.Collections.Generic;
using System.Text;

namespace SevenSnakeProblem
{
    internal class Snake
    {
        private Grid grid;
        private int sum;

        private List<Tuple<int, int>> cells;
        public List<Tuple<int, int>> Cells { get => cells; set => cells = value; }
        public int Sum { get => sum; }

        public Snake(Tuple<int, int> initialCell, Grid grid)
        {
            cells = new List<Tuple<int, int>>();
            cells.Add(initialCell);
            this.grid = grid;
            sum = this.grid.CurrentGrid[initialCell.Item1, initialCell.Item2];
         }

        /** 
         * Creates a snake from a list of directions.
         */
        public void CreateSnake(List<Direction> directionsList)
        {
            foreach (Direction direction in directionsList)
            {
                CreateNextCell(direction);
            }
        }

        /**
         * Defines a new cell for a snake, given a direction.
         */
        public void CreateNextCell(Direction direction)
        {
            if (!CanMoveTo(direction))
            {   
                throw new InvalidMoveException();
            }

            Tuple<int, int> nextCell;

            switch (direction)
            {
                case Direction.UP:
                    nextCell = new Tuple<int, int>(GetCurrentCell().Item1 - 1, GetCurrentCell().Item2);
                    break;
                case Direction.DOWN:
                    nextCell = new Tuple<int, int>(GetCurrentCell().Item1 + 1, GetCurrentCell().Item2);
                    break;
                case Direction.LEFT:
                    nextCell = new Tuple<int, int>(GetCurrentCell().Item1, GetCurrentCell().Item2 - 1);
                    break;
                case Direction.RIGHT:
                    nextCell = new Tuple<int, int>(GetCurrentCell().Item1, GetCurrentCell().Item2 + 1);
                    break;
                default:
                    nextCell = null;
                    break;
            }

            if (nextCell != null && !cells.Contains(nextCell))
            {
                cells.Add(nextCell);
                sum += grid.CurrentGrid[nextCell.Item1, nextCell.Item2];
            }
            else
            {
                throw new InvalidMoveException();
            }
        }

        /**
         * Checks if a new snake cell can be added to the given direction.
         */
        private bool CanMoveTo(Direction d)
        {
            switch (d)
            {
                case Direction.UP:
                    return GetCurrentCell().Item1 > 0;
                case Direction.DOWN:
                    return GetCurrentCell().Item1 < grid.Size - 1;
                case Direction.LEFT:
                    return GetCurrentCell().Item2 > 0;
                case Direction.RIGHT:
                    return GetCurrentCell().Item2 < grid.Size - 1;
                default:
                    return false;
            }
        }

        /**
         * Prints the cells occupied by the snake.
         */
        public String PrintSnakePosition()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Tuple<int, int> tuple in cells)
            {
                sb.Append(String.Format("({0}, {1}), ", tuple.Item1 + 1, tuple.Item2 + 1));
            }

            char[] charsToTrim = { ' ', ',' };
            return String.Format("[{0}]", sb.ToString().Trim(charsToTrim));
        }

        /**
         * Gets the last cell added to the snake.
         */
        private Tuple<int, int> GetCurrentCell()
        {
            return cells[cells.Count - 1];
        }
    }
}