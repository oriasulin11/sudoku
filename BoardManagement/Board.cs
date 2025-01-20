using System;
using System.Collections.Generic;


namespace Sudoku.Board  
{
    /// <summary>
    /// The sudoku board will be represented as a matrix
    /// of hash sets. Each set will include the numbers
    /// which can fit in the cell.
    /// The board size may vary according to the _dimensions field.
    /// </summary>
    internal class Board
    {
        
        private readonly int _dimensions;
        private readonly ISet<int>[,] _board;

        public Board(int dimensions)
        {
            _dimensions= dimensions;
            _board = new HashSet<int>[dimensions, dimensions];

            //initiating each cell
            for (int row = 0; row < dimensions; row++)
            {
                for (int column = 0; column < dimensions; column++)
                {
                    _board[row,column] = new HashSet<int>();
                }
            }

        }
    }
}
