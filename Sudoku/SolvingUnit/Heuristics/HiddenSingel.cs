using Sudoku.BoardManagement;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public static bool MadeProgress { get; set; } = false ;
        /// <summary>
        /// This is a generic function to check for hidden
        /// singles in a unit (row, col or box).
        /// </summary>
        /// <returns></returns>
        public static ISet<int> CheckForHiddenSinglesInUnit(Board board, int unitIndex, UnitType unitType)
        {
            int[] arrayOfCounters = new int[board.Dimensions]; //Count the appearence of each value

            for (int pos = 0; pos < board.Dimensions; pos++)
            {
                Cell cell = board.GetCellInUnit(unitType, unitIndex, pos);

                // For unsolved cells
                if(cell.FinalValue == 0)
                {
                    foreach (var number in cell.PossibleValues.ToList())
                    {
                        arrayOfCounters[number - 1]++;
                    }
                }
            }
            return GetSingles(arrayOfCounters);
        }

        public static void LocateHiddenSinglesInUnit(Board board, int unitIndex, UnitType unitType, ISet<int> singles)
        {
            int locatedCounter = 0;

            for (int position = 0; position < board.Dimensions; position++)
            {
                Cell cell = board.GetCellInUnit(unitType, unitIndex, position);

                foreach (var single in singles.ToList())
                {
                    if (cell.FinalValue == 0 && cell.PossibleValues.Contains(single))
                    {
                        cell.FinalValue = single;
                        cell.PossibleValues.Clear();
                        NeighborsUpdater.UpdateNeighbors(board, cell.Row, cell.Column, single);
                        locatedCounter++;
                    }
                }
            }
        }
    
    public static ISet<int> GetSingles(int[] arrayOfCounters)
    {
        ISet<int> singles = new HashSet<int>();

        for (int index = 0; index < arrayOfCounters.Length; index++)
        {
            if (arrayOfCounters[index] == 1)
            {
                singles.Add(index + 1);
            }
        }
        return singles;
    }

    public static bool SolveForHiddenSingles(Board board)
    {
        bool foundHidden = false;

        ISet<int> hiddenSinglesInRow = new HashSet<int>()
            , hiddenSinglesInCol = new HashSet<int>(),
            hiddenSingleInBox = new HashSet<int>(); ;
        // Index of first cell in box 
        int boxRow, boxCol;
        for (int index = 0; index < board.Dimensions; index++)
        {

            hiddenSinglesInRow = CheckForHiddenSinglesInUnit(board,index,UnitType.Row);
            // Found hidden single in row
            if (hiddenSinglesInRow.Count != 0)
            {
                LocateHiddenSinglesInUnit(board, index,UnitType.Row, hiddenSinglesInRow); // Locate and remove it
                foundHidden = true;
            }
            hiddenSinglesInCol = CheckForHiddenSinglesInUnit(board, index, UnitType.Column);
            // Found hidden single in column
            if (hiddenSinglesInCol.Count != 0)
            {
                LocateHiddenSinglesInUnit(board, index, UnitType.Column, hiddenSinglesInCol);// Locate and remove it
                foundHidden = true;
            }
            boxRow = board.BoxSize * (index / board.BoxSize);
            boxCol = board.BoxSize * (index % board.BoxSize);
            hiddenSingleInBox = CheckForHiddenSinglesInUnit(board, index, UnitType.Box);
            // Found hidden single in box
            if (hiddenSingleInBox.Count != 0)
            {
                LocateHiddenSinglesInUnit(board, index, UnitType.Box, hiddenSingleInBox); //Locate and remove it
                foundHidden = true;
            }

        }
        // When found hidden singles look for them, again
        if (foundHidden)
        {
            MadeProgress= true;
            SolveForHiddenSingles(board);
        }
        return MadeProgress;
            
    }




}
    
}

