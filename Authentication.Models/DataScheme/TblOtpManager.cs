using System;
using System.Collections.Generic;

namespace Authentication.Api;

public partial class TblOtpManager
{
    public int Id { get; set; }

    public string Username { get; set; }

    public string Otptext { get; set; }

    public string Otptype { get; set; }

    public DateTime Expiration { get; set; }

    public DateTime? Createddate { get; set; }
}
