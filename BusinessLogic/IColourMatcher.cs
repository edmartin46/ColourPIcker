using Prodigi.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodigi.BusinessLogic
{
    public interface IColourMatcher
    {
        public Colour MatchColour(Colour imageColour);
    }
}
