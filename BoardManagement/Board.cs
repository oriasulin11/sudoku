
using Sudoku.SolvingUnit;
using Sudoku.UI;
using System;
using System.Collections.Generic;


namespace Sudoku.BoardManagement 
{
    /// <summary>
    /// The sudoku board will be represented as a matrix
    /// of hash sets. Each set will include the values
    /// which can fit in the cell.
    /// The board size may vary according to the _dimensions field.
    /// A classic sudoku board is 9X9.
    /// </summary>
    internal class Board : ICloneable
    {
        public int BoxSize { get; } 
        public int Dimensions { get; }
        private readonly Cell[,] _board;

        public Board(int dimensions)
        {
            Dimensions= dimensions;
            BoxSize = (int)Math.Sqrt(dimensions);
            _board = new Cell[dimensions, dimensions];

            //initiating each cell
            for (int row = 0; row < dimensions; row++)
            {
                for (int column = 0; column < dimensions; column++)
                {
                    _board[row, column] = new Cell(Dimensions, row, column);
                }
            }

        }
        public List<Cell> GetCellsInUnit(UnitType unitType, int unitIndex)
        {
            List<Cell> cells = new List<Cell>();
            for (int pos = 0; pos < Dimensions; pos++)
            {
                cells.Add(GetCellInUnit(unitType, unitIndex, pos));
            }
            return cells;
        }
        //Returns a the set from a specified cell
        public Cell GetCell(int row, int col) => _board[row, col];

        public Cell GetCellInUnit(UnitType unitType, int unitIndex, int positionInUnit)
        {
            switch (unitType)
            {
                case UnitType.Row:
                    return GetCell(unitIndex, positionInUnit);
                case UnitType.Column:
                    return GetCell(positionInUnit, unitIndex);
                case UnitType.Box:
                    int startRow = (unitIndex / BoxSize) * BoxSize;
                    int startCol = (unitIndex % BoxSize) * BoxSize;
                    return GetCell(startRow + (positionInUnit / BoxSize), startCol + (positionInUnit % BoxSize));
                default:
                    return null;
            }
        }
        /// <summary>
        /// This function iterates over each cell in the board,
        /// and returns the cell with the least amount of possible
        /// values
        /// </summary>
        public Cell GetCellWithLeastProbabilities()
        {
            Cell minCell = null;
            int minCount = Dimensions+1;// The max number of possible values
            Cell currentCell;
            for (int rows = 0; rows < Dimensions; rows++)
            {
                //ShowSudoku.PrintSudoku(this);
                for (int columns = 0; columns < Dimensions; columns++)
                {
                    currentCell = GetCell(rows, columns);
                    // Check for unsoled cells
                    if(currentCell.FinalValue == 0 && currentCell.PossibleValues.Count < minCount)
                    {
                        minCell = GetCell(rows, columns);
                        minCount= minCell.PossibleValues.Count;
                    }
                }
            }
            return minCell;
        }
        /// <summary>
        /// This function creates a deep clone of the board
        /// </summary>
        public Object Clone()
        {
            Board newBoard = new Board(Dimensions);
            for (int row = 0; row < Dimensions; row++)
            {
                for (int column = 0; column < Dimensions; column++)
                {
                    Cell newCell = newBoard.GetCell(row, column);
                    Cell oldCell = GetCell(row, column);

                    newCell.FinalValue = oldCell.FinalValue;
                    newCell.PossibleValues = new HashSet<int>(oldCell.PossibleValues);

                }
            }
            return newBoard;
        }
        /// <summary>
        /// This function takes 2 boards and copys the contents of
        /// the backup board to the current one.
        /// </summary>
        public static void CopyBoard(Board currentBoard, Board backupBoard)
        {
            // Restore each cell's state from the backup board
            for (int row = 0; row < currentBoard.Dimensions; row++)
            {
                for (int column = 0; column < currentBoard.Dimensions; column++)
                {
                    Cell currentCell = currentBoard.GetCell(row, column);
                    Cell backupCell = backupBoard.GetCell(row, column);

                    // Restore final value
                    currentCell.FinalValue = backupCell.FinalValue;

                    // Restore possible values
                    currentCell.PossibleValues.Clear();
                    currentCell.PossibleValues.UnionWith(backupCell.PossibleValues);
                }
            }
        }
        /// <summary>
        /// This function will return a string representation
        /// of the board
        /// </summary>
        public override string ToString()
        {
            string output = "";
            for (int rows = 0; rows < Dimensions; rows++)
            {
                for (int columns = 0; columns < Dimensions; columns++)
                {
                    output += GetCell(rows, columns).FinalValue;
                }
            }
            return output;
        }
    }
}
