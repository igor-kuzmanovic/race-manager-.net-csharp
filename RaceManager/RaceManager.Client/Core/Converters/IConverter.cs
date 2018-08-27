using RaceManager.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceManager.Client.Core.Converters
{
    interface IConverter<TModel, TDataTransferObject> where TModel : ObservableObject where TDataTransferObject : class
    {
        TModel Convert(TDataTransferObject dto);

        TDataTransferObject Convert(TModel model);

        IEnumerable<TModel> Convert(IEnumerable<TDataTransferObject> dtos);

        IEnumerable<TDataTransferObject> Convert(IEnumerable<TModel> models);
    }
}
