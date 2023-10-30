using CarRental.Common.Interfaces;

namespace CarRental.Common.Classes;

public class Customer : ICustomer
{
    int _id;

    public int Id => _id;
    public long SSN { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string FullName => $"{FirstName} {LastName}";
    public bool RentingVehicle { get; set; } = false;
    public IRentable? RentedVehicle { get; set; }



    public Customer() { }
    public Customer(int id, long ssn, string firstName, string lastName)
        => (_id, SSN, FirstName, LastName) = (id, ssn, firstName, lastName);

}
