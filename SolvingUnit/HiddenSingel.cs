using Sudoku.BoardManagement;
using Sudoku.UI;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.SolvingUnit
{
    /// <summary>
    /// This heuristic is quite simple,
    /// we iterate over each row column and box.
    /// if a candidate appear in only one cell,
    /// congrats... its a hidden singel and must
    /// go in that cell.
    /// </summary>
    internal class HiddenSingel
    {
        public static void SolveForHiddenSingles(Board board)
        {
            bool foundHidden = false;
            // Index of first cell in box 
            int boxRow, boxCol;
            for (int index = 0; index < board.Dimensions; index++)
            {
                
                
                int hiddenSingleInRow = CheckForHiddenSingleInRow(board, index);
                // Found hidden single in row
                if (hiddenSingleInRow != 0)
                {
                    LocateHiddenSingleInRow(board, index, hiddenSingleInRow); // Locate and remove it
                    foundHidden= true;
                }
                int hiddenSingleInCol = CheckForHiddenSingleInCol(board, index);
                // Found hidden single in column
                if (hiddenSingleInCol != 0)
                {
                    LocateHiddenSingelsInCol(board, index, hiddenSingleInCol);// Locate and remove it
                    foundHidden= true;
                }
                boxRow = board.BoxSize * (index / board.BoxSize);
                boxCol = board.BoxSize  * (index % board.BoxSize);
                int hiddenSingleBox = CheckForHiddenSingleInBox(board, boxRow, boxCol);
                // Found hidden single in box
                if (hiddenSingleBox != 0)
                {
                    LocateHiddenSingleInBox(board, boxRow, boxCol, hiddenSingleBox); //Locate and remove it
                    foundHidden = true;
                }
              
            }
            // When found hidden singles look for them, again
            if (foundHidden)
                SolveForHiddenSingles(board);
        }
        /// <summary>
        /// This function checks for hidden singles in a given row
        /// </summary>
        /// <returns>0 if no value found</returns>
        private static int CheckForHiddenSingleInRow(Board board, int rowNum)
        {
            // This array will count the apparence of each number in the row
            int[] array_of_counters = new int[board.Dimensions];

            int hiddenSingle;

            // Iterate over the row
            for (int column = 0; column < board.Dimensions; column++)
            {
                Cell cell = board.GetCell(rowNum, column);
                // The Cell value is still unknown
                if (cell.FinalValue == 0)
                {
                    foreach (var number in cell.PossibleValues.ToList())
                        array_of_counters[number-1]++;
                }
            }
            hiddenSingle = Array.IndexOf(array_of_counters, 1) + 1;
            return hiddenSingle;


        }

        /// <summary>
        /// This function checks for hidden singles in a given box
        /// </summary>
        /// <param name="board"></param>
        /// <param name="colNum">the index of the first column in the box</param>
        /// <param name="rowNum">the index of the first row in the box</param>
        /// <returns>0 If a hidden single was not found in the box</returns>
        private static int CheckForHiddenSingleInBox(Board board, int rowNum, int colNum)
        {
            // This array will count the apparence of each number in the row
            int[] array_of_counters = new int[board.Dimensions];

            int hiddenSingle;
            

            // Iterate over each cell of the box
            for (int index = 0; index < board.Dimensions; index++)
            {
                Cell cell = board.GetCell(rowNum + index / board.BoxSize, colNum + index % board.BoxSize);
                // The Cell value is still unknown
                if (cell.FinalValue == 0)
                {
                    foreach (var number in cell.PossibleValues.ToList())
                        array_of_counters[number-1]++;
                }
            }
            hiddenSingle = Array.IndexOf(array_of_counters, 1) + 1;

            return hiddenSingle;
        }
        

        /// <summary>
        /// This function checks for hidden singles in a given column 
        /// </summary>
        /// <param name="board"></param>
        /// <param name="colNum"></param>
        /// <returns>0 If a hidden single was not found in the column</returns>
        private static int CheckForHiddenSingleInCol(Board board, int colNum)
        {
            // This array will count the apparence of each number in the row
            int[] array_of_counters = new int[board.Dimensions];

            int hiddenSingle;

            // Iterate over the column
            for (int row = 0; row < board.Dimensions; row++)
            {
                Cell cell = board.GetCell(row, colNum);
                // The Cell value is still unknown
                if (cell.FinalValue == 0)
                {
                    foreach (var number in cell.PossibleValues.ToList())
                        array_of_counters[number-1]++;
                }
            }
            hiddenSingle = Array.IndexOf(array_of_counters, 1) + 1;
            return hiddenSingle;


        }

        /// <summary>
        /// This function locates the given single in
        /// a given column and places it the right cell
        /// </summary>
        /// <param name="board"></param>
        /// <param name="colNum"></param>
        /// <param name="value"></param>
        private static void LocateHiddenSingelsInCol(Board board, int colNum, int value)
        {
            for (int row = 0; row < board.Dimensions; row++)
            {
                Cell cell = board.GetCell(row, colNum);
                if (cell.FinalValue == 0 && cell.PossibleValues.Contains(value))
                {
                    cell.FinalValue = value;
                    cell.PossibleValues.Clear();
                    NeighborsUpdater.UpdateNeighbors(board, row, colNum, value);
                }


            }
        }

        /// <summary>
        /// This function will locate the position of the
        /// hidden single in the row and place the value in the wanted cell
        /// </summary>
        /// <param name="board"></param>
        /// <param name="rowNum"></param>
        /// <param name="value"></param>
        private static void LocateHiddenSingleInRow(Board board, int row, int value)
        {
            for (int column = 0; column < board.Dimensions; column++)
            {
                Cell cell = board.GetCell(row, column);
                if (cell.FinalValue == 0 && cell.PossibleValues.Contains(value))
                {
                    cell.FinalValue = value;
                    cell.PossibleValues.Clear();
                    NeighborsUpdater.UpdateNeighbors(board, row, column, value);
                }
            }

        }
        /// <summary>
        ///  This function locates the hidden single in
        /// a given column and places it the right cell
        /// </summary>
        /// <param name="board"></param>
        /// <param name="colNum">The first index of the column</param>
        /// <param name="rowNum">The first index of the row</param>
        /// <param name="value"></param>
        private static void LocateHiddenSingleInBox(Board board, int rowNum, int colNum, int value)
        {
           
            for (int index = 0; index < board.Dimensions; index++)
            {
                int rowIndex = rowNum + index / board.BoxSize;
                int colIndex = colNum + index % board.BoxSize;
                Cell cell = board.GetCell(rowIndex,colIndex);
                if (cell.FinalValue == 0 && cell.PossibleValues.Contains(value))
                {
                    cell.FinalValue = value;
                    cell.PossibleValues.Clear();
                    NeighborsUpdater.UpdateNeighbors(board, rowIndex,colIndex, value);
                }
            }
        }


    }
    
}

