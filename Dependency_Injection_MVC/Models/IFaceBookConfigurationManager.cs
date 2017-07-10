using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Injection_MVC.Models
{
    public interface IFaceBookConfigurationManager
    {
        bool Authenticate();
    }
}
