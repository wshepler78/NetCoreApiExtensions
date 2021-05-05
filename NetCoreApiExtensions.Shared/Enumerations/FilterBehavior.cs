using System.ComponentModel;

namespace NetCoreApiExtensions.Shared.Enumerations
{
    public enum FilterBehavior
    {
        [Description("Contains")]
        Contains,
        [Description("Does Not Contain")]
        DoesNotContain,
        [Description("Starts With")]
        StartsWith,
        [Description("Ends With")]
        EndsWith,
        [Description("Equal To")]
        EqualTo,
        [Description("Not Equal To")]
        NotEqualTo,
        [Description("Greater Than")]
        GreaterThan,
        [Description("Less Than")]
        LessThan,
        [Description("Greater Than or Equal To")]
        GreaterThanOrEqualTo,
        [Description("Less Than or Equal To")]
        LessThanOrEqualTo,
        [Description("Between")]
        Between,
        [Description("Not Between")]
        NotBetween,
        [Description("Is Empty")]
        IsEmpty,
        [Description("Not Empty")]
        NotEmpty,
        [Description("Is Null")]
        IsNull,
        [Description("Not Null")]
        NotNull
    }
}