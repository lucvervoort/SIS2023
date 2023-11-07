using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class Room
{
    public int RoomId { get; set; }

    public int BuildingId { get; set; }

    public string Name { get; set; } = null!;

    public int? RoomTypeId { get; set; }

    public int? RoomKindId { get; set; }

    public int? Capacity { get; set; }

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Building Building { get; set; } = null!;

    public virtual RoomKind? RoomKind { get; set; }

    public virtual RoomType? RoomType { get; set; }

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
