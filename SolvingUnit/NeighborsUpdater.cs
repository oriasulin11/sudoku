using Sudoku.BoardManagement;
using System;
using System.Collections.Generic;

namespace Sudoku.SolvingUnit
{
    /// <summary>
    /// This class updates the possible values of
    /// cells in the same row, column and box.
    /// </summary>
    internal static class NeighborsUpdater
    {
        public static void UpdateNeighbors(Board board, int row, int column, int value)
        {
            UpdateRow(board, row, column, value);
            UpdateColumn(board, row, column, value);
            UpdateBox(board, row, column, value);
        }
        /// <summary>
        /// Iterate over the row and remove the number given from
        /// the possible values in the cell 
        /// </summary>
        /// <param name="board"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        public static void UpdateRow(Board board, int row, int column, int value)
        {
            for (int index = 0; index < board.Dimensions; index++)
            {
                Cell cell = board.GetCell(row, index);
                if(cell.FinalValue == 0 && cell.PossibleValues.Contains(value))
                    cell.PossibleValues.Remove(value);

            }
        }
        /// <summary>
        ///  Iterate over the column and remove the number given from
        ///  the possible values in the cell
        /// </summary>
        /// <param name="board"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        public static void UpdateColumn(Board board, int row, int column, int value)
        {
            for (int index = 0; index < board.Dimensions; index++)
            {
                Cell cell = board.GetCell(index, column);
                if (cell.FinalValue == 0 && cell.PossibleValues.Contains(value))
                    cell.PossibleValues.Remove(value);

            }
        }
        /// <summary>
        ///  Iterate over the box and remove the number given from
        ///  the possible values in the cell
        /// </summary>
        /// <param name="board"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        public static void UpdateBox(Board board, int row, int column, int value)
        {
            int sqrtOfDimension = (int)Math.Sqrt(board.Dimensions);

            //Calculate the first cell of the box in which the cell is in
            int boxRow = (row / sqrtOfDimension) * sqrtOfDimension;
            int boxColumn = (column / sqrtOfDimension) * sqrtOfDimension;

            for (int index = 0; index < board.Dimensions; index++)
            {
                Cell cell = board.GetCell(boxRow + index / sqrtOfDimension, boxColumn + index % sqrtOfDimension);
                if (cell.FinalValue == 0 && cell.PossibleValues.Contains(value))
                    cell.PossibleValues.Remove(value);

            }
        }
    }
}
