using System.Collections.Generic;
using UsersAPI.Models;

namespace UsersAPI.Repository
{
    public interface IUserRepository
    {
         void Add(User user);
         IEnumerable<User> GetAll();
         User Find(long id);
         void remove(long id);
         void Update(User user);

    }
}