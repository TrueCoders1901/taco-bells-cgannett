using GeoCoordinatePortable;
using System;
using System.Collections.Generic;

namespace LoggingKata
{/// <summary>
/// TacoBell object with Name, Longitude and Latitude
/// </summary>
    class TacoBell : ITrackable
    {
        public string Name { get; set; }
        public Point Location { get; set; }
        public TacoLogger Log { get; set; }
        public GeoCoordinate Coordinate { get; set; }
        public static List<TacoBell> GetTacoBells = new List<TacoBell>();


        public TacoBell(string name, Point loc) {
            this.Name = name;
            this.Location = loc;
            this.Log = new TacoLogger();
            this.Coordinate = new GeoCoordinate(this.Location.Longitude, this.Location.Latitude);
        }

        public TacoBell(string[] line) {
            TacoBell taco = TacoBell.ParseLine(line);
            this.Name = taco.Name;
            this.Location = taco.Location;
            this.Log = taco.Log;
        }
        /// <summary>
        /// parses a line of text into a TacoBell object and logs any errors.
        /// </summary>
        /// <param name="line"> csv string or string[>=3] with values {double, double, string} </param>
        /// <returns>new TacoBell object</returns>

        public static TacoBell ParseLine(string[] line) {
            TacoLogger log = new TacoLogger();
            if (line.Length < 3)
            {
                log.LogError("TacoBell.ParseLine requires a single string or string array with at least 3 indices.");
                return null;
            }
            if (line.Length > 3){ log.LogWarning("TacoBell.ParseLine has detected more than 3 indices."); }

            if( Double.TryParse(line[0], out double x) && (Double.TryParse(line[1], out double y)) )
            { return new TacoBell(line[2], new Point(x, y)); }
            else
            { log.LogError($"Invalid input for parsing to double on {line[0]} or {line[1]}");

                try
                { var rx = new System.Text.RegularExpressions.Regex(@"[^\d\.]");

                    double line0 = double.Parse(rx.Replace(line[0], ""));
                    double line1 = double.Parse(rx.Replace(line[1], ""));

                    return new TacoBell(line[2], new Point(line0, line1));
                    
                }
                catch(Exception e)
                { log.LogError("Unable to clean data", e); }
                return null;
            }
        }

        public static TacoBell ParseLine(string line) {
            return TacoBell.ParseLine(line.Split(','));
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
        public static void ConsoleWriteAllBells()
        {
            foreach( var taco in TacoBell.GetTacoBells )
            {
                Console.WriteLine($"{taco.Name} : {taco.Location.Latitude} : {taco.Location.Longitude}");
                
                
            }
             
        }

    }
}

            