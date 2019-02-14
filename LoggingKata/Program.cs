﻿using System;
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
            var frmtlines = lines.Select(x => x.Replace("/", "").Split("...")[0].Split(','));
            
            var parser = new TacoParser();
            
            
            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops
        }
    }
}