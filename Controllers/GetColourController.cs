using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Prodigi.BusinessLogic;
using Prodigi.Classes;

namespace Prodigi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetColourController : ControllerBase
    {
       
        private readonly ILogger<GetColourController> _logger;
        private readonly IImageScanner _imageScanner;
        private readonly IUrlChecker _urlChecker;
        private readonly IConfiguration _configuration;
        private readonly IColourMatcher _colourMatcher;
        public GetColourController(ILogger<GetColourController> logger, IImageScanner imageScanner, IUrlChecker urlChecker, IScanLogic scanLogic, IColourMatcher colourMatcher)
        {
            _logger = logger;
            _imageScanner = imageScanner;
            _urlChecker = urlChecker;
            _colourMatcher = colourMatcher;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string imageUrl)
        {
            var errorMessage = String.Empty;
            Colour imageColour;
            Colour matchedColour;

            //Check that the url is valid. Should always sanitise input.
            if (!_urlChecker.ValidateUrl(imageUrl, out errorMessage))
            {               
                return StatusCode(500, errorMessage);
            }

            //open the image and use scanlogic class to determie the colour of the image.
            //scan logic samples 100 pixels at random and gets the most common colour.
            try
            {
                imageColour = await _imageScanner.ScanImage(_urlChecker.GetUri(imageUrl));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);
                return StatusCode(500, "Error reading url");
            }

            //now match the colour to our predefined palette that is loaded from appsettings.
            //we use a tolerance setting to pick up near matches in the palette.
            //e.g. tolerance of 5 means that the image has to be + or - 5 on the RGB values in the palette.
            //Tolerance is held in appsettings.json

            matchedColour = _colourMatcher.MatchColour(imageColour);
            if (matchedColour == null)
            {
                return StatusCode(500, "No match found");
            }

            return Ok(matchedColour.Key);
        }
    }
}
