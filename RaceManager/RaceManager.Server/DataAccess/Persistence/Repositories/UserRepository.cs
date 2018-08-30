﻿using RaceManager.Server.DataAccess.Core.Domain;
using RaceManager.Server.DataAccess.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaceManager.Server.DataAccess.Persistence.Repositories
{
    class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(RaceManagerContext context) : base(context) { }
    }
}