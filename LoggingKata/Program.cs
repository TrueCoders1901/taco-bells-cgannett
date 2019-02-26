using System;
using System.Collections.Generic;
using System.Linq;
namespace LoggingKata
{
    internal class Program
    {
        private static readonly ILog logger = new TacoLogger();
        private const string csvPath = "TacoBell-US-AL.csv";

        private static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            var parser = new TacoParser(csvPath);

            foreach(string line in parser.DataLines )
            {
                TacoBell.Add(TacoParser.ParseLine(line));
            }

            var topTwo = TacoBell.MaxDistance();
            var distance = topTwo[0].GetDistance(topTwo[1]);
            logger.LogInfo($"MaxDistance({topTwo[0].Name},{topTwo[1].Name}) => {distance}");

        }
    }
}