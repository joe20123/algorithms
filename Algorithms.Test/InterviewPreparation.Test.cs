using System;
using Xunit;
using AlgorithmsLibrary;
using System.Linq;

using System.Collections.Generic;

namespace Algorithms.Test
{
    public class InterviewPreparationTest
    {
        [Theory]
        [InlineData("123", "321")]
        [InlineData("abc3d", "d3cba")]
        [InlineData("abc3d 3", "3 d3cba")]
        public void ReverseString_shouldReturnCorrectString(string input, string output)
        {
            //arrange
            var abc = new InterviewPreparation();
            //act
            var expected = abc.ReverseString(input);

            //assert
            Assert.True(expected == output);

        }

        [Theory]
        [InlineData(56, 2)]
        [InlineData(31283, 5)]
        public void digitCount_ShouldReturnCorrectDigits(int input, int output)
        {
            //arrange
            var abc = new InterviewPreparation();
            //act
            var expected = abc.digitCount(input);
            //assert
            Assert.True(expected == output);

        }

        [Theory]
        [InlineData(1, "one")]
        [InlineData(9, "nine")]
        [InlineData(0, "zero")]
        [InlineData(10, "ten")]
        [InlineData(11, "eleven")]
        [InlineData(19, "nineteen")]
        [InlineData(45, "forty five")]
        [InlineData(99, "ninety nine")]
        [InlineData(20, "twenty")]
        [InlineData(100, "one hundred")]
        [InlineData(102, "one hundred and two")]
        [InlineData(402, "four hundred and two")]
        [InlineData(999, "nine hundred ninety nine")]
        // [InlineData(1234, "one thousand two hundred thirty four")]
        // [InlineData(1234, "one thousand two hundred thirty four")]
        public void Turn3digitsIntegerIntoWord_ShouldReturnCorrectWordRepresentation(int input, string output)
        {
            //arrange
            var abc = new InterviewPreparation();
            //act
            var expected = abc.Turn3digitsIntegerIntoWord(input);
            //assert
            Assert.True(expected == output);
        }

        [Theory]
        [InlineData(4, new int[]{4})]
        [InlineData(45, new int[]{4, 5})]
        [InlineData(453921, new int[]{4, 5, 3, 9, 2, 1})]
        public void ConvertNumberToDigits_ShouldProduceDigitsArray(int input, int[] output)
        {
            var abc = new InterviewPreparation();
            var expected = abc.ConvertNumberToDigits(input);
            Assert.True(expected.SequenceEqual(output));
        }

        [Theory]
        [InlineData(new int[]{1,2,4}, 124)]
        [InlineData(new int[]{1,2,4, 0, 1}, 12401)]
        public void FormIntegerFromDigits_ShouldReturnCorrectly(int[] input, int output)
        {
            var abc = new InterviewPreparation();
            var expected = abc.FormIntegerFromDigits(input);
            Assert.True(expected == output);
        }

        [Theory]
        [InlineData(123, "one hundred twenty three")]
        [InlineData(1123, "one thousand one hundred twenty three")]
        [InlineData(111123, "one hundred and eleven thousand one hundred twenty three")]
        [InlineData(101123, "one hundred and one thousand one hundred twenty three")]
        [InlineData(1101123, "one million one hundred and one thousand one hundred twenty three")]
        [InlineData(1000000, "one million")]
        [InlineData(1, "one")]
        public void TurnNumberToWord(int input, string output)
        {
            var abc = new InterviewPreparation();
            var expected = abc.TurnNumberToWord(input);
            Assert.True(expected == output);
        }
    }
}
