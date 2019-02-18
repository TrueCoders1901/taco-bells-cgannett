using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);
            
            //format each line in lines into line[0] = longitude, line[1] = latitude, line[2] = location name
            var frmtlines = lines.Select(ln => ln.Replace("/", "").Split("...")[0].Split(','));
            
            foreach( string[] line in frmtlines )
            {
                TacoBell.Add(TacoBell.ParseLine(line));
            }

            double longest = 0.0;
            TacoBell[] furthestTwo = new TacoBell[2];
            foreach( var taco in TacoBell.GetTacoBells )
            {
                foreach( var otherTaco in TacoBell.GetTacoBells )
                {
                    double comp = taco.Coordinate.GetDistanceTo(otherTaco.Coordinate);
                    if( comp > longest )
                    {
                        furthestTwo[0] = taco;
                        furthestTwo[1] = otherTaco;
                        longest = comp;
                    }
                }

            }

            logger.LogInfo($"TacoBells with the longest distance apart are: {furthestTwo[0].Name} and {furthestTwo[1].Name}");

            

            

            Console.WriteLine("Would you like to see the TacoBells?");
            while( Console.ReadKey().KeyChar.ToString().ToUpper() == "Y" )
            {   
                TacoBell.ConsoleWriteAllBells();
                Console.WriteLine("Would you like to see the TacoBells again?");
            }
            }

        ~Program() {
            Console.ReadLine();

            
        }
    }
    
}