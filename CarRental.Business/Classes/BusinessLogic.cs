using CarRental.Common.Classes;
using CarRental.Common.Enums;
using CarRental.Common.ExtensionMethod;
using CarRental.Common.Interfaces;

namespace CarRental.Business.Classes
{
    public class BusinessLogic
    {

        private readonly IData _data;

        public BusinessLogic(IData data)
        {
            _data = data;
        }

        //Methods
        public void AddRemove<T>(T item, bool addRemove) where T : class
        {
            // addRemove = true; for adding - false; for removing

            if (item == default) throw new ArgumentNullException("Invalid item");

            if (item is IRentable rentable)
            {
                switch (addRemove)
                {
                    case true: _data.Add(rentable); break;
                    case false: _data.Remove(rentable); break;
                    default: throw new ArgumentException("Invalid choice");
                }

            }
            else if (item is ICustomer customer)
            {
                switch (addRemove)
                {
                    case true: _data.Add(customer); break;
                    case false: _data.Remove(customer); break;
                    default: throw new ArgumentException("Invalid choice");
                }
            }
            else if (item is IBooking booking)
            {
                switch (addRemove)
                {
                    case true: _data.Add(booking); break;
                    case false: _data.Remove(booking); break;
                    default: throw new ArgumentException("Invalid choice");
                }
            }
            else
            {
                throw new ArgumentException("Invalid type.");
            }
        }

        //Vehicles
        public async Task AddVehicle(VehicleType vt, VehicleEngine ve, double odo, string make, int year, string regNo)
        {
            await Task.Delay(3000);

            if (vt == default || ve == default) throw new ArgumentException("Invalid data");

            int id = _data.VehicleId();

            if (vt == VehicleType.Motorcycle)
                AddRemove(new Motorcycle(id, vt, ve, odo, make, year, regNo), true);
            else
                AddRemove(new Car(id, vt, ve, odo, make, year, regNo), true);

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
        public async Task AddBooking(ICustomer? customer, IRentable? vehicle)
        {
            await Task.Delay(3000);

            if (customer is null || vehicle is null) throw new ArgumentException("Invalid data");

            AddRemove(new Booking(customer, vehicle), true);
        }
        public async Task EndBooking(int id, DateTime returnDate)
        {
            await Task.Delay(3000);

            var booking = GetSingleBooking(id);

            if (booking is null) throw new ArgumentException("Can't find booking");

            booking.Reset().EndBooking(returnDate);
        }
        public async Task DeleteBooking(int id)
        {
            var booking = GetSingleBooking(id);

            await Task.Delay(3000);

            if (booking is null) throw new ArgumentException("Can't find booking");

            AddRemove(booking.Reset(), false);
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
        public async Task AddCustomer(int ssn, string firstName, string lastName)
        {
            await Task.Delay(3000);

            if (ssn == 0) throw new ArgumentException("Invalid or to short SSN");

            int id = _data.CustomerId();
            AddRemove<ICustomer>(new Customer(id, ssn, firstName, lastName), true);
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

        //Seeding Data
        //    public async Task SeedVehicleData()
        //    {
        //        var cars = await _http.GetFromJsonAsync<List<Car>>("sample-data/cars.json");
        //        var motorcycles = await _http.GetFromJsonAsync<List<Motorcycle>>("sample-data/motorcycles.json");

        //        if (cars != null)
        //            _data.AddOrRemove(cars, 0);

        //        if (motorcycles != null)
        //            _data.AddOrRemove(motorcycles, 0);
        //    }
    }
}
