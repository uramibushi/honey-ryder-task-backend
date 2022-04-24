using System;
using HoneyRyderTask.Domain.Models.Tasks;
using Xunit;

namespace HoneyRyderTaskTests.Tests.Domain.Models.Tasks
{
    /// <summary>
    /// TaskSchedulePeriod - test
    /// </summary>
    public class TaskSchedulePeriod_Test
    {
        [Fact(DisplayName = "[ValueOf(startDate, endDate)] 指定した値で予定期間を生成できる")]
        public void ValueOf_Test1()
        {
            // arrange
            var startDate = new DateTime(2020, 1, 1);
            var endDate = new DateTime(2022, 3, 31);

            // act
            var planPeriod = TaskSchedulePeriod.ValueOf(startDate, endDate);

            // assert
            Assert.Equal(startDate, planPeriod.StartDate);
            Assert.Equal(endDate, planPeriod.EndDate);
        }

        [Fact(DisplayName = "[ValueOf(startDate, endDate)] 指定日時の時間部分は丸められて日付のみになる")]
        public void ValueOf_Test2()
        {
            // arrange
            var startDate = new DateTime(2020, 1, 1, 11, 12, 13);
            var endDate = new DateTime(2022, 3, 31, 14, 15, 16);

            // act
            var planPeriod = TaskSchedulePeriod.ValueOf(startDate, endDate);

            // asserts
            Assert.NotEqual(startDate, planPeriod.StartDate);
            Assert.NotEqual(endDate, planPeriod.EndDate);
            Assert.Equal(startDate.Date, planPeriod.StartDate);
            Assert.Equal(endDate.Date, planPeriod.EndDate);
        }

        [Fact(DisplayName = "[ValueOf(startDate, endDate)] 開始日が終了日の未来日の場合、例外が投げられる")]
        public void ValueOf_Test3()
        {
            // arrange
            var startDate = new DateTime(2022, 4, 1);
            var endDate = new DateTime(2022, 3, 31);

            // act
            var target = () => TaskSchedulePeriod.ValueOf(startDate, endDate);

            // asserts
            var ex = Assert.Throws<Exception>(target);
            Assert.Equal("開始日と終了日の前後関係に誤りがあります。", ex.Message);
        }

        [Fact(DisplayName = "[ValueOf(startDate, endDate)] 開始日が終了日が同日の場合は日付期間を生成できる")]
        public void ValueOf_Test4()
        {
            // arrange
            var startDate = new DateTime(2022, 4, 1);
            var endDate = new DateTime(2022, 4, 1);

            // act
            var planPeriod = TaskSchedulePeriod.ValueOf(startDate, endDate);

            // asserts
            Assert.Equal(startDate, planPeriod.StartDate);
            Assert.Equal(endDate, planPeriod.EndDate);
        }
    }
}
