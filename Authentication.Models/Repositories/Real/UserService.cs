using Authentication.Api;
using Authentication.Models.Model;
using Authentication.Models.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Models.Repositories.Real
{
    public class UserService : IUserService
    {
        EcerereDbContext _db;

        public UserService()
        {
            _db = new EcerereDbContext();
        }

        public async Task<UserRegisterResult> UserRegister(UserRegistration userRegistration)
        {

            UserRegisterResult userRegisterResult = new UserRegisterResult();
            
            User user = new User();

            user.Name = userRegistration.Name;
            user.Email = userRegistration.Email;
            user.UserName = userRegistration.UserName;
 
            user.Password = userRegistration.Password;
   
            user.Role = user.Role;

            string otp = Generaterandomnumber();


            await _db.Users.AddAsync(user);
            
            await _db.SaveChangesAsync();


            return userRegisterResult;
        }




        private string Generaterandomnumber()
        {
            Random random = new Random();

            string randomno = random.Next(0, 1000000).ToString("D6");
            return randomno;
        }

    }
}
