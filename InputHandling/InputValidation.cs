using Sudoku.Exceptions;
using System;

namespace Sudoku.InputHandling
{
    public static class InputValidation
    {     
        /// <summary>
        ///  This class validates the given sudoku input.
        ///Note that this class dosen't determine if a suduko
        ///is solvable or not.
        /// </summary>
        /// <param name="rawInput"></param>
        public static void ValidateInput(string rawInput)
        {
            int dimentions = ProcessInputFromConsole.GetSudokuDimentions(rawInput);
            CheckForIllegalLenght(rawInput);
            CheckForIllegalCharacters(rawInput, dimentions);
            
        }
       
        private static void CheckForIllegalLenght(string rawInput)
        {
            int dimentions = ProcessInputFromConsole.GetSudokuDimentions(rawInput);
            // Dimention is NOT a perfect square
            if (Math.Sqrt(rawInput.Length) != dimentions)
                throw new InvalidSudokuLengthException($"Invalid input length");
        }

        private static void CheckForIllegalCharacters(string rawInput, int dimentions)
        {
            foreach (var character in rawInput)
            {
                if (character > '0' + dimentions || character < '0')
                    throw new IllegalCharactersException("Found illegal characters in input");
            }
        }
    }
}
