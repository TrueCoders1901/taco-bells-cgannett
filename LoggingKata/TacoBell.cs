using GeoCoordinatePortable;
using System;
using System.Collections.Generic;

namespace LoggingKata
{/// <summary>
/// TacoBell object with Name, Longitude and Latitude
/// </summary>
///
    public class TacoBell : ITrackable
    {
        public string Name { get; set; }
        public Point Location { get; set; }
        public TacoLogger Log { get; set; }
        public GeoCoordinate Coordinate { get; set; }
        public static List<TacoBell> GetTacoBells = new List<TacoBell>();

        public TacoBell(string name, Point loc)
        {
            this.Name = name;
            this.Location = loc;
            this.Log = new TacoLogger();
            this.Coordinate = new GeoCoordinate(this.Location.Longitude, this.Location.Latitude);
        }

        public TacoBell(string[] line)
        {
            TacoBell taco = TacoParser.ParseLine(line);
            this.Name = taco.Name;
            this.Location = taco.Location;
            this.Log = taco.Log;
        }

        public static void Add(TacoBell taco)
        {
            if( (taco != null) && (taco.Name != "") )
            { TacoBell.GetTacoBells.Add(taco); }
            else
            {
                (new TacoLogger()).LogError("TacoBell object empty or null, not adding to list");
            }
        }

        /// <summary>
        /// parses a line of text into a TacoBell object and logs any errors.
        /// </summary>
        /// <param name="line"> csv string or string[>=3] with values {double, double, string} </param>
        /// <returns>new TacoBell object</returns>

        public static void ConsoleWriteAllBells()
        {
            foreach( var taco in TacoBell.GetTacoBells )
            {
                Console.WriteLine($"{taco.Name} : {taco.Location.Latitude} : {taco.Location.Longitude}");
            }
        }
    }
}