using CreditSuisse.Infrastructure.Utilities;
using Xunit;

namespace CreditSuisse.UnitTests.Utilities
{
    public class TradeHelperTests
    {
        #region BEFORE PEP

        [Theory]
        [InlineData("2000000 Private 12/29/2025")]
        [InlineData("400000 Public 07/01/2020")]
        [InlineData("5000000 Public 01/02/2024")]
        [InlineData("3000000 Public 10/26/2023")]
        public void CheckIfStringAreOk_BeforePEP(string? inputTrade)
        {
            // Act
            var result = TradeHelper.IsTrade(inputTrade);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("4A")]
        [InlineData("500 fAKE")]
        [InlineData("300 Public 15/26/2023")]
        public void CheckIfStringAreWrong_BeforePEP(string? inputTrade)
        {
            // Act
            var result = TradeHelper.IsTrade(inputTrade);

            // Assert
            Assert.False(result);
        }

        #endregion BEFORE PEP

        #region AFTER PEP

        [Theory]
        [InlineData("2000000 Private 12/29/2025 true")]
        [InlineData("400000 Public 07/01/2020 false")]
        [InlineData("5000000 Public 01/02/2024 false")]
        [InlineData("3000000 Public 10/26/2023 false")]
        [InlineData("300000 Public 10/26/2023 true")]
        public void CheckIfStringAreOk_AfterPEP(string? inputTrade)
        {
            // Act
            var result = TradeHelper.IsTrade(inputTrade);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("4A")]
        [InlineData("500 fAKE")]
        [InlineData("300 Public 15/26/2023")]
        [InlineData("400 Public 12/26/2023 sa")]
        public void CheckIfStringAreWrong_AfterPEP(string? inputTrade)
        {
            // Act
            var result = TradeHelper.IsTrade(inputTrade);

            // Assert
            Assert.False(result);
        }

        #endregion AFTER PEP
    }
}
