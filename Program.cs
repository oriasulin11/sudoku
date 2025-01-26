using Sudoku.BoardManagement;
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
            Board board = new Board(9);
            BoardSetUp.InitilaizeBoard(board,
                "060010030830605029000000000006030900092000570000409000285000716000000000470000095");
            if (Solver.Solve(board, 0, 0))
                ShowSudoku.PrintSudoku(board);
            else
                Console.WriteLine("Sorry, this one is unsolvable");
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine("RunTime " + ts.Milliseconds);
        }
    }
}
