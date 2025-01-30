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
        private static Stopwatch stopWatch = new Stopwatch();

        public static void SolveWithUsersInput(String usersInput)
        {
            stopWatch.Reset();
            stopWatch.Start();
            // Validate users input
            InputValidation.ValidateInput(usersInput);

            // Init board according to users input
            Board board = new Board(ProcessInputFromConsole.GetSudokuDimentions(usersInput));
            BoardSetUp.InitilaizeBoard(board, usersInput);

            
            if (Solver.Solve(board))
            {
                stopWatch.Stop();
                ShowSudoku.PrintSudoku(board);
            }
            else
            {
                stopWatch.Stop();
                Console.WriteLine("Sorry, this one is unsolvable");

            }
            //Print Runtime
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine("RunTime in millisecods: " + ts.TotalMilliseconds);
            stopWatch.Reset();


        }
        static void Main(string[] args)
        {
            Menu.ShowMenu(); 
        }
    }
}
