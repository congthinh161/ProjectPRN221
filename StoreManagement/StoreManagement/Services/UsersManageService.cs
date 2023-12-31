﻿using StoreManagement.IService;
using StoreManagement.Models;
using System.Net.NetworkInformation;

namespace StoreManagement.Services
{
    public class UsersManageService : IUsersManageServices
    {
        private readonly WebContext _context;
        private readonly IConfiguration _config;
        public int paging { get; set; }
        public UsersManageService(WebContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
            paging  = Convert.ToInt32(_config.GetSection("PageSettings")["Paging"]);
        }

        public User Login(string user, string pass)
        {
            return _context.Users.Where(x => x.Username.Equals(user) && x.Password.Equals(pass)).FirstOrDefault();
        }

        public int Register(User user)
        {
            User check = CheckExist(user.Username);
            if (check == null)
            {
                user.Role = "us";
                _context.Users.Add(user);
                _context.SaveChanges();
                return 0;
            }
            else return 1;
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public int CountUser(string uname)
        {
            return _context.Users.Where(x => x.Username.Contains(uname)).ToList().Count;
        }

        public List<User> GetUserPaging(int take, string uname)
        {
            return _context.Users.Where(x => x.Username.Contains(uname)).Skip(take * paging).Take(paging).ToList();
        }

        public User GetUserData(string userName)
        {
            return _context.Users.Where(x => x.Username.Equals(userName)).FirstOrDefault();
        }

        public int UpdateRole(User user)
        {
            try
            {
                User check = CheckExist(user.Username);
                if (check != null)
                {
                    check.Role = user.Role;
                    _context.SaveChanges();
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            catch (Exception)
            {
                return 1;
            }
        }

        public User CheckExist(string username)
        {
            return _context.Users.Where(x => x.Username.Equals(username)).FirstOrDefault();
        }

        public User GetUserByOId(int oid)
        {
            Order order = _context.Orders.FirstOrDefault(x => x.Id == oid);
            return _context.Users.FirstOrDefault(x => x.Username.Equals(order.Uname));
        }
        public int UpdateProfile(User user)
        {
            User check = CheckExist(user.Username);
            if (check != null)
            {
                check.Firstname = user.Firstname;
                check.Lastname = user.Lastname;
                check.Birthday = user.Birthday;
                check.Email = user.Email;
                check.Phone = user.Phone;
                check.Address = user.Address;
                _context.SaveChanges();
                return 0;
            }
            else return 1;
        }
    }
}
