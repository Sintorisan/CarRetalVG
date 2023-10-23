using CarRental.Common.Enums;
using CarRental.Common.Interfaces;

namespace CarRental.Common.Classes;

public class Motorcycle : RentalVehicle, IRentable
{
    public string Make { get; set; }
    public int Year { get; init; }
    public string RegistrationNumber { get; init; }
    public string Picture => SetPicture("https://images.vexels.com/media/users/3/154289/isolated/lists/01d9c0910dd460a109b2e0fd475bebe8-classic-motorcycle-silhouette.png");
    public string Description => SetDescription($"A {VehicleType} made by {Make} the year {Year} it has a {Engine} engine.");

    public Motorcycle(int id, VehicleType vt, VehicleEngine ve, double odo, string make, int year, string regNo)
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



