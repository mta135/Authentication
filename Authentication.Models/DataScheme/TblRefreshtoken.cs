using System;
using System.Collections.Generic;

namespace Authentication.Api;

public partial class TblRefreshtoken
{
    public string Userid { get; set; }

    public string Tokenid { get; set; }

    public string Refreshtoken { get; set; }
}
