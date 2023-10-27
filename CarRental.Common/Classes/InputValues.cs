using CarRental.Common.Enums;
using CarRental.Common.Interfaces;

namespace CarRental.Common.Classes;

public class InputValues
{

    //TODO: Använd mig av RentableInput CustomerInput properties istället
    public IRentable? RentableInput { get; set; } = null;
    public ICustomer? CustomerInput { get; set; } = null;



    public VehicleAvailability? Display { get; set; }

    //Booking
    public IRentable? SelectedRentable { get; set; }
    public ICustomer? SelectedCustomer { get; set; }

    //Vehicles
    public VehicleType Type { get; set; } = default;
    public VehicleEngine Engine { get; set; } = default;
    public string Make { get; set; } = string.Empty;
    public string RegNo { get; set; } = string.Empty;
    public int Year { get; set; }
    public double Odometer { get; set; }

    //Customer
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int SSN { get; set; }




    public void AssignValue<T>(T? value) where T : class
    {
        if (value is null) throw new ArgumentNullException("Value is null");

        if (value is IRentable rentableValue)
            SelectedRentable = rentableValue;
        else if (value is ICustomer customerValue)
            SelectedCustomer = customerValue;
        else
            throw new ArgumentException("Invalid value");
    }

    public void DefaultEverything()
    {
        Type = default;
        Engine = default;
        Make = string.Empty;
        RegNo = string.Empty;
        Year = default;
        Odometer = default;
        SelectedRentable = default;
        SelectedCustomer = default;
        FirstName = string.Empty;
        LastName = string.Empty;
        SSN = default;
    }

}
