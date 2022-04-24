using System;
using HoneyRyderTask.Domain.Models.Tasks;
using Xunit;

namespace HoneyRyderTaskTests.Tests.Domain.Models.Tasks
{
    /// <summary>
    /// タスク実績期間 - test
    /// </summary>
    public class TaskAchievementPeriod_Test
    {
        [Fact(DisplayName = "[ValueOf(startDate, endDate) 指定した値でタスク実績を生成できる")]
        public void ValueOf_Test1()
        {
            // arrange
            var startDate = new DateTime(2022, 4, 1);
            var endDate = new DateTime(2022, 4, 3);

            // act
            var actual = TaskAchievementPeriod.ValueOf(startDate, endDate);

            // assert
            Assert.Equal(startDate, actual.StartDate);
            Assert.Equal(endDate, actual.EndDate);
        }

        [Fact(DisplayName = "[ValueOf(startDate, endDate) 終了日は省略可能")]
        public void ValueOf_Test2()
        {
            // arrange
            var startDate = new DateTime(2022, 4, 1);
            DateTime? endDate = null;

            // act
            var actual = TaskAchievementPeriod.ValueOf(startDate, endDate);

            // assert
            Assert.Equal(startDate, actual.StartDate);
            Assert.Null(actual.EndDate);
        }

        [Fact(DisplayName = "[ValueOf(startDate, endDate)] 指定日時の時間部分は丸められて日付のみになる")]
        public void ValueOf_Test3()
        {
            // arrange
            var startDate = new DateTime(2020, 1, 1, 11, 12, 13);
            var endDate = new DateTime(2022, 3, 31, 14, 15, 16);

            // act
            var actual = TaskAchievementPeriod.ValueOf(startDate, endDate);

            // asserts
            Assert.NotEqual(startDate, actual.StartDate);
            Assert.NotEqual(endDate, actual.EndDate);
            Assert.Equal(startDate.Date, actual.StartDate);
            Assert.Equal(endDate.Date, actual.EndDate);
        }

        [Fact(DisplayName = "[ValueOf(startDate, endDate)] 開始日が終了日の未来日の場合、例外が投げられる")]
        public void ValueOf_Test4()
        {
            // arrange
            var startDate = new DateTime(2022, 4, 1);
            var endDate = new DateTime(2022, 3, 31);

            // act
            var target = () => TaskAchievementPeriod.ValueOf(startDate, endDate);

            // asserts
            var ex = Assert.Throws<Exception>(target);
            Assert.Equal("開始日と終了日の前後関係に誤りがあります。", ex.Message);
        }

        [Fact(DisplayName = "[ValueOf(startDate, endDate)] 開始日が終了日が同日の場合は日付期間を生成できる")]
        public void ValueOf_Test5()
        {
            // arrange
            var startDate = new DateTime(2022, 4, 1);
            var endDate = new DateTime(2022, 4, 1);

            // act
            var actual = TaskAchievementPeriod.ValueOf(startDate, endDate);

            // asserts
            Assert.Equal(startDate, actual.StartDate);
            Assert.Equal(endDate, actual.EndDate);
        }
    }
}
