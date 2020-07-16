using System;
namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");
            var cells = line.Split(','); // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3 || cells == null)
            {
                logger.LogError("Parse Method Failed");
                return null;// Log that and return null
            }
            // Do not fail if one record parsing fails, return null
            // TODO Implement


            double latitude = double.Parse(cells[0]);
            double longitude = double.Parse(cells[1]);
            var name = cells[2];
            //return null;

            TacoBell taco = new TacoBell();


            taco.Name = name;
            taco.Location = new Point(latitude, longitude);

            return taco;



           

            
        }












        // Your going to need to parse your string as a `double`
        // which is similar to parsing a string as an `int`

        // You'll need to create a TacoBell class
        // that conforms to ITrackable

        // Then, you'll need an instance of the TacoBell class
        // With the name and point set correctly

        // Then, return the instance of your TacoBell class
        // Since it conforms to ITrackable
    }
}