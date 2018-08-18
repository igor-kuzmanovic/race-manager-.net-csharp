using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Service;

namespace Server
{
    class RaceService : BaseCRUDService<RaceDTO, Race>, IRaceService
    {
        public override IEnumerable<RaceDTO> GetAll(string securityToken)
        {
            if (string.IsNullOrWhiteSpace(securityToken))
                return new List<RaceDTO>();

            if (AuthorizationManager.Instance.Authorize(securityToken, false))
                return new List<RaceDTO>();

            var races = RaceDBManager.Instance.FindAll(r => true);
            var raceDTOs = RaceMapper.Instance.Map(races);

            return raceDTOs;
        }

        public override RaceDTO Get(string securityToken, int id)
        {
            if (string.IsNullOrWhiteSpace(securityToken))
                return new RaceDTO();

            if (AuthorizationManager.Instance.Authorize(securityToken, false))
                return new RaceDTO();

            if (id <= 0)
                return new RaceDTO();

            var race = RaceDBManager.Instance.Find(r => r.Id == id);
            var raceDTO = RaceMapper.Instance.Map(race);

            return raceDTO;
        }

        public override int Insert(string securityToken, RaceDTO raceDTO)
        {
            if (string.IsNullOrWhiteSpace(securityToken))
                return 0;

            if (AuthorizationManager.Instance.Authorize(securityToken, false))
                return 0;

            if (raceDTO == null)
                return 0;

            var race = RaceMapper.Instance.Map(raceDTO);
            var id = RaceDBManager.Instance.Insert(race);

            return id;
        }

        public override bool Update(string securityToken, RaceDTO raceDTO)
        {
            if (string.IsNullOrWhiteSpace(securityToken))
                return false;

            if (AuthorizationManager.Instance.Authorize(securityToken, false))
                return false;

            if (raceDTO == null)
                return false;

            var race = RaceMapper.Instance.Map(raceDTO);
            var result = RaceDBManager.Instance.Update(race);

            return result;
        }

        public override bool Delete(string securityToken, int id)
        {
            if (string.IsNullOrWhiteSpace(securityToken))
                return false;

            if (AuthorizationManager.Instance.Authorize(securityToken, false))
                return false;

            if (id <= 0)
                return false;

            var result = RaceDBManager.Instance.Delete(id);

            return result;
        }

        public IEnumerable<RaceDTO> FindByEventDate(string securityToken, DateTime eventDate, DateTimeQueryType queryType)
        {
            if (string.IsNullOrWhiteSpace(securityToken))
                return new List<RaceDTO>();

            if (AuthorizationManager.Instance.Authorize(securityToken, false))
                return new List<RaceDTO>();

            Expression<Func<Race, bool>> predicate;

            switch (queryType)
            {
                case DateTimeQueryType.Equals:
                    predicate = (r => r.EventDate.Date == eventDate.Date);
                    break;
                case DateTimeQueryType.Before:
                    predicate = (r => r.EventDate.Date < eventDate.Date);
                    break;
                case DateTimeQueryType.After:
                    predicate = (r => r.EventDate.Date > eventDate.Date);
                    break;
                default:
                    return GetAll(securityToken);
            }

            var races = RaceDBManager.Instance.FindAll(predicate);
            var raceDTOs = RaceMapper.Instance.Map(races);

            return raceDTOs;
        }

        public IEnumerable<RaceDTO> FindByEventLocation(string securityToken, string eventLocation)
        {
            if (string.IsNullOrWhiteSpace(securityToken))
                return new List<RaceDTO>();

            if (AuthorizationManager.Instance.Authorize(securityToken, false))
                return new List<RaceDTO>();

            if (string.IsNullOrWhiteSpace(eventLocation))
                return GetAll(securityToken);

            var races = RaceDBManager.Instance.FindAll(r => r.EventLocation.ToLower().Contains(eventLocation.ToLower()));
            var raceDTOs = RaceMapper.Instance.Map(races);

            return raceDTOs;
        }
    }
}
