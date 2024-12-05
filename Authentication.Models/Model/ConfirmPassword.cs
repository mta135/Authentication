using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Models.Model
{
    public class ConfirmPassword
    {
        public int userid { get; set; }
        public string username { get; set; }
        public string otptext { get; set; }
    }
}
