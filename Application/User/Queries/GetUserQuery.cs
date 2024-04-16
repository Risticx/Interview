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

        public Domain.Entities.User getById(string id)
        {
            return UserRepository.getById(id);
        }
    }
}