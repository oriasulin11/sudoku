
using System;
using System.Collections.Generic;


namespace Sudoku.BoardManagement 
{
    /// <summary>
    /// The sudoku board will be represented as a matrix
    /// of hash sets. Each set will include the values
    /// which can fit in the cell.
    /// The board size may vary according to the _dimensions field.
    /// A classic sudoku board is 9X9.
    /// </summary>
    internal class Board
    {
        
        public int Dimensions { get; }
        private readonly Cell[,] _board;

        public Board(int dimensions)
        {
            Dimensions= dimensions;
            _board = new Cell[dimensions, dimensions];

            //initiating each cell
            for (int row = 0; row < dimensions; row++)
            {
                for (int column = 0; column < dimensions; column++)
                {
                    _board[row, column] = new Cell(Dimensions);
                }
            }

        }

        //Returns a the set from a specified cell
        public Cell GetCell(int row, int col) => _board[row, col];

        //Returns if a cell is in the board
        public bool InBoard(int row, int col) => row >= 0 && row < Dimensions && col >= 0 && col < Dimensions;
    }
}
