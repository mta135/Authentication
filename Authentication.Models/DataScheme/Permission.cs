using System;
using System.Collections.Generic;

namespace Authentication.Api;

public partial class Permission
{
    public int Id { get; set; }

    public int? RoleId { get; set; }

    public int? MenuId { get; set; }

    public virtual Menu Menu { get; set; }

    public virtual RegisteredUserRole Role { get; set; }
}
