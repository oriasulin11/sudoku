using Sudoku.BoardManagement;
using System;
using System.Collections.Generic;
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
        /// <summary>
        /// This function will locate the position of the
        /// hidden single and place the value in the wanted cell
        /// </summary>
        /// <param name="board"></param>
        /// <param name="rowNum"></param>
        /// <param name="value"></param>
        private static void LocateHiddenSingleInRow(Board board, int row, int value)
        {
            for (int column = 0; column < board.Dimensions; column++)
            {
                Cell cell = board.GetCell(row, column);
                if(cell.FinalValue == 0 && cell.PossibleValues.Contains(value))
                {
                    cell.FinalValue = value;
                    cell.PossibleValues.Clear();
                    NeighborsUpdater.UpdateNeighbors(board, row, column, value);
                }
                    

            }
        }
        private static bool CheckForHiddenSingleInRow(Board board, int rowNum)
        {
            // This array will count the apparence of each number in the row
            int[] array_of_counters = new int[board.Dimensions];

            int hiddenSingle =0;

            // Iterate over the row
            for (int column = 0; column < board.Dimensions; column++)
            {
                Cell cell = board.GetCell(rowNum, column);
                // The Cell value is still unknown
                if (cell.FinalValue == 0)
                {
                    foreach (var number in cell.PossibleValues.ToList())
                        array_of_counters[number]++;
                }
            }
            hiddenSingle = Array.IndexOf(array_of_counters,1) + 1;
            // Found hidden single
            if (hiddenSingle != 0)
                return true;
            return false;
                

        }
    }
}
