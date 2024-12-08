using System;
using System.Collections.Generic;

namespace Authentication.Api;

public partial class OtpManager
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string? OtpText { get; set; }

    public string? OtpType { get; set; }

    public DateTime? ExpirationDate { get; set; }

    public DateTime? CreateddateDate { get; set; }

    public virtual RegisteredUser? User { get; set; }
}
