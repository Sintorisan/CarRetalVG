namespace CarRental.Common.Interfaces;

public interface ICustomer
{
    public int Id { get; }
    public long SSN { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; }
    public bool RentingVehicle { get; set; }
    public IRentable? RentedVehicle { get; set; }
}
