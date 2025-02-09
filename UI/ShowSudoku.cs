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
            int value;
            for (int row = 0; row < board.Dimensions; row++)
            {
                // Prints Box horizontal outline
                if (row % board.BoxSize == 0)
                    Console.WriteLine(new String('-', board.Dimensions * 2+ board.BoxSize * 2  -1));

                for (int column = 0; column < board.Dimensions; column++)
                {
                    // Print box vertical outline 
                    if (column % board.BoxSize == 0)
                        Console.Write(" | ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    value = board.GetCell(row, column).FinalValue;
                    // Print extra whitespace for single digit numbers
                    if (value < 10)
                    {
                        Console.Write($"{board.GetCell(row, column).FinalValue}  ");
                    }
                    else
                        Console.Write($"{board.GetCell(row, column).FinalValue} ");

                    Console.ResetColor();
                }
                //Move down for a new row
                Console.WriteLine();
            }
        }
    }
}
