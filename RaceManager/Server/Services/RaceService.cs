using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Service;

namespace Server
{
    class RaceService : IRaceService
    {
        public IEnumerable<RaceDTO> GetAll(string securityToken)
        {
            if (string.IsNullOrWhiteSpace(securityToken))
                return null;

            throw new NotImplementedException();
        }

        public RaceDTO Get(string securityToken, int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(string securityToken, RaceDTO raceDTO)
        {
            throw new NotImplementedException();
        }

        public bool Update(string securityToken, RaceDTO raceDTO)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string securityToken, int id)
        {
            throw new NotImplementedException();
        }
    }
}
