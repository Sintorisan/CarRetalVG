namespace CarRental.Common.Interfaces;

public interface IBooking
{
    public int Id { get; }
    public int StartFee { get; }
    public DateTime StartDate { get; }
    public string? ReturnDate { get; set; }
    public ICustomer Customer { get; set; }
    public IRentable Vehicle { get; set; }
    public int TotalCost { get; }
    public string Status { get; set; }
    public int KmStart { get; }
    public int KmDriven { get; set; }


    public void EndBooking(DateTime returnDate);
}
