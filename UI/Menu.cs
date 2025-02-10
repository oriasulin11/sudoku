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
        public static void ShowOptions()
        {
            Console.WriteLine("Enter 1 to take sudoku board from console.");
            Console.WriteLine("Enter 2 to take sudoku board from file");
            Console.WriteLine("Enter 3 to exit");
        }
        public static void ShowMenu() {

            ShowOptions();

            string usersChoise = ProcessInputFromConsole.TakeInputFromUser();
            //Take input from console
            if (usersChoise.Equals("1"))
            {
                try
                {
                    Console.WriteLine("Enter Sudoku");
                    string sudokuBoard = ProcessInputFromConsole.TakeInputFromUser();
                    Program.SolveWithUsersInput(sudokuBoard);

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message.ToString());
                }
                
            }
            // Take input from file
            else if(usersChoise.Equals("2"))
            {
                try
                {
                    Console.WriteLine("Please enter file's path");
                    string inputFile = ProcessInputFromConsole.TakeInputFromUser();

                    Program.SolveFromFile(inputFile);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message.ToString());
                    ShowMenu();
                }
            }
            // Exit
            else if (usersChoise.Equals("3"))
                return;
            // Invalid input
            else
                Console.WriteLine("Invalid input try again...");
            ShowMenu();
        }
        
    }
}
