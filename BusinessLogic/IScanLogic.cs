using Prodigi.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace Prodigi.BusinessLogic
{
    public interface IScanLogic
    {
        public Colour GetImageColour(Bitmap image);
       
    }
}
