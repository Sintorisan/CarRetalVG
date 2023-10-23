using CarRental.Common.Classes;
using CarRental.Common.Enums;
using CarRental.Common.Interfaces;

namespace CarRental.Common.ExtensionMethod;

public static class BookingExtensions
{
    public static IBooking Reset(this IBooking booking)
    { 

        booking.Customer.RentingVehicle = false;
        booking.Customer.RentedVehicle = default;
        booking.Vehicle.Availability = VehicleAvailability.Available;
        booking.Vehicle.Odometer += booking.KmDriven;
        
        
        return booking;
    }
}
