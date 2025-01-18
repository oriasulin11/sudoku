using Sudoku.Exceptions;

namespace Sudoku.InputHandling
{
    public class InputValidation
    {
        /* 
        This class validates the given sudoku input.
        Note that this class dosen't determine if a suduko
        is solvable or not.
         */
        public static void ValidateInput(string rawInput, int dimensions)
        {
            //Invalid characters found in the input
            string invalidCharacters = "";
            // Validate input length 
            if (rawInput.Length != dimensions * dimensions)
                throw new InvalidSudokuLengthException($"Invalid input length for given dimensions ({dimensions} X {dimensions})");

            foreach (char token in rawInput)
            {
                if (!char.IsDigit(token))
                {
                    invalidCharacters += token;   
                }
            }
            // Found Illegal tokens
            if (invalidCharacters.Length != 0)
                throw new IllegalCharactersException($"found illegal chracters in input : {invalidCharacters}");
            
        }
    }
}
