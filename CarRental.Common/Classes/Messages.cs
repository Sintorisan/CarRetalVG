namespace CarRental.Common.Classes;

public class Messages
{
    public string? Message { get; set; }
    public bool ErrorBool { get; set; }
    public bool AddingComplete { get; set; }
    public bool BookingComplete { get; set; }
    public bool InProgressBool { get; set; }
    public bool EndBookingBool { get; set; }
    public bool DeleteBookingBool { get; set; }

    public void InProgress()
    {
        InProgressBool = true;
    }
    public void ErrorMessage(Exception ex)
    {
        ResetMessage();
        InProgressBool = false;
        ErrorBool = true;
        Message = $"{ex.Message}! Please try again";
    }
    public void BookingSuccess()
    {
        ResetMessage();
        InProgressBool = false;
        BookingComplete = true;
        Message = "Booking Successful";
    }

    public void AddingSuccess()
    {
        ResetMessage();
        InProgressBool = false;
        AddingComplete = true;
        Message = "Successfully Added";
    }

    public void EndBooking()
    {
        ResetMessage();
        InProgressBool = false;
        EndBookingBool = true;
        Message = "Booking Successfully Ended";
    }

    public void DeleteBooking()
    {
        ResetMessage();
        InProgressBool = false;
        DeleteBookingBool = true;
        Message = "Booking Successfully Deleted";
    }
    public void ResetMessage()
    {
        Message = string.Empty;
        ErrorBool = false;
        AddingComplete = false;
        BookingComplete = false;
        EndBookingBool = false;
        DeleteBookingBool = false;
    }
}
