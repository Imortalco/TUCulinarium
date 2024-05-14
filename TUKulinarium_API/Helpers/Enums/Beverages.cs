using System.Runtime.Serialization;

namespace TUKulinarium_API.Helpers.Enums
{
    public enum Beverages
    {
        Cola,
        Fanta,
        Sprite,
        [EnumMember(Value = "Schweppes Mandarin")]
        SchweppesMandarin,
        [EnumMember(Value = "Schweppes Tonic")]
        SchweppesTonic,
        [EnumMember(Value = "Schweppes Grapefruit")]
        SchweppesGrapefruit

    }
}