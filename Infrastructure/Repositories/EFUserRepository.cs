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

        public bool userExistsByEmail(string email)
        {
            return Context.Users.Any(p => p.Email == email);
        }

        public bool userExistsById(string id) 
        {
            return Context.Users.Any(p => p.Id == id);
        }

        public void addTransaction(User u, Transaction t)
        {
            if(u != null) {
                u.UserTransactions ??= new List<Transaction>();
                u.UserTransactions.Add(t);
                Context.SaveChanges();
            }
        }

        public void save(User u)
        {
            Context.Users.Add(u);
            Context.SaveChanges();
        }

        
    }
}