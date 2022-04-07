using HoneyRyderTask.Domain.Models.Shared;
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
			//act
			var id = ULID.NewULID();

			//assert
			Assert.Equal(26, id.Value.Length);
        }

		[Fact(DisplayName = "[IsULID(value)] 指定した値がULIDであればtrueを返す")]
		public void IsULID_Test1()
        {
			//arrange
			var value = "01D0KDBRASGD5HRSNDCKA0AH53";	//26文字

			//act
			var actual = ULID.IsULID(value);

			//assert
			Assert.True(actual);
        }

		[Fact(DisplayName = "[IsULID(value)] 26文字未満の場合はfalseを返す")]
		public void IsULID_Test2()
		{
			//arrange
			var value = "01D0KDBRASGD5HRSNDCKA0AH5";	//25文字

			//act
			var actual = ULID.IsULID(value);

			//assert
			Assert.False(actual);
		}
	}
}

