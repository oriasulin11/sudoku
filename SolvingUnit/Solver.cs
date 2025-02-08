using Sudoku.BoardManagement;
using Sudoku.UI;
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
        public static void ApplyHeuristic(Board board)
        {
            NakedSingels.LocateNakedSingels(board);
            HiddenSingel.SolveForHiddenSingles(board);
        }
        public static bool Solve(Board board)
        {
            try
            {
                // Apply the heuristics
                ApplyHeuristic(board);
            }
            catch (Exception ex)
            {
                // Heuistic found an error with the given board
                return false;
                
            }
           

            Cell cell = board.GetCellWithLeastProbabilities();

            // Coudn't find an unsolved cell
            if (cell == null)
                return true;

            // Found an unsolved cell with no possible candidates 
            if (cell.PossibleValues.Count == 0)              
                return false;

            
            foreach (var number in cell.PossibleValues.ToList())
            {

                Board oldBoard = (Board)board.Clone();
                cell.FinalValue = number;
                cell.PossibleValues.Clear();
                NeighborsUpdater.UpdateNeighbors(board, cell.Row, cell.Column, number);
                if (Solve(board))
                    return true;
                Board.CopyBoard(board, oldBoard);
            }
            return false;

        }
    }
}
