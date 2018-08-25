using RaceManager.Client.Models;
using RaceManager.Client.RaceService;

namespace RaceManager.Client.Core.Converters
{
    interface IRaceConverter : IConverter<Race, RaceDTO>
    {
    }
}