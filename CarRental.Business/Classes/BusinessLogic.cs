using CarRental.Common.Classes;
using CarRental.Common.Enums;
using CarRental.Common.ExtensionMethod;
using CarRental.Common.Interfaces;

namespace CarRental.Business.Classes
{
    public class BusinessLogic
    {
        private readonly IData _data;
        private readonly InputValues _iv;
        private readonly Messages _messages;

        public BusinessLogic(IData data, InputValues inputValues, Messages messages)
        {
            _data = data;
            _iv = inputValues;
            _messages = messages;
        }

        //Methods
        public void Add<T>(T item) where T : class
        {
            if (item == null) throw new ArgumentNullException("No item found");

            if (item is Booking booking)
            {
                _data.Add<IBooking>(booking);
            }
            else if (item is Customer customer)
            {
                _data.Add<ICustomer>(customer);
            }
            else if (item is Car car)
            {
                _data.Add<IRentable>(car);
            }
            else if (item is Motorcycle motorcycle)
            {
                _data.Add<IRentable>(motorcycle);
            }
        }
        public void Remove<T>(T item) where T : class
        {
            if (item == null) throw new ArgumentNullException("No item found");

            if (item is Booking booking)
            {
                _data.Remove<IBooking>(booking);
            }
            else if (item is Customer customer)
            {
                _data.Remove<ICustomer>(customer);
            }
            else if (item is Car car)
            {
                _data.Remove<IRentable>(car);
            }
            else if (item is Motorcycle motorcycle)
            {
                _data.Remove<IRentable>(motorcycle);
            }
        }

        //Vehicles
        public async Task AddVehicleAsync()
        {
            _messages.InProgress();
            int id = _data.VehicleId();

            await Task.Delay(3000);

            if (_iv.Type == default || _iv.Engine == default) throw new ArgumentException("Invalid data");

            try
            {
                if (_iv.Type == VehicleType.Motorcycle)
                    Add(new Motorcycle(id, _iv.Type, _iv.Engine, _iv.Odometer, _iv.Make, _iv.Year, _iv.RegNo));
                else
                    Add(new Car(id, _iv.Type, _iv.Engine, _iv.Odometer, _iv.Make, _iv.Year, _iv.RegNo));

                _iv.DefaultEverything();
            }
            catch (Exception ex)
            {
                _messages.ErrorMessage(ex);
            }
            finally
            {
                _messages.AddingSuccess();
            }
        }
        public IEnumerable<IRentable> GetRentables(VehicleAvailability? status)
        {
            return status is not null ? _data.Get<IRentable>(v => v?.Availability == status) : _data.Get<IRentable>(null);
        }
        public IRentable GetSingleVehicle(int id)
        {
            var vehicle = _data.GetSingle<IRentable>(c => c.Id == id);

            return vehicle ?? throw new ArgumentException("Can't find vehicle");
        }

        //Bookings
        public async Task AddBookingAsync()
        {
            _messages.InProgress();

            await Task.Delay(3000);

            if (_iv.SelectedCustomer is null || _iv.SelectedRentable is null) throw new ArgumentException("Invalid data");

            try
            {
                Add(new Booking(_iv.SelectedCustomer, _iv.SelectedRentable));
                _iv.DefaultEverything();
            }
            catch (Exception ex)
            {
                _messages.ErrorMessage(ex);
            }
            finally
            {
                _messages.BookingSuccess();
            }
        }
        public async Task EndBookingAsync(int id)
        {
            _messages.InProgress();
            var booking = GetSingleBooking(id);

            await Task.Delay(3000);

            if (booking is null) throw new ArgumentException("Can't find booking");

            try
            {
                booking.Reset().EndBooking(DateTime.Now);
            }
            catch (Exception ex)
            {
                _messages?.ErrorMessage(ex);
            }
            finally
            {
                _messages.EndBooking();
            }

        }
        public async Task DeleteBookingAsync(int id)
        {
            _messages.InProgress();
            var booking = GetSingleBooking(id);

            await Task.Delay(3000);

            if (booking is null) throw new ArgumentException("Can't find booking");

            try
            {
                Remove(booking.Reset());
            }
            catch (Exception ex)
            {
                _messages?.ErrorMessage(ex);
            }
            finally
            {
                _messages.DeleteBooking();
            }

        }
        public IEnumerable<IBooking> GetBookingStatus(string? status)
        {
            return status is not null ? _data.Get<IBooking>(b => b.Status == status) : _data.Get<IBooking>(null);
        }
        public IBooking GetSingleBooking(int id)
        {
            var booking = _data.GetSingle<IBooking>(c => c.Id == id);

            return booking ?? throw new ArgumentException("Can't find booking");
        }



        //Customers
        public async Task AddCustomerAsync()
        {
            _messages.InProgress();
            int id = _data.CustomerId();

            await Task.Delay(3000);

            if (_iv.SSN == 0) throw new ArgumentException("Invalid or to short SSN");

            try
            {
                Add(new Customer(id, _iv.SSN, _iv.FirstName, _iv.LastName));
                _iv.DefaultEverything();
            }
            catch (Exception ex)
            {
                _messages.ErrorMessage(ex);
            }
            finally
            {
                _messages.AddingSuccess();
            }
        }
        public ICustomer GetSingleCustomer(int id)
        {
            var customer = _data.GetSingle<ICustomer>(c => c.Id == id);

            return customer ?? throw new ArgumentException("Can't find customer");
        }
        public IEnumerable<ICustomer> GetCustomers(bool? status)
        {
            return status is not null ? _data.Get<ICustomer>(c => c.RentingVehicle == status) : _data.Get<ICustomer>(null);
        }

        //Enums
        public IEnumerable<VehicleEngine> GetVehicleEngine() => Enum.GetValues(typeof(VehicleEngine)).Cast<VehicleEngine>();
        public IEnumerable<VehicleType> GetVehicleTypes() => Enum.GetValues(typeof(VehicleType)).Cast<VehicleType>();

    }
}
