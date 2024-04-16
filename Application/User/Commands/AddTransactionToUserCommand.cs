using Domain.Repositories;
using Domain.Exceptions;

namespace Application.User.Commands
{
    public class AddTransactionToUserCommand
    {
        private IUserRepository UserRepository;
        
        public AddTransactionToUserCommand(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }
        public void AddTransactionToUser(Domain.Entities.User user, Domain.Entities.Transaction t) 
        {
            if(!UserRepository.userExistsById(user.Id!))
                throw new UserNotFoundException();

            UserRepository.addTransaction(user, t);
        }
    }
}