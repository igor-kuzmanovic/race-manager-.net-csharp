using RaceManagerServer.DataAccess.Persistence;
using RaceManagerServer.Service.Converters;
using RaceManagerServer.Service.Core.DataTransferObjects;
using RaceManagerServer.Service.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RaceManagerServer.Service.Services
{
    public class RaceService : IRaceService
    {
        public RaceDTO Get(int id)
        {
            using (var uow = new UnitOfWork(new RaceManagerContext()))
            {
                return RaceConverter.Instance.Convert(uow.Races.Get(id));
            }
        }

        public IEnumerable<RaceDTO> GetAll()
        {
            using (var uow = new UnitOfWork(new RaceManagerContext()))
            {
                return RaceConverter.Instance.Convert(uow.Races.GetAll());
            }
        }

        public void Update(RaceDTO raceDTO)
        {
            using (var uow = new UnitOfWork(new RaceManagerContext()))
            {
                var race = uow.Races.Get(raceDTO.Id);
                race.EventDate = raceDTO.EventDate;
                race.EventLocation = raceDTO.EventLocation;
                uow.Complete();
            }
        }

        public void Add(RaceDTO raceDTO)
        {
            using (var uow = new UnitOfWork(new RaceManagerContext()))
            {
                uow.Races.Add(RaceConverter.Instance.Convert(raceDTO));
                uow.Complete();
            }
        }

        public void Remove(int id)
        {
            using (var uow = new UnitOfWork(new RaceManagerContext()))
            {
                uow.Races.Remove(id);
                uow.Complete();
            }
        }
    }
}
