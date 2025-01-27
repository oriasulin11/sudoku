using Sudoku.BoardManagement;
using Sudoku.InputHandling;
using Sudoku.SolvingUnit;
using Sudoku.UI;
using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Sudoku
{
    internal class Program
    {
        public static void SolveWithUsersInput(String usersInput)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            // Validate users input
            InputValidation.ValidateInput(usersInput);

            // Init board according to users input
            Board board = new Board(ProcessInputFromConsole.GetSudokuDimentions(usersInput));
            BoardSetUp.InitilaizeBoard(board, usersInput);

            if (Solver.Solve(board, 0, 0))
            {
                stopWatch.Stop();
                ShowSudoku.PrintSudoku(board);
            }
            else
                Console.WriteLine("Sorry, this one is unsolvable");
            //Print Runtime
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine("RunTime in millisecods: " + ts.Milliseconds);


        }
        static void Main(string[] args)
        {
            Menu.ShowMenu(); 
        }
    }
}
