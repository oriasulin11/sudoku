using System;
using System.Collections.Generic;
using System.Linq;


namespace Sudoku.BoardManagement
{
    /// <summary>
    /// A cell in the board
    /// </summary>
    public class Cell
    {
        public ISet<int> PossibleValues { get; set; } // Posible candidates for this cell
        public int FinalValue { get; set; } 
        public int Row { get; }
        public int Column { get; }

        public Cell(int dimensions, int row, int column)
        {
            PossibleValues = new HashSet<int>(Enumerable.Range(1, dimensions));
            Row = row;
            Column = column;
        }
    }
}
