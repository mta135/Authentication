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
        private readonly FlowersStoreDbContext _db;

        public RefreshHandler()
        {
            _db = new FlowersStoreDbContext();
        }

 
        public async Task<string> GenerateToken(string username)
        {
            try
            {
                byte[] randomnumber = new byte[32];

                using (RandomNumberGenerator randomnumbergenerator = RandomNumberGenerator.Create())
                {
                    randomnumbergenerator.GetBytes(randomnumber);

                    string refreshtoken = Convert.ToBase64String(randomnumber);

                    var Existtoken = _db.TblRefreshtokens.FirstOrDefaultAsync(item => item.Userid == username).Result;

                    if (Existtoken != null)
                    {
                        Existtoken.Refreshtoken = refreshtoken;
                    }
                    else
                    {
                        await _db.TblRefreshtokens.AddAsync(new TblRefreshtoken
                        {
                            Userid = username,

                            Tokenid = new Random().Next().ToString(),
                            
                            Refreshtoken = refreshtoken
                        });
                    }
                    await _db.SaveChangesAsync();

                    return refreshtoken;

                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
