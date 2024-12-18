using System;
using System.Collections.Generic;

namespace Authentication.Api.Authentication.Models.DataScheme;

public partial class RegisteredUser
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public string Email { get; set; }

    public string Role { get; set; }

    public bool? IsActive { get; set; }

    public bool? IsConfirmed { get; set; }

    public virtual ICollection<OtpManager> OtpManagers { get; set; } = new List<OtpManager>();

    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

    public virtual ICollection<TempUser> TempUsers { get; set; } = new List<TempUser>();
}
