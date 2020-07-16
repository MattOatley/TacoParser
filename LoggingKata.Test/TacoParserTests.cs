using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            // TODO: Complete Something, if anything

            //Arrange
            TacoParser sut = new TacoParser();
            //Act
            var actual = sut.Parse("34,88,Taco Bell Atmore");
            //Assert
            Assert.NotNull(actual);
        }

        [Theory]
        [InlineData("34,88,Taco Bell Atmore", 34, 88, "Taco Bell Atmore")]
        public void ShouldParse(string str, double lat, double log, string expected)
        {
            // TODO: Complete Should Parse
            //Arrange
            TacoParser sut = new TacoParser();
            //Act
            var actual = sut.Parse(str);
            //Assert
            Assert.Equal(expected, actual.Name);
            Assert.Equal(lat, actual.Location.Latitude);
            Assert.Equal(log, actual.Location.Longitude);

        }

        [Theory]
        //[InlineData(null)]
        [InlineData("")]
        [InlineData("34,88,Taco Bell Atmore")]
        public void ShouldFailParse(string str)
        {
            // TODO: Complete Should Fail Parse
            //Arrange
            TacoParser sut = new TacoParser();
            //Act
            var actual = sut.Parse(str);
            //Assert
            Assert.Equal(null, actual);
        }
    }
}
