using Authentication.Api;
using Authentication.Models.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Models.Repositories.Real
{
    public class RefreshHandler : IRefreshHandler
    {
        private readonly EcerereDbContext _db;

        public RefreshHandler()
        {
            _db = new EcerereDbContext();
        }

        public async Task<string> GenerateToken(string username)
        {
            byte[] randomnumber = new byte[32];

            using (var randomnumbergenerator = RandomNumberGenerator.Create())
            {
                randomnumbergenerator.GetBytes(randomnumber);

                string refreshedToken = Convert.ToBase64String(randomnumber);

                RefreshToken refreshToken = await _db.RefreshTokens.FirstOrDefaultAsync(item => item.UserId == Convert.ToInt32(username));

                if (refreshToken != null)
                    refreshToken.RefreshedToken = refreshedToken;
              
                else
                {
                    RefreshToken dbRefreshToken = new()
                    {
                        UserId = Convert.ToInt32(username),
                        TokenId = new Random().Next().ToString(),
                        RefreshedToken = refreshedToken
                    };

                    await _db.RefreshTokens.AddAsync(dbRefreshToken);

                    await _db.SaveChangesAsync();
                }
             
                return refreshedToken;
            }
        }
    }
}
