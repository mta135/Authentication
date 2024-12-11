using System;
using System.Collections.Generic;

namespace Authentication.Api;

public partial class RefreshToken
{
    public int? UserId { get; set; }

    public string TokenId { get; set; }

    public string RefreshToken1 { get; set; }

    public bool? IsActive { get; set; }

    public virtual RegisteredUser User { get; set; }
}
