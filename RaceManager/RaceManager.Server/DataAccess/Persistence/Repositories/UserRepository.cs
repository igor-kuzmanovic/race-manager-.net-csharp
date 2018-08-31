using RaceManager.Server.DataAccess.Core.DataAccessObjects;
using RaceManager.Server.DataAccess.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaceManager.Server.DataAccess.Persistence.Repositories
{
    class UserRepository : Repository<UserDAO>, IUserRepository
    {
        public UserRepository(RaceManagerDbContext context) : base(context) { }
    }
}