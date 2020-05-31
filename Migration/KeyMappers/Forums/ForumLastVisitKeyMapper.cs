﻿using System;

namespace LaDanse.Migration.KeyMappers.Forums
{
    public class ForumLastVisitKeyMapper : GenericKeyMapper<string, Guid>
    {
        protected override Guid CreateTargetKey()
        {
            return Guid.NewGuid();
        }
    }
}