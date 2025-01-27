using Sudoku.BoardManagement;
using Sudoku.InputHandling;
using Sudoku.SolvingUnit;
using Sudoku.UI;
using System;
using System.Diagnostics;

namespace Sudoku
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            string sudokuBoard = ProcessInputFronUser.TakeInputFromUser();
            InputValidation.ValidateInput(sudokuBoard);
            Board board = new Board(ProcessInputFronUser.GetSudokuDimentions(sudokuBoard));
            BoardSetUp.InitilaizeBoard(board,sudokuBoard);
            if (Solver.Solve(board, 0, 0))
                ShowSudoku.PrintSudoku(board);
            else
                Console.WriteLine("Sorry, this one is unsolvable");
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine("RunTime " + ts.Milliseconds);
        }
    }
}
