using System;
using System.Collections.Generic;

namespace Authentication.Api.Authentication.Models.DataScheme;

public partial class RefreshToken
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string TokenId { get; set; }

    public string RefreshedToken { get; set; }

    public bool? IsActive { get; set; }

    public virtual RegisteredUser User { get; set; }
}
