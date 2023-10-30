using CarRental.Common.Enums;
using CarRental.Common.Interfaces;

namespace CarRental.Common.Classes;

public class Car : RentalVehicle, IRentable
{
    public string Make { get; set; } = string.Empty;
    public int Year { get; set; }
    public string RegistrationNumber { get; set; } = string.Empty;
    public string Picture => "https://cdn-icons-png.flaticon.com/256/27/27003.png";
    public string Description => $"A {VehicleType} made by {Make} the year {Year} it has a {Engine} engine.";


    public Car() { }

    public Car(int id, VehicleType vt, VehicleEngine ve, double odo, string make, int year, string regNo)
        : base(id, vt, ve, odo) => (Make, Year, RegistrationNumber) = (make, year, regNo);


}