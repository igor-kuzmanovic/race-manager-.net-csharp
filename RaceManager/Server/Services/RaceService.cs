using System.Collections.Generic;
using Service;

namespace Server
{
    class RaceService : BaseCRUDService<RaceDTO, Race>, IRaceService
    {
        public override IEnumerable<RaceDTO> GetAll(string securityToken)
        {
            if (string.IsNullOrWhiteSpace(securityToken))
                return new List<RaceDTO>();

            var races = RaceDBManager.Instance.GetAll(r => true);
            var raceDTOs = RaceMapper.Instance.Map(races);

            return raceDTOs;
        }

        public override RaceDTO Get(string securityToken, int id)
        {
            if (string.IsNullOrWhiteSpace(securityToken))
                return new RaceDTO();

            var race = RaceDBManager.Instance.Get(r => r.Id == id);
            var raceDTO = RaceMapper.Instance.Map(race);

            return raceDTO;
        }

        public override int Insert(string securityToken, RaceDTO raceDTO)
        {
            if (string.IsNullOrWhiteSpace(securityToken))
                return 0;

            var race = RaceMapper.Instance.Map(raceDTO);
            var id = RaceDBManager.Instance.Insert(race);

            return id;
        }

        public override bool Update(string securityToken, RaceDTO raceDTO)
        {
            if (string.IsNullOrWhiteSpace(securityToken))
                return false;

            var race = RaceMapper.Instance.Map(raceDTO);
            var result = RaceDBManager.Instance.Update(race);

            return result;
        }

        public override bool Delete(string securityToken, int id)
        {
            if (string.IsNullOrWhiteSpace(securityToken))
                return false;

            var result = RaceDBManager.Instance.Delete(id);

            return result;
        }
    }
}
