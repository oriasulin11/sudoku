using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.BoardManagement
{
    internal class Cell
    {
        public ISet<int> PossibleValues { get; }
        public int FinalValue { get; set; } 

        public Cell(int dimensions)
        {
            PossibleValues = new HashSet<int>(Enumerable.Range(1, dimensions));
        }
    }
}
