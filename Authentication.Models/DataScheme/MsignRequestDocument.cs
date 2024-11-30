using System;
using System.Collections.Generic;

namespace Authentication.Api;

public partial class MsignRequestDocument
{
    public int Id { get; set; }

    public int? AppointmentId { get; set; }

    public byte? ProgramareAc { get; set; }

    public byte? Epensii { get; set; }

    public virtual Appointment? Appointment { get; set; }

    public virtual ICollection<MsignRequest> MsignRequests { get; set; } = new List<MsignRequest>();
}
