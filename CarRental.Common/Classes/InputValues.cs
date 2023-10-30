using CarRental.Common.Enums;
using CarRental.Common.Interfaces;

namespace CarRental.Common.Classes;

public class InputValues
{
    public IRentable RentableInput { get; set; } = new Car();
    public ICustomer CustomerInput { get; set; } = new Customer();

    public VehicleAvailability? Display { get; set; }

    public IRentable? SelectedRentable { get; set; }
    public ICustomer? SelectedCustomer { get; set; }


    public void DefaultEverything()
    {
        RentableInput.VehicleType = default;
        RentableInput.Engine = default;
        RentableInput.Make = string.Empty;
        RentableInput.RegistrationNumber = string.Empty;
        RentableInput.Year = default;
        RentableInput.Odometer = default;
        SelectedRentable = default;
        SelectedCustomer = default;
        CustomerInput.FirstName = string.Empty;
        CustomerInput.LastName = string.Empty;
        CustomerInput.SSN= default;
    }

}
