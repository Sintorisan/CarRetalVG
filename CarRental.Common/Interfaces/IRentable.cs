using CarRental.Common.Enums;

namespace CarRental.Common.Interfaces;

public interface IRentable
{
    public int Id { get;}
    public VehicleType VehicleType { get; set; }
    public VehicleEngine Engine { get; set; }
    public VehicleAvailability Availability { get; set; }
    public string Make { get; set; }
    public int Year { get; }
    public string RegistrationNumber { get; }
    public double Odometer { get; set; }
    public int CostKm { get; }
    public int CostDay { get; }
    public string Picture { get; }
    public string Description { get; }
}
