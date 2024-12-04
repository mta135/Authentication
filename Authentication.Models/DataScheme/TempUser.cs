using System;
using System.Collections.Generic;

namespace Authentication.Api;

public partial class TempUser
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? UserId { get; set; }

    public string? Password { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public virtual User? User { get; set; }
}
