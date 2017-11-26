using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SevenSnakeProblem
{
    class Grid
    {
        #region attributes
        int[,] currentGrid;
        int size;
        #endregion

        #region Properties
        public int Size { get => size; }
        public int[,] CurrentGrid { get => currentGrid; }
        #endregion

        /**
         * Loads information to the grid.
         */
        public void LoadGrid(String filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            if (lines.Count() <= 0)
            {
                throw new FileLoadException();
            }

            size = lines[0].Split(',').Count();

            currentGrid = new int[size, size];

            for (int i = 0; i < lines.Count(); i++)
            {
                String[] lineArray = lines[i].Split(',');

                for (int j = 0; j < lineArray.Count(); j++)
                {
                    currentGrid[i, j] = Convert.ToInt32(lineArray[j]);
                }
            }
        }

        /**
         * Checks if two snakes are valid within the grid, that is, do not share cells.
         */
        public bool CheckValidSnakes(Snake s1, Snake s2)
        {
            List<Tuple<int, int>> list = new List<Tuple<int, int>>();
            list.AddRange(s1.Cells);
            list.AddRange(s2.Cells);
            return list.Distinct().Count() == list.Count();
        }
    }
}
