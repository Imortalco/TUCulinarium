using System.Runtime.Serialization;

namespace TUKulinarium_API.Helpers.Enums
{
    public enum Sauces
    {
        [EnumMember(Value = "BBQ Sauce")]
        BBQSauce,
        Ketchup,
        Mayonnaise,
        [EnumMember(Value = "Honey Mustard")]
        HoneyMustard,
        [EnumMember(Value = "Garlic Sauce")]
        GarlicSauce,
        [EnumMember(Value = "Chilli Sauce")]
        ChilliSauce
    }
}