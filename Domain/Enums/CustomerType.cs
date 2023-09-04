using System.ComponentModel;
/// /// <summary>
/// Represents the types of CustomerType.
/// <remarks>
/// The following are the possible values for the `CustomerType` enum:
///
/// * `0-Natural`
/// * `1-Legal`
/// </remarks>
/// </summary>
public enum CustomerType
{
    [Description("Natural")]
    Natural,
    [Description("Legal")]
    Legal
}