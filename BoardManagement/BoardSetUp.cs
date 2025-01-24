using Sudoku.SolvingUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.BoardManagement
{
    /// <summary>
    /// This class is responsable for
    /// the initial set up of the board
    /// using the user's string input.
    /// </summary>
    internal static class BoardSetUp
    {
        /// <summary>
        /// This function iterates over the sudoku
        /// string and place each number in the corresponding
        /// cell in the board.
        /// When placing a number in a cell, this number
        /// can't show up in the the same row culumn or box.
        /// therefore an update to the nehiboring cells is requierd
        /// </summary>
        /// <param name="board"></param>
        /// <param name="sudokuString"></param>
        public static void InitilaizeBoard(Board board, string sudokuString)
        {
            int stringIndex = 0, number;
            for (int row = 0; row < board.Dimensions; row++)
            {
                for(int column = 0; column < board.Dimensions; column++)
                {
                    number = sudokuString[stringIndex];
                    // Checking for non empty cells
                    if (number != 0)
                    {
                        // Retreving the corresponding cell
                        Cell cell = board.GetCell(row, column);

                        cell.FinalValue = number;
                        cell._possibleValues.Clear();

                        // Eliminating the number from neighbors possible values.
                        NeighborsUpdater.UpdateNeighbors(board, row, column, number);

                    }
                }

            }
        }
    }
}
