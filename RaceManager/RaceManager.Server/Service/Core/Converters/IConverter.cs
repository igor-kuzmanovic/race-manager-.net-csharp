using RaceManager.Server.DataAccess.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceManager.Server.Service.Core.Converters
{
    interface IConverter<TEntity, TDataTransferObject> where TEntity : Entity where TDataTransferObject : class
    {
        TEntity Convert(TDataTransferObject dto);

        TDataTransferObject Convert(TEntity entity);

        IEnumerable<TEntity> Convert(IEnumerable<TDataTransferObject> dtos);

        IEnumerable<TDataTransferObject> Convert(IEnumerable<TEntity> entities);
    }
}
