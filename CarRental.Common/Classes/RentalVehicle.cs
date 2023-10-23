using CarRental.Common.Enums;
using CarRental.Common.Interfaces;
using System.Reflection.Metadata.Ecma335;

namespace CarRental.Common.Classes;

public class RentalVehicle
{
    int _id;
    public int Id => _id;
    public VehicleType VehicleType { get; set; }
    public VehicleEngine Engine { get; set; }
    public VehicleAvailability Availability { get; set; } = VehicleAvailability.Available;
    public double Odometer { get;  set; }
    public int CostKm => (int)Engine;
    public int CostDay => (int)VehicleType;


    public RentalVehicle(int id, VehicleType vt, VehicleEngine ve, double odo)
    {
        (_id, VehicleType, Engine, Odometer) = (id, vt, ve, odo);
    }        

    public void OdoUpdate(double newOdo) => Odometer = newOdo;
}
