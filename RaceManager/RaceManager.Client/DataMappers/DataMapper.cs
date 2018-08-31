using RaceManager.Client.Core;
using RaceManager.Client.Core.DataMappers;
using System.Collections.Generic;
using System.Linq;

namespace RaceManager.Client.DataMappers
{
    abstract class DataMapper<TModel, TDataTransferObject> : IDataMapper<TModel, TDataTransferObject> where TModel : ObservableObject where TDataTransferObject : class
    {
        public abstract TModel Map(TDataTransferObject dto);

        public abstract TDataTransferObject Map(TModel model);

        public virtual IEnumerable<TModel> Map(IEnumerable<TDataTransferObject> dtos)
        {
            var models = new List<TModel>(dtos.Count());

            foreach (var dto in dtos)
            {
                var model = Map(dto);
                models.Add(model);
            }

            return models;
        }

        public virtual IEnumerable<TDataTransferObject> Map(IEnumerable<TModel> models)
        {
            var dtos = new List<TDataTransferObject>(models.Count());

            foreach (var model in models)
            {
                var dto = Map(model);
                dtos.Add(dto);
            }

            return dtos;
        }
    }
}