using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Theory]
        [InlineData("11.22, 11.33,BLAH")]
        public void ShouldParse(string str)
        {
            TacoBell blah = TacoParser.ParseLine(str);
            Assert.Equal(blah.Location, new Point(11.22, 11.33));
            Assert.Equal(blah.Name, str.Split(',')[2]);
        }
        [Theory]
        [InlineData("-11.22, -11.33,BLAH")]
        public void ShouldParse2(string str)
        {
            TacoBell blah = TacoParser.ParseLine(str);
            Assert.Equal(blah.Location, new Point(-11.22, -11.33));
            Assert.Equal(blah.Name, str.Split(',')[2]);
        }

        [Theory]
        [InlineData("EXAMPLE")]

        [InlineData("111423ssdf,234sdf")]

        [InlineData(",,")]
        public void ShouldFailParse(string str)
        {
            Assert.Null(TacoParser.ParseLine(str));
        }
    }
}
