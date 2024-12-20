using Authentication.Api;

using Authentication.Models.Model;
using Authentication.Models.Model.RegisteredUsers;
using Authentication.Models.Repositories.Abstract;
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
                RegisteredUser registstered = new();

                registstered.Name = userRegistration.Name;
                registstered.Email = userRegistration.Email;
                registstered.UserName = userRegistration.UserName;

                registstered.Password = userRegistration.Password;

                registstered.Role = registstered.Role;

                registstered.NrCont = userRegistration.NrCont;

                string otp = GenerateRandomNumber();

                registstered.OtpManagers.Add(SetOtpManager(otp, "register"));

                registstered.TempUsers.Add(SetTempUser(userRegistration));
                
                await _db.RegisteredUsers.AddAsync(registstered);

                await _db.SaveChangesAsync();

                registerResult.Result = "pass";

                registerResult.Message = registstered.Id.ToString();

                return registerResult;

            }
            catch (Exception)
            {
                registerResult.Result = "fail" ;

                registerResult.Message = Convert.ToString("-1");

                return registerResult;
            }
        }

        private OtpManager SetOtpManager(string otpText, string optType)
        {
            OtpManager otpManager = new()
            {
                OtpText = otpText,
                CreateddateDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddMinutes(30),
                OtpType = optType
            };

            return otpManager;
        }

        private TempUser SetTempUser(UserRegistrationModel userRegistration)
        {
            TempUser tempUser = new TempUser
            {
                Name = userRegistration.Name,

                Email = userRegistration.Email,
                Password = userRegistration.Password,
                Phone = userRegistration.Phone
            };
            return tempUser;
        }

        private string GenerateRandomNumber()
        {
            Random random = new Random();

            string randomno = random.Next(0, 1000000).ToString("D6");
            return randomno;
        }

        public async Task<APIResponse> ConfirmRegister(int userId, string userName, string otpText)
        {
            APIResponse response = new APIResponse();

            bool otpResponse = await ValidateOTP(userId, otpText);

            if (!otpResponse)
            {
                response.Result = "fail";
                response.Message = "Invalid OTP or Expired";
            }
            else
            {
                RegisteredUser user = await _db.RegisteredUsers.Where(x => x.Id == userId).FirstOrDefaultAsync();
                user.Role = "user";
                user.IsConfirmed = true;

                await _db.SaveChangesAsync();

                response.Result = "pass";

                response.Message = "Registered successfully.";
            }

            return response;
        }


        public async Task<RegisteredUser> GetRegisteredUser(UserCredentialsModel userCred)
        {
            return await _db.RegisteredUsers.FirstOrDefaultAsync(x => x.UserName == userCred.UserName && x.Password == userCred.Password && x.IsActive == true);
        }


        private async Task<bool> ValidateOTP(int? userId, string OTPText)
        {
            return  await _db.OtpManagers.AnyAsync(item => item.UserId == userId && item.OtpText == OTPText && item.ExpirationDate > DateTime.Now);
        }
    }
}
