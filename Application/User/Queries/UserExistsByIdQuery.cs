using Domain.Repositories;

namespace Application.User.Queries
{
    public class UserExistsByIdQuery
    {
        IUserRepository UserRepository;

        public UserExistsByIdQuery(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }
        public bool UserExistsById(string id)
        {
            return UserRepository.userExistsById(id);
        }
    }
}