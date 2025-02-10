using Sudoku.BoardManagement;
using Sudoku.SolvingUnit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Sudoku.InputHandling;
using Sudoku.Exceptions;


namespace SudokuTester
{
    public class SudokuSmokeTest
    {
        private static Stopwatch stopwatch = new Stopwatch();

        public static TheoryData<string> GetTestCases(string fileTestName)
        {
            var data = new TheoryData<string>();

            string fileName = Path.Combine("TestData", fileTestName);

            string[] boards = File.ReadAllLines(fileName);

            for (int i = 0; i < boards.Length; i ++)
            {
                data.Add(boards[i]);
            }

            return data;
        }

        [Theory]
        [MemberData(nameof(GetTestCases), parameters: "InvalidBoardLength.txt")]
        public void ShouldThrowInvalidLenghtException(string invalidBoard)
        {
            // Arrange
            stopwatch.Reset();
            stopwatch.Start();

            // Act & assert
            Assert.Throws<InvalidSudokuLengthException>( () =>InputValidation.ValidateInput(invalidBoard));
            stopwatch.Stop();

           
            // Under one second
            Assert.InRange(stopwatch.ElapsedMilliseconds, 0, 1000);
        }
        [Theory]
        [MemberData(nameof(GetTestCases), parameters: "IllegalCharsInSudoku.txt")]
        public void ShouldThrowIllegalCharsException(string invalidBoard)
        {
            // Arrange
            stopwatch.Reset();
            stopwatch.Start();

            // Act & assert
            Assert.Throws<IllegalCharactersException>(() => InputValidation.ValidateInput(invalidBoard));
            stopwatch.Stop();


            // Under one second
            Assert.InRange(stopwatch.ElapsedMilliseconds, 0, 1000);
        }
    }
}
