﻿using RaceManager.Server.DataAccess.Core.Domain;
using RaceManager.Server.Service.Core.DataTransferObjects;

namespace RaceManager.Server.Service.Core.DataMappers
{
    interface ILoginMapper : IDataMapper<User, LoginDTO>
    {
    }
}