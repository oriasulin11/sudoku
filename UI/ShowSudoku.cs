using Sudoku.BoardManagement;
using System;

namespace Sudoku.UI
{
    internal class ShowSudoku
    {
        public static void PrintSudoku(Board board)
        {
            int size = board.Dimensions;
            int boxSize = board.BoxSize;
            int cellWidth = (size > 9) ? 3 : 2; // Adjust width for double-digit numbers
            int innerWidth = (cellWidth * size) + (boxSize * 3) - 1 + size; // Dynamic separator width

            string horizontalBorder = "+" + new string('-', innerWidth) + "+";

            Console.WriteLine(horizontalBorder); // Top border

            for (int row = 0; row < size; row++)
            {
                if (row % boxSize == 0 && row != 0)
                    Console.WriteLine("|" + new string('-', innerWidth) + "|");

                Console.Write("|"); // Left border

                for (int col = 0; col < size; col++)
                {
                    if (col % boxSize == 0)
                        Console.Write(" | ");

                    int value = board.GetCell(row, col).FinalValue;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(value.ToString().PadLeft(cellWidth) + " ");
                    Console.ResetColor();
                }

                Console.WriteLine("|"); // Right border
            }

            Console.WriteLine(horizontalBorder); // Bottom border
        }
    }
}
