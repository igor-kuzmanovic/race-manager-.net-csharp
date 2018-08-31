using RaceManager.Server.DataAccess.Persistence;
using RaceManager.Server.Service.DataMappers;
using RaceManager.Server.Service.Core.DataTransferObjects;
using RaceManager.Server.Service.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.ServiceModel;
using System.Text;
using RaceManager.Server.Service.Security;
using RaceManager.Server.DataAccess.Core.DataAccessObjects;

namespace RaceManager.Server.Service.Services
{
    public class RaceService : IRaceService
    {
        public RaceDTO Get(string token, int id)
        {
            using (var uow = new UnitOfWork(new RaceManagerDbContext()))
            {
                if (!AuthorizationManager.Instance.Authorize(uow, token))
                    return new RaceDTO();

                return RaceMapper.Instance.Map(uow.Races.Get(id));
            }
        }

        public IEnumerable<RaceDTO> GetAll(string token)
        {
            using (var uow = new UnitOfWork(new RaceManagerDbContext()))
            {
                if (!AuthorizationManager.Instance.Authorize(uow, token))
                    return new List<RaceDTO>();

                return RaceMapper.Instance.Map(uow.Races.GetAll());
            }
        }

        public bool Update(string token, RaceDTO raceDTO)
        {
            using (var uow = new UnitOfWork(new RaceManagerDbContext()))
            {
                if (!AuthorizationManager.Instance.Authorize(uow, token))
                    return false;

                var race = uow.Races.Get(raceDTO.Id);

                if (race == null)
                    return false;

                race.EventDate = raceDTO.EventDate;
                race.EventLocation = raceDTO.EventLocation;
                race.RaceDrivers = new List<RaceDriverDAO>(raceDTO.DriverIds.Select(id => new RaceDriverDAO() { RaceId = race.Id, DriverId = id }));

                if (!uow.Complete())
                    return false;

                return true;
            }
        }

        public bool Add(string token, RaceDTO raceDTO)
        {
            using (var uow = new UnitOfWork(new RaceManagerDbContext()))
            {
                if (!AuthorizationManager.Instance.Authorize(uow, token))
                    return false;

                uow.Races.Add(RaceMapper.Instance.Map(raceDTO));

                if (!uow.Complete())
                    return false;

                return true;
            }
        }

        public bool Remove(string token, int id)
        {
            using (var uow = new UnitOfWork(new RaceManagerDbContext()))
            {
                if (!AuthorizationManager.Instance.Authorize(uow, token))
                    return false;

                var race = uow.Races.Get(id);

                if (race == null)
                    return false;

                uow.Races.Remove(race);

                if (!uow.Complete())
                    return false;

                return true;
            }
        }
    }
}
