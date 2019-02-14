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

            if( !double.TryParse(line[0], out double longitude) )
            { logger.LogError($"Parse to Double failed at \"{line[0]}\"");
                return null;
            }

            if( !double.TryParse(line[1], out double latitude) )
            { logger.LogError($"Parse to Double failed at \"{line[1]}\"");
                return null;
            }

            taco.Name = line[2];
            taco.Location = new Point(longitude, latitude) ;
            Bells.Add(taco);


            return taco;
        }
    }
}