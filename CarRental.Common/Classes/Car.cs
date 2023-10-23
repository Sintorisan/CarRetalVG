using CarRental.Common.Enums;
using CarRental.Common.Interfaces;

namespace CarRental.Common.Classes;

public class Car : RentalVehicle, IRentable
{
    public string Make { get; set; }
    public int Year { get; init; }
    public string RegistrationNumber { get; init; }
    public string Picture => SetPicture("https://cdn-icons-png.flaticon.com/256/27/27003.png");
    public string Description => SetDescription($"A {VehicleType} made by {Make} the year {Year} it has a {Engine} engine.");
    public Car(int id, VehicleType vt, VehicleEngine ve, double odo, string make, int year, string regNo)
        : base(id, vt, ve, odo) => (Make, Year, RegistrationNumber) = (make, year, regNo);


    public void VehiclePresentation(string description, string picture)
    {
        SetDescription(description);
        SetPicture(picture);
    }

    string SetDescription(string d)
    {
        return d;
    }
    string SetPicture(string p)
    {
        return p;
    }
}