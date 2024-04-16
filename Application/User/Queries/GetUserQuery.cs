using Domain.Repositories;

namespace Application.User.Queries
{
    public class GetUserQuery
    {
        private IUserRepository UserRepository;

        public GetUserQuery(IUserRepository userRepository) 
        {
            UserRepository = userRepository;
        }
        public Domain.Entities.User GetById(string id)
        {
            return UserRepository.getById(id);
        }
    }
}