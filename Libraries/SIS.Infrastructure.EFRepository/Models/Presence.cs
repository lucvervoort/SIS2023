using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class Presence
{
    public int PresenceId { get; set; }

    public int OfficialCode { get; set; }

    public string Qrcode { get; set; } = null!;

    public int PresenceStateId { get; set; }

    public int PersonId { get; set; }

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Person Person { get; set; } = null!;

    public virtual PresenceState PresenceState { get; set; } = null!;
}
