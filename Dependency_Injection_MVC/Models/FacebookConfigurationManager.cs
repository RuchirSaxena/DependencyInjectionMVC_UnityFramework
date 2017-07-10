using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dependency_Injection_MVC.Models
{
    public class FacebookConfigurationManager : IFaceBookConfigurationManager
    {
        private string _username;
        private string _authenticationToken;
        private string _facebookUrl;
        public FacebookConfigurationManager(string username, string authenticationToken, string facebookUrl)
        {
            _username = username;
            _authenticationToken = authenticationToken;
            _facebookUrl = facebookUrl;
        }
        public bool Authenticate()
        {
            if (!string.IsNullOrEmpty(_username)
                 && !string.IsNullOrEmpty(_authenticationToken)
                  && !string.IsNullOrEmpty(_facebookUrl)
                 )
            {
                return true;
            }
            return false;
        }
    }
}