using System;
using LaDanse.Target.Entities.Events;

namespace LaDanse.Migration.Migrations.Events
{
    public static class StringToSignUpType
    {
        public static SignUpType Convert(string strSignUpType)
        {
            return strSignUpType switch
            {
                "WillCome" => SignUpType.WillCome,
                "MightCome" => SignUpType.MightCome,
                "Absence" => SignUpType.Absence,
                _ => throw new Exception($"Unknown sign up type given: '{strSignUpType}'")
            };
        }
    }
}