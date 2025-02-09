using Sudoku.BoardManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.SolvingUnit
{
    internal class NakedSets
    {
        public static void ApplyNakedSets(Board board)
        {
            List<Cell> cellsInRow, cellsInCol, cellsInBox;
            int maxSetSize;
            for (int setSize = 0; setSize < 9; setSize++)
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
