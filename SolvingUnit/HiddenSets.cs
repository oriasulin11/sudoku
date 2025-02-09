using Sudoku.BoardManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.SolvingUnit
{
    internal static class HiddenSets
    {


        private static Dictionary<int, List<Cell>> CheckForHiddenSetsInUnit(Board board, UnitType unitType, int unitIndex, int setSize)
        {
            // Map each candidate to a list of cells which contains it
            Dictionary<int, List<Cell>> candidateMap = new Dictionary<int, List<Cell>>();

            for (int position = 0; position < board.Dimensions ; position++)
            {
                Cell cell = board.GetCellInUnit(unitType,unitIndex, position);
                // Unsolved cell
                if(cell.FinalValue == 0)
                {
                    foreach (var value in cell.PossibleValues.ToList())
                    {
                        if (!candidateMap.ContainsKey(value))
                            candidateMap[value] = new List<Cell>();

                        candidateMap[value].Add(cell);
                    }
                }
            }
            return candidateMap;
        }

        private static void LocateHiddenSetsInUnit(Board board, UnitType unitType, Dictionary<int, List<Cell>> candidateMap, int setSize)
        {
            var hiddenSet = candidateMap
                .Where(kv => kv.Value.Count == setSize)
                .GroupBy(kv => kv.Value); // Group the candidates which appear in the same cells

        }
    }
}
