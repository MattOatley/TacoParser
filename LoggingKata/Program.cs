﻿using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;
using System.Data.Common;
using System.Threading;

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

            logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();

            var locations = lines.Select(parser.Parse).ToArray();

            // These are the variables that store the two taco bells furthest from each other
            ITrackable locA = null;
            ITrackable locB = null;
            ITrackable p1 = null;
            ITrackable p2 = null;
            
            // These variables store the distance of the taco bells
            double distance = 0;
            double maxDistance = 0;

            for (int i = 0; i < locations.Length; i++) // loop for first location
            {
                locA = locations[i];
                GeoCoordinate CordA = new GeoCoordinate(); //created a new instance of the geo coordinate class for first location
                CordA.Latitude = locA.Location.Latitude; 
                CordA.Longitude = locA.Location.Longitude;
                for (int j = i; j < locations.Length; j++) // loop for second location
                {
                    locB = locations[j];
                    GeoCoordinate CordB = new GeoCoordinate(); //created a new instance of the geo coordinate class for second location
                    CordB.Latitude = locB.Location.Latitude;
                    CordB.Longitude = locB.Location.Longitude;
                    distance = CordA.GetDistanceTo(CordB); //compares the distance between the two coordinates using the method 'GetDistanceTo'
                    if(distance > maxDistance) //if statement that updates distance and 'ITrackable' variables set above, if given distance is greater than saved distance
                    {
                        p1 = locA;
                        p2 = locB;
                        maxDistance = distance;
                    }
                }
            }
            logger.LogInfo("Determining furthest distance between Taco Bells!");
            Thread.Sleep(500);
            double inMiles = 0.000621371 * maxDistance; //formula to convert meters to miles
            logger.LogInfo("Converting distance to miles......");
            Thread.Sleep(1000);
            logger.LogInfo($"Location A - {p1.Name} and Location B - {p2.Name} have a distance of {inMiles} miles between them."); // prints to the console the name of location A, B and the distance between them

            // TODO:  Find the two Taco Bells in Alabama that are the furthest from one another.
            // HINT:  You'll need two nested forloops
        }

       

        // DON'T FORGET TO LOG YOUR STEPS
        // Grab the path from the name of your file

        // use File.ReadAllLines(path) to grab all the lines from your csv file DONE
        // Log and error if you get 0 lines and a warning if you get 1 line

        // Create a new instance of your TacoParser class DONE
        // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);

        // Now, here's the new code

        // Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the furthest from each other.
        // Create a `double` variable to store the distance

        // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`
        // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
        // Create a new corA Coordinate with your locA's lat and long

        // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)
        // Create a new Coordinate with your locB's lat and long
        // Now, compare the two using `.GetDistanceTo()`, which returns a double
        // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above

        // Once you've looped through everything, you've found the two Taco Bells furthest away from each other.
    }
}