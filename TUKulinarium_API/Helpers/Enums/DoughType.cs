using System.Runtime.Serialization;

namespace TUKulinarium_API.Helpers.Enums
{
    public enum DoughTypes
    {
        [EnumMember(Value = "Thin and soft")]
        ThinCrunchy,
        [EnumMember(Value = "Thin and crunchy")]
        ThinSoft,
        [EnumMember(Value = "Thick and crunchy")]
        ThickCrunchy,
        [EnumMember(Value = "Thick and soft")]
        ThickSoft,

    }
}