using CarRental.Common.Interfaces;

namespace CarRental.Common.Classes;

public class Customer : ICustomer
{
    int _id;
    long _ssn;

    public int Id => _id;
    public long SSN => _ssn;
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => NameConcat();
    public bool RentingVehicle { get; set; } = false;
    public IRentable? RentedVehicle { get; set; }


    public Customer(int id, long ssn, string firstName, string lastName) 
        => (_id, _ssn, FirstName, LastName) = (id, ssn, firstName, lastName);


    string NameConcat() => $"{FirstName} {LastName}";
}
