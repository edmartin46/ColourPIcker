using Microsoft.Extensions.Configuration;
using Prodigi.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodigi.BusinessLogic
{
    public class ColourMatcher: IColourMatcher
    {
        List<Colour> _colourPalette;
        int _tolerance = 0;
        public ColourMatcher(IConfiguration configuration)
        {           
            _colourPalette = configuration.GetSection("ColourPalette").Get<List<Colour>>();
            _tolerance = configuration.GetSection("Tolerance").Get<int>();

        }
        public Colour MatchColour(Colour imageColour)
        {
            return _colourPalette.FirstOrDefault(x =>
                 imageColour.Red <= x.Red + _tolerance
                 && imageColour.Red >= x.Red - _tolerance
                 && imageColour.Green <= x.Green + _tolerance
                 && imageColour.Green >= x.Green - _tolerance
                 && imageColour.Blue <= x.Blue + _tolerance
                 && imageColour.Blue >= x.Blue - _tolerance
                 );
            
        }
    }
}
