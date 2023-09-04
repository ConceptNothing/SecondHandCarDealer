using System.ComponentModel;

/// /// <summary>
/// Represents the types of car categories.
/// <remarks>
/// The following are the possible values for the `CarCategory` enum:
///
/// * `0-SUV`
/// * `1-HATCHBACK`
/// * `2-SEDAN`
/// * `3-CROSSOVER`
/// * `4-COUPE`
/// * `5-WAGON`
/// * `6-MINIVAN`
/// * `7-PICKUP_TRUCK`
/// * `8-SPORT_CAR`
/// * `9-ELECTRIC_CAR`
/// * `10-HYBRID`
/// * `11-OFF_ROAD`
/// </remarks>
    /// </summary>
public enum CarCategory
{
    [Description("SUV")]
    SUV,

    [Description("HATCHBACK")]
    HATCHBACK,

    [Description("SEDAN")]
    SEDAN,

    [Description("CROSSOVER")]
    CROSSOVER,

    [Description("COUPE")]
    COUPE,

    [Description("WAGON")]
    WAGON,

    [Description("MINIVAN")]
    MINIVAN,


    [Description("PICKUP_TRUCK")]
    PICKUP_TRUCK,


    [Description("SPORT_CAR")]
    SPORT_CAR,


    [Description("ELECTRIC_CAR")]
    ELECTRIC_CAR,


    [Description("HYBRID")]
    HYBRID,

 
    [Description("OFF_ROAD")]
    OFF_ROAD
}
