using Sudoku.SolvingUnit;

namespace Sudoku.BoardManagement
{
    /// <summary>
    /// This class is responsable for
    /// the initial set up of the board
    /// using the user's string input.
    /// </summary>
    public static class BoardSetUp
    {
        /// <summary>
        /// This function iterates over the sudoku
        /// string and place each number in the corresponding
        /// cell in the board.
        /// When placing a number in a cell, this number
        /// can't show up in the the same row culumn or box.
        /// therefore an update to the nehiboring cells is requierd
        /// For 9x9 boards we will apply the naked sets heuristc
        /// </summary>
        public static void InitilaizeBoard(Board board, string sudokuString)
        {
            int stringIndex = 0, number;
            for (int row = 0; row < board.Dimensions; row++)
            {
                for(int column = 0; column < board.Dimensions; column++)
                {
                    number = sudokuString[stringIndex] - '0';
                    // Checking for non empty cells
                    if (number != 0)
                    {
                        // Retreving the corresponding cell
                        Cell cell = board.GetCell(row, column);

                        cell.FinalValue = number;
                        cell.PossibleValues.Clear();

                        // Eliminating the number from neighbors possible values.
                        NeighborsUpdater.UpdateNeighbors(board, row, column, number);

                    }
                    stringIndex++;
                }
            }
            if(board.Dimensions == 9)
                NakedSets.ApplyNakedSets(board);
        }
    }
}
