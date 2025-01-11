using System;
using System.Collections.Generic;

namespace Authentication.Api;

public partial class TblUser
{
    public string Username { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string Password { get; set; }

    public bool? Isactive { get; set; }

    public string Role { get; set; }

    public bool? Islocked { get; set; }

    public int? Failattempt { get; set; }
}
