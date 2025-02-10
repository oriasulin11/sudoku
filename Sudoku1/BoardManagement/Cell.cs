using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.BoardManagement
{
    public class Cell
    {
        public ISet<int> PossibleValues { get; set; }
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
