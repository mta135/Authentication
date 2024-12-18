using System;
using System.Collections.Generic;

namespace Authentication.Api;

public partial class Menu
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string LinkName { get; set; }

    public virtual ICollection<Permission> Permissions { get; set; } = new List<Permission>();
}
