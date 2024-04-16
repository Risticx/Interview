using Domain.Entities;

namespace Domain.Repositories
{
    public interface IUserRepository 
    {
        public User getById(string id);

        public bool userExistsByEmail(string email);
        
        public void save(User u);
    }
}