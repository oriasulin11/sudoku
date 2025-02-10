using Sudoku.BoardManagement;
using Sudoku.InputHandling;
using Sudoku.SolvingUnit;
using Sudoku.UI;
using System;
using System.Diagnostics;
using System.IO;
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
            // Apply naked sets heuristic once
            if(board.Dimensions == 9)
                NakedSets.ApplyNakedSets(board);
            
            if (Solver.Solve(board))
            {
                stopWatch.Stop();
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                // Print solution to file
                using(StreamWriter writer = new StreamWriter(Path.Combine(docPath, "OutputFile.txt"), append:true))
                {
                    writer.WriteLine(board.ToString());
                }
                // Show sudoku to console
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
        public static void SolveFromFile(String fileName)
        {
            int solvedCount = 0;
            using (StreamReader streamReader = new StreamReader(fileName))
            {
                string sudokuBoard;

                // Read and solve boards from the file until the end of
                // the file is reached.
                while ((sudokuBoard = streamReader.ReadLine()) != null)
                {
                    Program.SolveWithUsersInput(sudokuBoard.Trim());
                    solvedCount++;
                }
            }
        }
        static void Main(string[] args)
        {
            Menu.ShowMenu(); 
        }
    }
}
