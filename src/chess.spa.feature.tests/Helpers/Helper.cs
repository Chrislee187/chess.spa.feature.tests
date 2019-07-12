using System;

namespace chess.spa.feature.tests.Helpers
{
    public static class Helper
    {
        public static string ColourTextToSerialisedTurnIndicator(this string colourText)
        {
            if (colourText.ToLower() == "white") return "W";
            if (colourText.ToLower() == "black") return "B";

            throw new ArgumentException($"Invalid colour text '{colourText}'");
        }
    }
}