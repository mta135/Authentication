using System;
using System.Collections.Generic;

namespace Authentication.Api;

public partial class Address
{
    public int Id { get; set; }

    public string? Street { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Zip { get; set; }
}
