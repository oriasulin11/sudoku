using Sudoku.BoardManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.SolvingUnit
{
    /// <summary>
    /// This heuristic is the simplest one.
    /// we iterate over the board and search for cells
    /// with only one possible number. if such cell exists,
    /// we update it, and do another iteration.
    /// </summary>
    internal static class NakedSingels
    {
        public static void LocateNakedSingels(Board board)
        {
            for (int row = 0; row < board.Dimensions; row++)
            {
                for (int column = 0; column < board.Dimensions; column++)
                {
                    // One possible value
                    if (board.GetCell(row,column).PossibleValues.Count == 1)
                    {
                        Cell cell = board.GetCell(row, column);

                        cell.FinalValue = cell.PossibleValues.First();
                        cell.PossibleValues.Clear();
                        //Updating the neighboring cells
                        NeighborsUpdater.UpdateNeighbors(board, row,column,cell.FinalValue);

                        LocateNakedSingels(board);
                    }
                }
            }
        }
    }
}
