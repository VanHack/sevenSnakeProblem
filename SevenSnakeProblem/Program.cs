
using System;
using System.Collections.Generic;
using System.IO;

namespace SevenSnakeProblem
{
    class Program
    {
        private const string USAGE = "SevenSnakeProblem.exe filePath";
        private static Grid grid;
        private static List<Snake> validSnakes;
        private static List<List<Direction>> validMoves;

        static void Main(string[] args)
        {
            if (!ValidateArgs(args))
            {
                return;
            }

            grid = new Grid();
            try
            {
                grid.LoadGrid(args[0]);
            }
            catch (OutOfMemoryException)
            {
                Console.Error.WriteLine("Error while loading file: Provide a smaller file.");
                return;
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(String.Format("Error while loading file: {0}", e.Message));
                return;
            }

            validMoves = MoveGenerator.GenerateValidMoves();
            validSnakes = new List<Snake>();

            for (int i = 0; i < grid.Size; i++)
            {
                for (int j = 0; j < grid.Size; j++)
                {
                    Tuple<int, int> initialCell = new Tuple<int, int>(i, j);

                    foreach (List<Direction> moves in validMoves)
                    {
                        Snake newSnake = new Snake(initialCell, grid);
                        try
                        {
                            newSnake.CreateSnake(moves);
                        }
                        catch (InvalidMoveException)
                        {
                            continue;
                        }

                        // checks if there is a snake with the same Sum
                        Snake similarSnake = validSnakes.Find(snake => snake.Sum == newSnake.Sum);
                        if (similarSnake != null && grid.CheckValidSnakes(similarSnake, newSnake))
                        {
                            Console.WriteLine(similarSnake.PrintSnakePosition());
                            Console.WriteLine(newSnake.PrintSnakePosition());
                            return;
                        }
                        else
                        {
                            validSnakes.Add(newSnake);
                        }
                    }
                }
            }

            Console.WriteLine("FAIL");
        }

        private static bool ValidateArgs(string[] args)
        {
            if (args.Length != 1)
            {
                Console.Error.WriteLine(USAGE);
                return false;
            }
            if (!File.Exists(args[0]))
            {
                Console.Error.WriteLine("File not found.");
                return false;
            }
            
            return true;
        }
    }
}
