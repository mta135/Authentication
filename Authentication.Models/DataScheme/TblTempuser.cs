using System;
using System.Collections.Generic;

namespace Authentication.Api;

public partial class TblTempuser
{
    public int Id { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string Password { get; set; }
}
