﻿using DAL.Entities;
using DAL.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserService
    {

        private readonly UserProvider _userP;

        public UserService()
        {
            var context = new AppDbContext();
            _userP = new UserProvider(context);
        }

        public void AddUser(User user)
        {
            _userP.Add(user);
        }

        public void UpdateUser(User user)
        {
            _userP.Update(user);
        }

        public void DeleteUser(User user)
        {
            _userP.Delete(user);
        }

        public User GetUser(int id)
        {
            return _userP.Get(id);
        }

        public List<User> GetAllUsers()
        {
            return _userP.GetAll(); 
        }

    }
}
