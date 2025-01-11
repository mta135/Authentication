using Authentication.Api;

using Authentication.Models.Model;
using Authentication.Models.Model.RegisteredUsers;
using Authentication.Models.Repositories.Abstract;
using Azure;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Models.Repositories.Real
{
    public class UserService : IUserService
    {
        private readonly FlowersStoreDbContext _db;

        public UserService()
        {
            _db = new FlowersStoreDbContext();
        }

        public async Task<APIResponse> UserRegister(UserRegistrationModel userRegistration)
        {
            APIResponse registerResult = new APIResponse();

            try
            {
                TblTempuser _tempuser = new TblTempuser()
                {
                    Code = userRegistration.UserName,
                    Name = userRegistration.Name,
                    Email = userRegistration.Email,
                    Password = userRegistration.Password,
                    Phone = userRegistration.Phone,
                };

                await _db.TblTempusers.AddAsync(_tempuser);
                await _db.SaveChangesAsync();

                int userid = _tempuser.Id;
                string otp = GenerateRandomNumber();

                await UpdateOtp(userRegistration.UserName, otp, "register");

                registerResult.Result = "pass";
                registerResult.Message = userid.ToString();

                return registerResult;
            }
            catch (Exception)
            {
                registerResult.Result = "fail";

                registerResult.Message = Convert.ToString("-1");

                return registerResult;
            }
        }

        private async Task UpdateOtp(string username, string otptext, string otptype)
        {
            var _opt = new TblOtpManager()
            {
                Username = username,
                Otptext = otptext,
                Expiration = DateTime.Now.AddMinutes(30),
                Createddate = DateTime.Now,
                Otptype = otptype
            };

            await _db.TblOtpManagers.AddAsync(_opt);
            await _db.SaveChangesAsync();
        }

        private string GenerateRandomNumber()
        {
            Random random = new Random();

            string randomno = random.Next(0, 1000000).ToString("D6");
            return randomno;
        }

        public async Task<APIResponse> ConfirmRegister(int userId, string userName, string otpText)
        {
            APIResponse response = new();

            bool otpResponse = await ValidateOTP(userName, otpText);

            if (!otpResponse)
            {
                response.Result = "fail";
                response.Message = "Invalid OTP or Expired";
            }
            else
            {
                TblTempuser _tempdata = await _db.TblTempusers.FirstOrDefaultAsync(item => item.Id == userId);

                TblUser _user = new TblUser()
                {
                    Username = userName,
                    Name = _tempdata.Name,

                    Password = _tempdata.Password,
                    Email = _tempdata.Email,
                    Phone = _tempdata.Phone,

                    Failattempt = 0,
                    Isactive = true,
                    Islocked = false,

                    Role = "user"
                };

                await _db.TblUsers.AddAsync(_user);

                await _db.SaveChangesAsync();
                await UpdatePWDManager(userName, _tempdata.Password);

                response.Result = "pass";
                response.Message = "Registered successfully.";
            }

            return response;
        }


        public async Task<TblUser> GetRegisteredUser(UserCredentialsModel userCred)
        {
            return await _db.TblUsers.FirstOrDefaultAsync(item => item.Username == userCred.UserName && item.Password == userCred.Password && item.Isactive == true);
        }


        private async Task<bool> ValidateOTP(string username, string OTPText)
        {
            TblOtpManager _data = await _db.TblOtpManagers.FirstOrDefaultAsync(item => item.Username == username && item.Otptext == OTPText && item.Expiration > DateTime.Now);

            if (_data != null)
                return true;

            return false;
        }

        private async Task UpdatePWDManager(string username, string password)
        {
            TblPwdManger _opt = new TblPwdManger()
            {
                Username = username,
                Password = password,

                ModifyDate = DateTime.Now
            };

            await _db.TblPwdMangers.AddAsync(_opt);
            await _db.SaveChangesAsync();
        }
    }
}
