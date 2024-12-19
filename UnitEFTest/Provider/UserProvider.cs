using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnitEFTest.Entities;

namespace UnitEFTest.Provider
{
    internal class UserProvider
    {
        private readonly AppDbContext _context;

        public UserProvider(AppDbContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Users.Update(user);

            _context.SaveChanges();
        }

        public void Delete(User user)
        {
            _context.Remove(user);
        }

        public User Get(int id)
        {
            return _context.Users.First(x => x.Id == id);
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }
    }
}
