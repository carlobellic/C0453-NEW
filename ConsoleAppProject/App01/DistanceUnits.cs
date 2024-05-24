using System.ComponentModel.DataAnnotations;
// This is just background code that is able to be pulled from inside the distance converter, which allows it to know what the units of measurements are.
namespace ConsoleAppProject.App01
{
    /// <summary>
    /// List of units used to measure distance
    /// </summary>
    public enum DistanceUnits
    {
        [Display(Name = "No Unit")]
        NoUnit,
        Feet,
        Metres,
        Kilometres,
        Miles
    }
}
