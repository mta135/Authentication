using System;
using System.Collections.Generic;

namespace Authentication.Api;

public partial class RegisteredUserRole
{
    public int Id { get; set; }

    public int? RoleId { get; set; }

    public string Name { get; set; }

    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}
