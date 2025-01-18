using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.Exceptions
{
    internal class IllegalCharactersException : Exception
    {
        public IllegalCharactersException(string message)
            :base(message) { }
    }
}
