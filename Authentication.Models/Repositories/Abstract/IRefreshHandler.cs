using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Models.Repositories.Abstract
{
    public interface IRefreshHandler
    {
        Task<string> GenerateToken(string userName);
    }
}
