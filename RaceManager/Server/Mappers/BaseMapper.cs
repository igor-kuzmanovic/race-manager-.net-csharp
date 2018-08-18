using System.Collections.Generic;
using System.Linq;

namespace Server
{
    abstract class BaseMapper<TEntity, TDataTransferObject>
    {
        public abstract TEntity Map(TDataTransferObject dto);
        public abstract TDataTransferObject Map(TEntity entity);

        public virtual IEnumerable<TEntity> Map(IEnumerable<TDataTransferObject> dtos)
        {
            var entities = new List<TEntity>(dtos.Count());

            foreach (var dto in dtos)
            {
                var entity = Map(dto);
                entities.Add(entity);
            }

            return entities;
        }

        public virtual IEnumerable<TDataTransferObject> Map(IEnumerable<TEntity> entities)
        {
            var dtos = new List<TDataTransferObject>(entities.Count());

            foreach (var entity in entities)
            {
                var dto = Map(entity);
                dtos.Add(dto);
            }

            return dtos;
        }
    }
}
