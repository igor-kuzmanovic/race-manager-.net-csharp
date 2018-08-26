using RaceManager.Client.Core.Converters;
using RaceManager.Core;
using System.Collections.Generic;
using System.Linq;

namespace RaceManager.Client.Models.Converters
{
    abstract class Converter<TModel, TDataTransferObject> : IConverter<TModel, TDataTransferObject> where TModel : ObservableObject where TDataTransferObject : class
    {
        public abstract TModel Convert(TDataTransferObject dto);

        public abstract TDataTransferObject Convert(TModel model);

        public virtual IEnumerable<TModel> Convert(IEnumerable<TDataTransferObject> dtos)
        {
            var models = new List<TModel>(dtos.Count());

            foreach (var dto in dtos)
            {
                var model = Convert(dto);
                models.Add(model);
            }

            return models;
        }

        public virtual IEnumerable<TDataTransferObject> Convert(IEnumerable<TModel> models)
        {
            var dtos = new List<TDataTransferObject>(models.Count());

            foreach (var model in models)
            {
                var dto = Convert(model);
                dtos.Add(dto);
            }

            return dtos;
        }
    }
}