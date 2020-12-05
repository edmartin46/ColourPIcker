using Prodigi.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodigi.BusinessLogic
{
    public interface IImageScanner
    {
        public Task<Colour> ScanImage(Uri imageUri);
        
    }
}
