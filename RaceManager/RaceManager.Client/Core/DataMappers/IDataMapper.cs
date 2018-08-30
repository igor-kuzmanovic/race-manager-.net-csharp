using RaceManager.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceManager.Client.Core.DataMappers
{
    interface IDataMapper<TModel, TDataTransferObject> where TModel : ObservableObject where TDataTransferObject : class
    {
        TModel Map(TDataTransferObject dto);

        TDataTransferObject Map(TModel model);

        IEnumerable<TModel> Map(IEnumerable<TDataTransferObject> dtos);

        IEnumerable<TDataTransferObject> Map(IEnumerable<TModel> models);
    }
}
