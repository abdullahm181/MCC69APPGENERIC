using API.Context;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace API.Repositories.Data
{
    public class UserRepository : Repository<User, MyContext>
    {
        MyContext myContext;
        public UserRepository(MyContext myContext) : base(myContext)
        {
            this.myContext = myContext;
        }
        public User Login(string username, string password)
        {
            var user = myContext.User.SingleOrDefault(x => x.UserName == username);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            /*if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;*/
            if (user.Password != password)
                return null;

            // authentication successful
            return user;
        }
        public int Create(User user)
        {
            if (myContext.User.Any(x => x.UserName == user.UserName))
                return -2;

            /*byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;*/

            
            var result = Post(user);

            return result;
        }
        public int ChangePassword(User userParam) {
            var user = myContext.User.SingleOrDefault(x => x.UserName == userParam.UserName);
            if (user == null)
                return -1;
            if (!string.IsNullOrWhiteSpace(userParam.Password) && userParam.Password != user.Password)
            {
                user.Password = userParam.Password;
            }
            var result = myContext.SaveChanges();
            return result;
        }
        public int Update(User userParam)
        {
            var user = Get(userParam.Id);

            if (user == null)
                return -1;


            if (!string.IsNullOrWhiteSpace(userParam.UserName) && userParam.UserName != user.UserName)
            {

                if (myContext.User.Any(x => x.UserName == userParam.UserName))
                    return -2;

                user.UserName = userParam.UserName;
            }

            

            if (!string.IsNullOrWhiteSpace(userParam.Password) && userParam.Password != user.Password)
            {
                user.Password = userParam.Password;
            }
            var result = myContext.SaveChanges();
            return result;
        }
        public int ForgotPassword(User userParam)
        {
            var user = myContext.User.SingleOrDefault(x => x.UserName == userParam.UserName);
            if (user == null)
            {
                return -1;
            }
            if (!string.IsNullOrWhiteSpace(userParam.Password))
            {
                user.Password = userParam.Password;
            }
            var result = myContext.SaveChanges();
            return result;

        }

    }
  
    
}
