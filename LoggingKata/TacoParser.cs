using System;
using System.IO;

namespace LoggingKata

{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        private readonly ILog logger = new TacoLogger();
        private string DataPath { get; set; }
        public string[] DataLines { get; set; }

        public TacoParser(string datapath)
        {
            logger.LogInfo($"Reading data from file at {datapath}");
            this.DataPath = datapath;
            this.DataLines = File.ReadAllLines(DataPath);
        }

        public static ITrackable ParseLine(string[] line)
        {
            TacoLogger log = new TacoLogger();
            if( line.Length < 3 )
            {
                log.LogError("TacoBell.ParseLine requires a single string or string array with at least 3 indices.");
                return null;
            }
            if( line.Length > 3 )
            { log.LogWarning("TacoBell.ParseLine has detected more than 3 indices."); }

            if( Double.TryParse(line[0], out double x) && (Double.TryParse(line[1], out double y)) )
            { return new TacoBell(line[2], new Point(x, y)); }
            else
            {
                log.LogError($"Invalid input for parsing to double on {line[0]} or {line[1]}");

                try
                {
                    var rx = new System.Text.RegularExpressions.Regex(@"[^\d\.]");

                    double line0 = double.Parse(rx.Replace(line[0], ""));
                    double line1 = double.Parse(rx.Replace(line[1], ""));

                    return new TacoBell(line[2], new Point(line0, line1));
                }
                catch( Exception e )
                { log.LogError("Unable to clean data", e); }
                return null;
            }
        }

        public static ITrackable ParseLine(string line)
        {
            return TacoParser.ParseLine(line.Split(','));
        }
    }
}