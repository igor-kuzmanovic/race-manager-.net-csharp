using RaceManager.Client.Models;
using RaceManager.Client.UserService;

namespace RaceManager.Client.Core.DataMappers
{
    interface IUserMapper : IDataMapper<User, UserDTO>
    {
    }
}