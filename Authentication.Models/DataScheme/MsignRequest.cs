using System;
using System.Collections.Generic;

namespace Authentication.Api;

public partial class MsignRequest
{
    public int Id { get; set; }

    public int? MsignRequestDocumentId { get; set; }

    public string? MsingRequestId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? ResposnseAt { get; set; }

    public int? ResponseStatus { get; set; }

    public string? ResponseMessage { get; set; }

    public DateTime? SignDate { get; set; }

    public string? SignerFullName { get; set; }

    public string? SingerIdnp { get; set; }

    public byte[]? Sign { get; set; }

    public virtual MsignRequestDocument? MsignRequestDocument { get; set; }
}
