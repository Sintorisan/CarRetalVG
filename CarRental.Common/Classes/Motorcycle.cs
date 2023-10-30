using CarRental.Common.Enums;
using CarRental.Common.Interfaces;

namespace CarRental.Common.Classes;

public class Motorcycle : RentalVehicle, IRentable
{
    public string Make { get; set; } = string.Empty;
    public int Year { get; set; }
    public string RegistrationNumber { get; set; } = string.Empty;
    public string Picture => "https://images.vexels.com/media/users/3/154289/isolated/lists/01d9c0910dd460a109b2e0fd475bebe8-classic-motorcycle-silhouette.png";
    public string Description => $"A {VehicleType} made by {Make} the year {Year} it has a {Engine} engine.";


    public Motorcycle(int id, VehicleType vt, VehicleEngine ve, double odo, string make, int year, string regNo)
        : base(id, vt, ve, odo) => (Make, Year, RegistrationNumber) = (make, year, regNo);
}



