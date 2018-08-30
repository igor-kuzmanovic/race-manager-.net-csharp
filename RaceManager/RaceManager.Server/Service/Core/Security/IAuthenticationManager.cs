using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceManager.Server.Service.Core.Security
{
    interface IAuthenticationManager
    {
        bool Authenticate(string username, string password);
    }
}
