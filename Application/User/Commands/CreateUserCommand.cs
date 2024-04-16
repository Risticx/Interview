using Domain.Repositories;
using Domain.Exceptions;

namespace Application.User.Commands
{
    public class CreateUserCommand
    {
        private IUserRepository UserRepository;
        
        public CreateUserCommand(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public void Handle(string username, string name, string lastname, string email) 
        {
            if(UserRepository.userExistsByEmail(email))
                throw new UserExistsByEmailException();

            Domain.Entities.User u = new Domain.Entities.User(username, name, lastname, email);
            UserRepository.save(u);
        }
    }
}