using HoneyRyderTask.Domain.Helpers.Extensions;
using Xunit;

namespace HoneyRyderTaskTests.Tests.Domain.Helpers.Extensions
{
    /// <summary>
    /// decimal（拡張メソッド）- test
    /// </summary>
    public class DecimalExtension_Test
    {
        [Theory(DisplayName = "[Truncate(d, decimals)] 指定した小数桁で切り捨てを行える")]
        [InlineData(123.456, 0, 123)]
        [InlineData(123.456, 1, 123.4)]
        [InlineData(123.456, 2, 123.45)]
        [InlineData(123.456, 3, 123.456)]
        [InlineData(123.456, 4, 123.456)]
        [InlineData(-123.456, 0, -123)]
        [InlineData(-123.456, 1, -123.4)]
        [InlineData(-123.456, 2, -123.45)]
        [InlineData(-123.456, 3, -123.456)]
        [InlineData(-123.456, 4, -123.456)]
        public void Truncate_Test1(decimal d, int decimals, decimal expected)
        {
            // act
            var actual = d.Truncate(decimals);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory(DisplayName = "[ShiftLeft(d, shiftCount)] 指定した数だけ桁を左に移動する")]
        [InlineData(123.456, 0, 123.456)]
        [InlineData(123.456, 1, 1234.56)]
        [InlineData(123.456, 2, 12345.6)]
        [InlineData(123.456, 3, 123456)]
        [InlineData(123.456, 4, 1234560)]
        [InlineData(-123.456, 0, -123.456)]
        [InlineData(-123.456, 1, -1234.56)]
        [InlineData(-123.456, 2, -12345.6)]
        [InlineData(-123.456, 3, -123456)]
        [InlineData(-123.456, 4, -1234560)]
        public void ShiftLeft_Test1(decimal d, int shiftCount, decimal expected)
        {
            // act
            var actual = d.ShiftLeft(shiftCount);

            // assert
            Assert.Equal(expected, actual);
        }

        [Theory(DisplayName = "[ShiftRight(d, shiftCount)] 指定した数だけ桁を右に移動する")]
        [InlineData(123.456, 0, 123.456)]
        [InlineData(123.456, 1, 12.3456)]
        [InlineData(123.456, 2, 1.23456)]
        [InlineData(123.456, 3, 0.123456)]
        [InlineData(123.456, 4, 0.0123456)]
        [InlineData(-123.456, 0, -123.456)]
        [InlineData(-123.456, 1, -12.3456)]
        [InlineData(-123.456, 2, -1.23456)]
        [InlineData(-123.456, 3, -0.123456)]
        [InlineData(-123.456, 4, -0.0123456)]
        public void ShiftRight_Test1(decimal d, int shiftCount, decimal expected)
        {
            // act
            var actual = d.ShiftRight(shiftCount);

            // assert
            Assert.Equal(expected, actual);
        }
    }
}
