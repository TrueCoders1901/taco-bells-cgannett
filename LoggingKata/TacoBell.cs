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

        public static List<TacoBell> GetTacoBells = new List<TacoBell>();

        public TacoBell(string name, Point loc)
        {
            this.Name = name;
            this.Location = loc;
            this.Log = new TacoLogger();
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

        public static TacoBell[] MaxDistance()
        {
            TacoBell max1 = GetTacoBells[0];
            TacoBell max2 = GetTacoBells[1];

            foreach( var bell1 in GetTacoBells )
            {
                foreach( var bell2 in GetTacoBells )
                {
                    if( max1.GetDistance(max2) < bell1.GetDistance(bell2) )
                    {
                        max1 = bell1;
                        max2 = bell2;
                    }
                }

            }
            return new TacoBell[] { max1, max2 };
        }

        public double GetDistance(ITrackable other)
        {
            var Coordinate = new GeoCoordinate(this.Location.Longitude, this.Location.Latitude);
            var othercoord = new GeoCoordinate(other.Location.Longitude, other.Location.Latitude);
            return Coordinate.GetDistanceTo(othercoord);
        }

        public static void ConsoleWriteAllBells()
        {
            foreach( var taco in TacoBell.GetTacoBells )
            {
                Console.WriteLine($"{taco.Name} : {taco.Location.Latitude} : {taco.Location.Longitude}");
            }
        }
    }
}