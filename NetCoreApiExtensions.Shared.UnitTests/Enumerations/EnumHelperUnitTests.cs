using FluentAssertions;
using NetCoreApiExtensions.Shared.Enumerations;
using NetCoreApiExtensions.Shared.Utilities;

namespace NetCoreApiExtensions.Shared.UnitTests.Enumerations
{
    public class EnumHelperUnitTests
    {
        public enum EnumWithoutDefault
        {
            Value1,
            Value2,
            Value3,
        }

        public enum EnumWithDefault
        {
            Value1,
            [DefaultValue]
            Value2,
            Value3,
        }

        public enum EnumWithAlternateDefault
        {
            Value1,
            Value2,
            [UnitTestDefault]
            Value3,
        }

        public enum EnumWithDoubleDefaults
        {
            Value1,
            [DefaultValue]
            Value2,
            [UnitTestDefault]
            Value3,
        }

        [Theory]
        [InlineData("value1", new object?[] {EnumWithDoubleDefaults.Value1, EnumWithDefault.Value1, EnumWithAlternateDefault.Value1, EnumWithoutDefault.Value1 })]
        [InlineData("not_a_value", new object?[] {EnumWithDoubleDefaults.Value2, EnumWithDefault.Value2, null, null })]
        public void EnumHelper_GetValueOrDefault_When_DefaultValueAttributeIsSpecified_TheCorrectValue_IsReturned(string input, object[] outputs)
        {
            var results = new List<object?>();
            results.Add(EnumHelper<EnumWithDoubleDefaults>.GetValueOrDefault(input));
            results.Add(EnumHelper<EnumWithDefault>.GetValueOrDefault(input));
            results.Add(EnumHelper<EnumWithAlternateDefault>.GetValueOrDefault(input));
            results.Add(EnumHelper<EnumWithoutDefault>.GetValueOrDefault(input));
            
            results.Should().BeEquivalentTo(outputs);
        }

        [Theory]
        [InlineData("value1", new object?[] { EnumWithDoubleDefaults.Value1, EnumWithDefault.Value1, EnumWithAlternateDefault.Value1, EnumWithoutDefault.Value1 })]
        [InlineData("not_a_value", new object?[] { EnumWithDoubleDefaults.Value3, null, EnumWithAlternateDefault.Value3, null })]
        public void EnumHelper_GetValueOrDefault_When_AlternateDefaultValueAttributeIsSpecified_TheCorrectValue_IsReturned(string input, object[] outputs)
        {
            var results = new List<object?>();
            results.Add(EnumHelper<EnumWithDoubleDefaults>.GetValueOrDefault<UnitTestDefaultAttribute>(input));
            results.Add(EnumHelper<EnumWithDefault>.GetValueOrDefault<UnitTestDefaultAttribute>(input));
            results.Add(EnumHelper<EnumWithAlternateDefault>.GetValueOrDefault<UnitTestDefaultAttribute>(input));
            results.Add(EnumHelper<EnumWithoutDefault>.GetValueOrDefault<UnitTestDefaultAttribute>(input));

            results.Should().BeEquivalentTo(outputs);
        }
    }
}