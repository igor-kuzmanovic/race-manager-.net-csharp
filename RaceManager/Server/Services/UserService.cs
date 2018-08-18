using Service;

namespace Server
{
    class UserService : BaseCRUDService<UserDTO, User>, IUserService
    {
    }
}
