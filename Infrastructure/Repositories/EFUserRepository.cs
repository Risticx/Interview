using Domain.Entities;
using Domain.Exceptions;
using Domain.Repositories;

namespace Infrastructure.Repositories
{
    public class EFUserRepository : IUserRepository
    {
        private DataContext Context;

        public EFUserRepository(DataContext context) 
        {
            Context = context;
        }
        public User getById(string id)
        {
            return Context.Users.Where(p => p.Id == id).FirstOrDefault() ?? throw new UserNotFoundException();
        }

        public void save(User u)
        {
            Context.Users.Add(u);
            Context.SaveChanges();
        }
    }
}