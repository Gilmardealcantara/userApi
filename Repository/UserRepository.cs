using System.Collections.Generic;
using UsersAPI.Models;

namespace UsersAPI.Repository
{
  public class UserRepository : IUserRepository
  {
    private readonly UserDbContext _context;

    public UserRepository(UserDbContext ctx)
    {
      _context = ctx;
    }
    public void Add(User user)
    {
      _context.Users.Add(user);
      _context.SaveChanges();
    }

    public User Find(long id)
    {
      return _context.Users.Find(id);
    }

    public IEnumerable<User> GetAll()
    {
      return _context.Users;
    }

    public void remove(long id)
    {
      var entity = _context.Users.Find(id);
      _context.Users.Remove(entity);
      _context.SaveChanges();
    }

    public void Update(User user)
    {
      _context.Users.Update(user);
      _context.SaveChanges();
    }
  }
}