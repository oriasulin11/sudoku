using Sudoku.BoardManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.SolvingUnit
{
    /// <summary>
    /// A naked set is a group of N cells which all 
    /// have the same N number of possible values.
    /// When found these possible values must be in one of
    /// those cells which means we can remove them from other cells in this unit.
    /// This heuristic is highly affecive on classic 9X9 boards when apllied once.
    /// We wont apply it on higher dimention boards.
    /// </summary>
    internal class NakedSets
    {
        private const int MaxSetSize = 8;
        public static void ApplyNakedSets(Board board)
        {
            List<Cell> cellsInRow, cellsInCol, cellsInBox;
            for (int setSize = 2; setSize <= MaxSetSize; setSize++)
            {
                for (int position = 0; position < board.Dimensions; position++)
                {
                    cellsInRow = board.GetCellsInUnit(UnitType.Row, position);
                    cellsInCol = board.GetCellsInUnit(UnitType.Column, position);
                    cellsInBox = board.GetCellsInUnit(UnitType.Box, position);

                    SolveForNakedSetInUnit(cellsInRow, setSize);
                    SolveForNakedSetInUnit(cellsInCol, setSize);
                    SolveForNakedSetInUnit(cellsInBox, setSize);

                }
            }
            
        }
        private static void SolveForNakedSetInUnit(List<Cell> cells, int setSize)
        {
            // unsolved cells only
            List<Cell> unsolved = cells.Where(cell => cell.FinalValue == 0).ToList();

            // Try each combination of unsoved cells
            foreach (var combenation in unsolved.GetCombinations(setSize))
            {
                // Make a set of total candidates for each combinations
                ISet<int> candidates = combenation.SelectMany(cell => cell.PossibleValues).ToHashSet();

                // Naked set condition
                if(candidates.Count == setSize)
                {
                    foreach (var cell in unsolved.Except(combenation))
                    {
                       cell.PossibleValues.ExceptWith(candidates);
                    }

                }
            }
        }
      
        
    }
}
