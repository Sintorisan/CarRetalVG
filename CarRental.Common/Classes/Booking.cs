using CarRental.Common.Enums;
using CarRental.Common.Interfaces;

namespace CarRental.Common.Classes;

public class Booking : IBooking
{
    int _id;
    public int Id => _id;
    public int StartFee => (int)Vehicle.CostDay;
    public DateTime StartDate => DateTime.Now;
    public string? ReturnDate { get; set; }
    public ICustomer Customer { get; set; }
    public IRentable Vehicle { get; set; }
    public int KmStart { get; init; }
    public int KmDriven { get; set; }
    public int TotalCost { get; private set; }
    public string Status { get; set; }


    public Booking(ICustomer customer, IRentable vehicle)
    {
        Customer = customer;
        Vehicle = vehicle;
        _id = IdGenerator();
        Status = "Open";
        KmStart = (int)vehicle.Odometer;
        Vehicle.Availability = VehicleAvailability.Booked;
        Customer.RentingVehicle = true;
        Customer.RentedVehicle = Vehicle;
    }

    public void EndBooking(DateTime returnDate)
    {
        TimeSpan rentalDuration = returnDate - StartDate;

        int rentalDurationCost = StartFee + Vehicle.CostDay * (int)rentalDuration.TotalDays;
        int rentalKmCost = KmDriven * Vehicle.CostKm;
        int totalCost = rentalDurationCost + rentalKmCost;

        ReturnDate = returnDate.ToShortDateString();
        TotalCost = totalCost;
    }

    private int IdGenerator()
    {
        Random random = new Random();
        int bookingId = random.Next(1000, 8999) + Customer.Id;
        return bookingId;
    }
}
