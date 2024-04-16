using Domain.Entities;

namespace Domain.Repositories
{
    public interface IUserRepository 
    {
        public User getById(string id);
        public void save(User u);
    }
}