using Authentication.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Models.Repositories.Abstract
{
    public interface IUserService
    {
        Task<APIResponse> UserRegister(UserRegistration userRegistration);

        Task<APIResponse> ConfirmRegister(int userId, string userName, string otpText);
    }
}
