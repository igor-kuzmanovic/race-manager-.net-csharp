using RaceManager.Server.DataAccess.Core.DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceManager.Server.Service.Core.DataMappers
{
    interface IDataMapper<TDataAccessObject, TDataTransferObject> where TDataAccessObject : DataAccessObject where TDataTransferObject : class
    {
        TDataAccessObject Map(TDataTransferObject dto);

        TDataTransferObject Map(TDataAccessObject dao);

        IEnumerable<TDataAccessObject> Map(IEnumerable<TDataTransferObject> dtos);

        IEnumerable<TDataTransferObject> Map(IEnumerable<TDataAccessObject> daos);
    }
}
