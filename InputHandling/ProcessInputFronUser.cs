using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.InputHandling
{
    /// <summary>
    /// This class will read input from the user
    /// directly.
    /// </summary>
    internal class ProcessInputFronUser
    {
        public static string TakeInputFromUser()
        {
            Console.WriteLine("Enter Sudoku:\n");
            try
            {
                string sudokuBoard = Console.ReadLine();
                return sudokuBoard;
            }
            catch (IOException e) { Console.WriteLine(e.Message); TakeInputFromUser(); }
            catch (OutOfMemoryException e) { Console.WriteLine(e.Message); TakeInputFromUser(); }
            catch (ArgumentOutOfRangeException e) { Console.WriteLine(e.Message); TakeInputFromUser(); }


            return String.Empty;
        }
        /// <summary>
        /// returns dimentions of the sudoku
        /// </summary>
        /// <param name="rawInput"></param>
        public static int GetSudokuDimentions(string rawInput) => (int)Math.Sqrt(rawInput.Length);
    }
}
