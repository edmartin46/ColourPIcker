using Prodigi.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;

using System.Linq;
using System.Threading.Tasks;

namespace Prodigi.BusinessLogic
{
    public class ScanLogic: IScanLogic
    {
        public Colour GetImageColour(Bitmap image)
        {
            //This class samples 100 pixels at random and takes the most common colour
            //This could be speeded up of we presupplied a coordinate that guaranteed the 
            //colour to use, then only one sample required.
            //Sample size should really come from appsettings.json.
            Random random = new Random();
            List<Colour> samples = new List<Colour>();

            for (int i = 0; i < 100; i++)
            {
                Color c = image.GetPixel(random.Next(1, image.Width), random.Next(1, image.Height));
                samples.Add(new Colour { Red = c.R, Green = c.G, Blue = c.B });
            }
            //Now return the most popular colour.
            return  (from s in samples
                                    group s by new { s.Red, s.Green, s.Blue } into gj
                                    select new Colour
                                    {
                                        Red = gj.Key.Red,
                                        Green = gj.Key.Green,
                                        Blue = gj.Key.Blue,
                                        Count = gj.Count()
                                    }).OrderByDescending(s => s.Count).First();
            
                                   

        }
    }
}
