using RaceManagerServer.DataAccess.Core.Domain;
using RaceManagerServer.Service.Core.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RaceManagerServer.Service.Converters
{
    abstract class Converter<TEntity, TDataTransferObject> : IConverter<TEntity, TDataTransferObject> where TEntity : Entity where TDataTransferObject : class
    {
        public abstract TEntity Convert(TDataTransferObject dto);

        public abstract TDataTransferObject Convert(TEntity entity);

        public virtual IEnumerable<TEntity> Convert(IEnumerable<TDataTransferObject> dtos)
        {
            var entities = new List<TEntity>(dtos.Count());

            foreach (var dto in dtos)
            {
                var entity = Convert(dto);
                entities.Add(entity);
            }

            return entities;
        }

        public virtual IEnumerable<TDataTransferObject> Convert(IEnumerable<TEntity> entities)
        {
            var dtos = new List<TDataTransferObject>(entities.Count());

            foreach (var entity in entities)
            {
                var dto = Convert(entity);
                dtos.Add(dto);
            }

            return dtos;
        }
    }
}