using CreditSuisse.Domain.Entities;
using CreditSuisse.Infrastructure.Utilities;
using Xunit;

namespace CreditSuisse.UnitTests.Utilities
{
    public class TypeHelperTests
    {
        [Fact]
        public void CheckNumberOfClass_CategoryBase_BeforePEP()
        {
            //Arrange
            DateTime referenceDate = DateTime.Now;
            Trade trade = new("2000000 Private 12/29/2025");

            // Act
            var tradesBase = TypeHelper.GetEnumerableOfType<CategoryBase>(new object[] { referenceDate, trade });

            // Assert
            Assert.Equal(3, tradesBase.Count);
        }

        [Fact]
        public void CheckNumberOfClass_CategoryBase_AfterPEP()
        {
            //Arrange
            DateTime referenceDate = DateTime.Now;
            Trade trade = new("2000000 Private 12/29/2025 false");

            // Act
            var tradesBase = TypeHelper.GetEnumerableOfType<CategoryBase>(new object[] { referenceDate, trade });

            // Assert
            Assert.Equal(4, tradesBase.Count);
        }
    }
}
