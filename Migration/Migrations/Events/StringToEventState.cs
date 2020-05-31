using System;
using LaDanse.Target.Entities.Events;

namespace LaDanse.Migration.Migrations.Events
{
    public static class StringToEventState
    {
        public static EventState Convert(string strEventState)
        {
            return strEventState switch
            {
                "Pending" => EventState.Pending,
                "Confirmed" => EventState.Confirmed,
                "Cancelled" => EventState.Cancelled,
                "NotHappened" => EventState.NotHappened,
                "Happened" => EventState.Happened,
                "Deleted" => EventState.Deleted,
                "Archived" => EventState.Archived,
                _ => throw new Exception($"Unknown event state given: '{strEventState}'")
            };
        }
    }
}