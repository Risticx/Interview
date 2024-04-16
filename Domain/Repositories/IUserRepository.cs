using Domain.Entities;

namespace Domain.Repositories
{
    public interface IUserRepository 
    {
        public User getById(string id);

        public bool userExistsByEmail(string email);

        public bool userExistsById(string id);

        public void addTransaction(User u, Transaction t);
        
        public void save(User u);
    }
}