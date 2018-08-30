using RaceManager.Server.DataAccess.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceManager.Server.Service.Core.DataMappers
{
    interface IDataMapper<TEntity, TDataTransferObject> where TEntity : Entity where TDataTransferObject : class
    {
        TEntity Map(TDataTransferObject dto);

        TDataTransferObject Map(TEntity entity);

        IEnumerable<TEntity> Map(IEnumerable<TDataTransferObject> dtos);

        IEnumerable<TDataTransferObject> Map(IEnumerable<TEntity> entities);
    }
}
