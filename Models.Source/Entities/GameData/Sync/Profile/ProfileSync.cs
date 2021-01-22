using System;
using LaDanse.Source.Entities.Identity;

namespace LaDanse.Source.Entities.GameData.Sync.Profile
{
    public partial class ProfileSync
    {
        public string Id { get; set; }

        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}
