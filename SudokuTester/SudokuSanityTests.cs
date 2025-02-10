using Sudoku.SolvingUnit;
using Sudoku.BoardManagement;
using Xunit;
using System.Diagnostics;
using SudokuTester;

namespace SudokuTester
{
    public class SudokuSanityTests
    {
        private static Stopwatch stopwatch = new Stopwatch();
        public static TheoryData<string, string> GetTestCases(string fileTestName)
        {
            var data = new TheoryData<string, string>();

            string fileName = Path.Combine("TestData", fileTestName);

            string[] boards = File.ReadAllLines(fileName);

            for (int i = 0; i < boards.Length; i += 2)
            {
                data.Add(boards[i], boards[i + 1]);
            }

            return data;
        }
        [Theory]
        [MemberData(nameof(GetTestCases), parameters:"EmptyBoards.txt")]
        public void ShouldSolveEmptyBoards(string emptyBoard, string expectedSolution)
        {
            // Arrange
            Board board = new Board((int)Math.Sqrt(emptyBoard.Length));
            stopwatch.Reset();
            stopwatch.Start();

            // Act
            bool IsSolved = Solver.Solve(board);

            // Assert
            stopwatch.Stop();

            Assert.True(IsSolved, "Unable to solve board");
            Assert.Equal(expectedSolution, board.ToString());
            // Under one second
            Assert.InRange(stopwatch.ElapsedMilliseconds, 0, 1000);
        }
        [Theory]
        [MemberData(nameof(GetTestCases), parameters: "UnsolvableBoards.txt")]
        public void ShouldHandleUnsolableBoards(string unsolvableBoard, string expectedSolution)
        {
            // Arrange
            Board board = new Board((int)Math.Sqrt(unsolvableBoard.Length));
            BoardSetUp.InitilaizeBoard(board, unsolvableBoard);
            stopwatch.Reset();
            stopwatch.Start();

            // Act
            bool IsSolved = Solver.Solve(board);

            // Assert
            stopwatch.Stop();

            Assert.False(IsSolved);
            // Under one second
            Assert.InRange(stopwatch.ElapsedMilliseconds, 0, 1000);
        }
        [Theory]
        [MemberData(nameof(GetTestCases), parameters: "HardBoards.txt")]
        public void ShouldSolveHardBoards(string hardBoard, string expectedSolution)
        {
            // Arrange
            Board board = new Board((int)Math.Sqrt(hardBoard.Length));
            BoardSetUp.InitilaizeBoard(board, hardBoard);
            stopwatch.Reset();
            stopwatch.Start();

            // Act
            bool IsSolved = Solver.Solve(board);

            // Assert
            stopwatch.Stop();

            Assert.True(IsSolved);
            Assert.Equal(expectedSolution, board.ToString());
            // Under one second
            Assert.InRange(stopwatch.ElapsedMilliseconds, 0, 1000);
        }
    }
}