using RaceManager.Server.DataAccess.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceManager.Server.Service.Core.Security
{
    interface IAuthorizationManager
    {
        bool Authorize(IUnitOfWork uow, string securityToken);
    }
}
