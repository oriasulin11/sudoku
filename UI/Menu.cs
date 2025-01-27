using Sudoku.InputHandling;
using Sudoku.SolvingUnit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku.UI
{
    internal class Menu
    {
        public static void ShowMenu() {
            Console.WriteLine("Enter 1 to take sudoku board from console.");
            Console.WriteLine("Enter 2 to take sudoku board from file");
            Console.WriteLine("Enter 3 to exit");


            string usersChoise = ProcessInputFromConsole.TakeInputFromUser();
            //Take input from console
            if (usersChoise.Equals("1"))
            {
                Console.WriteLine("Enter Sudoku");
                string sudokuBoard = ProcessInputFromConsole.TakeInputFromUser();
                Program.SolveWithUsersInput(sudokuBoard);
                ShowMenu();
            }
            // Take input from file
            if(usersChoise.Equals("2"))
            {
                try
                {
                    Console.WriteLine("Please enter file's path");
                    string inputFile = ProcessInputFromConsole.TakeInputFromUser();

                    using (StreamReader streamReader = new StreamReader(inputFile))
                    {
                        string sudokuBoard;

                        // Read and solve boards from the file until the end of
                        // the file is reached.
                        while ((sudokuBoard = streamReader.ReadLine()) != null)
                        {
                            Program.SolveWithUsersInput(sudokuBoard);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    ShowMenu();
                }
            }
            if (usersChoise.Equals("3"))
                return;
            // Invalid input
            Console.WriteLine("Invalid input try again...");
            ShowMenu();
        }
        
    }
}
