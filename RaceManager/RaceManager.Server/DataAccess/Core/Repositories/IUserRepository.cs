using RaceManager.Server.DataAccess.Core.DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceManager.Server.DataAccess.Core.Repositories
{
    interface IUserRepository : IRepository<UserDAO>
    {
    }
}
