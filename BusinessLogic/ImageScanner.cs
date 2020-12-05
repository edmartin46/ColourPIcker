using Microsoft.AspNetCore.Mvc;
using Prodigi.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace Prodigi.BusinessLogic
{
    /// <summary>
    /// Responible for opening the image and scanning
    /// THe scan logic is injected so that potentially different types of logic can be applied 
    /// to different types of image.
    /// </summary>
    public class ImageScanner: IImageScanner
    {
        private readonly IScanLogic _scanLogic;
        public ImageScanner(IScanLogic scanLogic)
        {
            _scanLogic = scanLogic;
        }
        public async Task<Colour> ScanImage(Uri address)
        {       
            
            using (WebClient client = new WebClient())
            {
                using (var stream = await client.OpenReadTaskAsync(address))
                {
                    var bitmap = new Bitmap(stream);
                    return _scanLogic.GetImageColour(bitmap);
                }                
            }                    
        }
        
    }
}
