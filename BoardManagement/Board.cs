
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
    internal class Board : ICloneable
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

        /// <summary>
        /// This function creates a deep clone of the board
        /// </summary>
        /// <returns></returns>
        public Object Clone()
        {
            Board newBoard = new Board(Dimensions);
            for (int row = 0; row < Dimensions; row++)
            {
                for (int column = 0; column < Dimensions; column++)
                {
                    Cell newCell = newBoard.GetCell(row, column);
                    Cell oldCell = GetCell(row, column);

                    newCell.FinalValue = oldCell.FinalValue;
                    newCell.PossibleValues = new HashSet<int>(oldCell.PossibleValues);

                }
            }
            return newBoard;
        }
        /// <summary>
        /// This function takes 2 boards and copys the contents of
        /// the backup board to the current one.
        /// </summary>
        /// <param name="currentBoard"></param>
        /// <param name="backupBoard"></param>
        public static void CopyBoard(Board currentBoard, Board backupBoard)
        {
            // Restore each cell's state from the backup board
            for (int row = 0; row < currentBoard.Dimensions; row++)
            {
                for (int column = 0; column < currentBoard.Dimensions; column++)
                {
                    Cell currentCell = currentBoard.GetCell(row, column);
                    Cell backupCell = backupBoard.GetCell(row, column);

                    // Restore final value
                    currentCell.FinalValue = backupCell.FinalValue;

                    // Restore possible values
                    currentCell.PossibleValues.Clear();
                    currentCell.PossibleValues.UnionWith(backupCell.PossibleValues);
                }
            }
        }
    }
}
