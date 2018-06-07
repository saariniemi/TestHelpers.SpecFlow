using System;
using SpecFlowExtensionsTests._TestHelpers;
using TestHelpers.SpecFlow;
using Xunit;

namespace SpecFlowExtensionsTests
{
    public class Get
    {
        [Fact]
        public void GivenThatTheSpecifiedColumnExist_ThenItReturnsTheValueForThatColumnd()
        {
            const string columnName = "ColumnWithName";
            var sut = ObjectBuilder.CreateTableRow(
                new[] { columnName },
                new[] { "ValueForColumnWithName" });

            var result = sut.Get<string>(columnName);

            Assert.Equal("ValueForColumnWithName", result);
        }

        [Fact]
        public void GivenThatTheSpecifiedColumnDoesNotExist_ThenItThrowsAnArgumentException()
        {
            var sut = ObjectBuilder.CreateTableRow(
                new[] { "ColumnWithName" },
                new[] { "ValueForColumnWithName" });

            Assert.Throws<ArgumentException>(() => sut.Get<string>("ColumnNameThatDoesNotExist"));
        }
    }
}