using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace Prodigi.BusinessLogic
{
    public class UrlChecker : IUrlChecker
    {
        public bool ValidateUrl(string imageUrl, out string errorMessage)
        {
            //do validations here that the url is safe, eg could restrict to certain domains
            //or that it is https. Could also check for malicious characters.
            //For the purposes of this we just validate that it is not empty
            if (string.IsNullOrEmpty(imageUrl))
            {
                errorMessage = "Url not specified";
                return false;
            }
            errorMessage = "";
            return true;
        }
        public Uri GetUri (string imageUrl)
        {
            return new Uri(imageUrl);
        }
    }
}
