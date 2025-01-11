using System;
using System.Collections.Generic;

namespace Authentication.Api;

public partial class TblPwdManger
{
    public int Id { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public DateTime? ModifyDate { get; set; }
}
