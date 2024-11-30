using System;
using System.Collections.Generic;

namespace Authentication.Api;

public partial class Appointment
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Idnp { get; set; }

    public string? BirthDate { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? AudienceSubject { get; set; }

    public string? ServiceId { get; set; }

    public string? ServiceName { get; set; }

    public string? ServiceTypeId { get; set; }

    public string? ServiceTypeName { get; set; }

    public string? PcerereId { get; set; }

    public string? RegisterDate { get; set; }

    public string? OrarId { get; set; }

    public int? OracleTransferStatus { get; set; }

    public virtual ICollection<MsignRequestDocument> MsignRequestDocuments { get; set; } = new List<MsignRequestDocument>();
}
