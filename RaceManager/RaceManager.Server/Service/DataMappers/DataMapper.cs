using RaceManager.Server.DataAccess.Core.DataAccessObjects;
using RaceManager.Server.Service.Core.DataMappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaceManager.Server.Service.DataMappers
{
    abstract class DataMapper<TDataAccessObject, TDataTransferObject> : IDataMapper<TDataAccessObject, TDataTransferObject> where TDataAccessObject : DataAccessObject where TDataTransferObject : class
    {
        public abstract TDataAccessObject Map(TDataTransferObject dto);

        public abstract TDataTransferObject Map(TDataAccessObject dao);

        public virtual IEnumerable<TDataAccessObject> Map(IEnumerable<TDataTransferObject> dtos)
        {
            var daos = new List<TDataAccessObject>(dtos.Count());

            foreach (var dto in dtos)
            {
                var dao = Map(dto);
                daos.Add(dao);
            }

            return daos;
        }

        public virtual IEnumerable<TDataTransferObject> Map(IEnumerable<TDataAccessObject> daos)
        {
            var dtos = new List<TDataTransferObject>(daos.Count());

            foreach (var dao in daos)
            {
                var dto = Map(dao);
                dtos.Add(dto);
            }

            return dtos;
        }
    }
}