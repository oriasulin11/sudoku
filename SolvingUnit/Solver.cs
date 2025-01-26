using Sudoku.BoardManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.SolvingUnit
{
    /// <summary>
    /// This is the main solving algorithem.
    /// this is algorithem uses recursive backtracking
    /// to solve the sudoku by "guessing" a number and when
    /// incountering a problem, we backtrack and try a diffrent one.
    /// Additionaly the algorithem use various heuristics to chop down
    /// the recursion tree, and gurentee short solving time.
    /// </summary>
    internal static class Solver
    {
        public static bool Solve(Board board, int row, int column)
        {
            // Checking if we reached the end of the board
            if (row == board.Dimensions)
                return true;
            // Checking if we reached the end of a row
            if (column == board.Dimensions)
                return Solve(board, row + 1, 0);

            Cell cell = board.GetCell(row, column);
            // If the cell is already solved, move to the next one
            if (cell.FinalValue != 0)
                return Solve(board, row, column + 1);
            HiddenSingels.LocateHiddenSingels(board);

            //Check if the heuristic found the missing value
            if (cell.FinalValue != 0)
                return Solve(board, row, column + 1);
            foreach (var number in cell.PossibleValues.ToList())
            {

                Board oldBoard = (Board)board.Clone();

                cell.FinalValue = number;
                cell.PossibleValues.Clear();
                NeighborsUpdater.UpdateNeighbors(board, row, column, number);
                if (Solve(board, row, column + 1))
                    return true;
                Board.CopyBoard(board, oldBoard);
            }
            return false;







        }
    }
}
