using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Exceptions
{
    public class InvalidSudokuLengthException : Exception
    {

        public InvalidSudokuLengthException(string message)
            :base(message){ }
    }
}
