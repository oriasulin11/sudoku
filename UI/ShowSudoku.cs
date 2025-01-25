using Sudoku.BoardManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.UI
{
    /// <summary>
    /// This class will print out the
    /// (hopefuly) solved sudoku board
    /// </summary>
    internal class ShowSudoku
    {
        public static void PrintSudoku(Board board)
        {
            int boxSize = (int)Math.Sqrt(board.Dimensions);
            for (int row = 0; row < board.Dimensions; row++)
            {
                // Prints Box horizontal outline
                if (row % boxSize == 0)
                    Console.WriteLine(new String('-', board.Dimensions * boxSize));

                for (int column = 0; column < board.Dimensions; column++)
                {
                    // Print box vertical outline 
                    if (column % boxSize == 0)
                        Console.Write(" | ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{board.GetCell(row, column).FinalValue} ");
                    Console.ResetColor();
                }
                //Move down for a new row
                Console.WriteLine();
            }
        }
    }
}
