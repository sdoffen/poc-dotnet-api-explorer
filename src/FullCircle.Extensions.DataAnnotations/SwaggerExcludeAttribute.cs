using System.Diagnostics.CodeAnalysis;

namespace FullCircle.Extensions.DataAnnotations;

/// <summary>
/// Specified that the target should not show up in the OpenApi specification.
/// </summary>
[ExcludeFromCodeCoverage]
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Field | AttributeTargets.Property)]
public sealed class SwaggerExcludeAttribute : Attribute { }
