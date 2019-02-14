using System.Collections.Generic;
using System.IO;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        public static List<ITrackable> Bells = new List<ITrackable>();
        public ITrackable Parse(string[] line)
        {
            TacoBell taco = new TacoBell();
            taco.Name = line[2];
            taco.Location = new Point(double.Parse(line[0]), double.Parse(line[1])) ;
            
            // Do not fail if one record parsing fails, return null
            return null; // TODO Implement
        }
    }
}