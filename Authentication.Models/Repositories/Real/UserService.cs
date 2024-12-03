using Authentication.Api;
using Authentication.Models.DataScheme;
using Authentication.Models.Model;
using Authentication.Models.Repositories.Abstract;

namespace Authentication.Models.Repositories.Real
{
    public class UserService : IUserService
    {
        private readonly EcerereDbContext _db;

        public UserService()
        {
            _db = new EcerereDbContext();
        }

        public async Task<RegisterResult> UserRegister(UserRegistration userRegistration)
        {
            RegisterResult registerResult = new RegisterResult();

            try
            {
                User user = new();

                user.Name = userRegistration.Name;
                user.Email = userRegistration.Email;
                user.UserName = userRegistration.UserName;

                user.Password = userRegistration.Password;

                user.Role = user.Role;

                string otp = GenerateRandomNumber();

                user.OtpManagers.Add(SetOtpManager(otp, "register"));

                await _db.Users.AddAsync(user);

                await _db.SaveChangesAsync();

                registerResult.Result = "pass";

                registerResult.Message = user.Id.ToString();

                return registerResult;

            }
            catch (Exception ex)
            {
                registerResult.Result = "fail";

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




        private string GenerateRandomNumber()
        {
            Random random = new Random();

            string randomno = random.Next(0, 1000000).ToString("D6");
            return randomno;
        }

    }
}
