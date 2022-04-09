using System.Linq;
using HoneyRyderTask.Domain.Models.Shared;
using HoneyRyderTaskTests.Helpers.Extensions;
using Xunit;

namespace HoneyRyderTaskTests.Tests.Domain.Models.Shared
{
    /// <summary>
    /// ULID - test
    /// </summary>
    public class ULID_Test
    {
        [Fact(DisplayName = "[NewULID()] 新しいULIDが採番される")]
        public void NewULID_Test()
        {
            // act
            var id = ULID.NewULID();

            // assert
            Assert.Equal(26, id.Value.Length);
        }

        [Fact(DisplayName = "[NewULID()] 毎回異なるIDが採番される（100回実行して確認）")]
        public void NewULID_Test2()
        {
            // act
            var ids = Enumerable.Range(1, 100).Select((i) => ULID.NewULID());

            // assert
            var isDuplicated = ids.IsDuplicated(id => id.Value);
            Assert.False(isDuplicated);
        }

        [Fact(DisplayName = "[IsULID(value)] 指定した値がULIDであればtrueを返す")]
        public void IsULID_Test1()
        {
            // arrange
            var value = "01D0KDBRASGD5HRSNDCKA0AH53";   // 26文字

            // act
            var actual = ULID.IsULID(value);

            // assert
            Assert.True(actual);
        }

        [Fact(DisplayName = "[IsULID(value)] 26文字未満の場合はfalseを返す")]
        public void IsULID_Test2()
        {
            // arrange
            var value = "01D0KDBRASGD5HRSNDCKA0AH5";    // 25文字

            // act
            var actual = ULID.IsULID(value);

            // assert
            Assert.False(actual);
        }
    }
}
