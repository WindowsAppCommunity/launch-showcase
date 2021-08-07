using System.Runtime.Serialization;

namespace LaunchShowcase.Sdk.Models
{
    public enum Role
    {
        Other,
        Developer,
        Translator,

        [EnumMember(Value = "Beta Tester")]
        BetaTester,
        Advocate,
        Patreon,
        Lead,
        Support,
    }
}