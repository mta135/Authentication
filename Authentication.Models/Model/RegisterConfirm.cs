using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Models.Model
{
    public class RegisterConfirm
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string OptText { get; set; }
    }
}
