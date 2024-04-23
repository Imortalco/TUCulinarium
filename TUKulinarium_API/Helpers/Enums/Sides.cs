using System.Runtime.Serialization;

namespace TUKulinarium_API.Helpers.Enums
{
    public enum Sides
    {
        Fries,
        [EnumMember(Value = "Fries with cheeese")]
        Frieswithcheese,
        [EnumMember(Value = "Mashed Potatoes")]
        MashedPotatoes,
        [EnumMember(Value = "Steamed Vegetables")]
        SteamedVegetables
    }
}