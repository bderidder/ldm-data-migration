using System;

namespace LaDanse.Target.Entities.Shared
{
    public interface ITimeVersionedEntity
    {
        DateTime FromTime { get; set; }
        DateTime? EndTime { get; set; }
    }
}