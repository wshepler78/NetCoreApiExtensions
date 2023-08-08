using NetCoreApiExtensions.Shared.Enumerations;

namespace NetCoreApiExtensions.WebApi.TestHarness.TestModels;

public enum DinosaurType
{
    Tyranosaurus,
    Stegosaurus,
    Triceretops,
    [DefaultValue]
    Brachiosaurus,
    Pterradon
}