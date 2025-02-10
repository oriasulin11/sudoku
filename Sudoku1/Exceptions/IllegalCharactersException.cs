using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Exceptions
{
    public class IllegalCharactersException : Exception
    {
        public IllegalCharactersException(string message)
            :base(message) { }
    }
}
