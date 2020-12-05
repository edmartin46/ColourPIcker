using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prodigi.BusinessLogic
{
    public interface IUrlChecker
    {
        public bool ValidateUrl(string imageUrl, out string errorMessage);
        public Uri GetUri(string imageUrl);
    }
}
