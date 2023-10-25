using CarRental.Common.Classes;
using CarRental.Common.Enums;
using CarRental.Common.Interfaces;
using System.Net.Http.Json;

namespace CarRental.Data;

public class CollectionData : IData
{



    readonly List<IBooking> _bookings = new();
    readonly List<ICustomer> _customers = new();
    readonly List<IRentable> _rentables = new();


    public CollectionData()
    {
        SeedData();
    }


    void SeedData()
    {
        _customers.Add(new Customer(CustomerId(), 7807202635, "John", "Doe"));
        _customers.Add(new Customer(CustomerId(), 6711247542, "Jane", "Doe"));
        _customers.Add(new Customer(CustomerId(), 8810141536, "Bob", "Smith"));
        _customers.Add(new Customer(CustomerId(), 9209063467, "Mary", "Johnson"));
        _rentables.Add(new Car(1, VehicleType.SUV, VehicleEngine.Diesel, 123425, "Volvo", 2020, "HAI-298"));
        _rentables.Add(new Car(2, VehicleType.Coupe, VehicleEngine.Electric, 212424, "Tesla", 2022, "MDI-571"));
        _rentables.Add(new Car(3, VehicleType.Hatchback, VehicleEngine.Gasoline, 234523, "Toyota", 2017, "KDI-631"));
        _rentables.Add(new Motorcycle(4, VehicleType.Motorcycle, VehicleEngine.Gasoline, 123414, "Yamaha", 2005, "AJI-361"));
        _bookings.Add(new Booking(_customers[0], _rentables[1]));
        _bookings.Add(new Booking(_customers[1], _rentables[0]));        
    }

    public int VehicleId()
    {
        Random random = new Random();
        int id;
        do { id = random.Next(1000, 9999); }
        while (_rentables.Any(v => v.Id == id));
        return id;
    }
    public int CustomerId()
    {
        Random random = new Random();
        int id;
        do { id = random.Next(100, 999); }
        while (_customers.Any(v => v.Id == id));
        return id;
    }


    public IEnumerable<T> Get<T>(Func<T, bool>? predicate = null) where T : class
    {
        if (typeof(T) == typeof(IRentable))
        {
            return predicate is null ? _rentables.Cast<T>() : _rentables.Cast<T>().Where(predicate)
                ?? throw new ArgumentException("Nothing to return.");
        }
        else if (typeof(T) == typeof(ICustomer))
        {
            return predicate is null ? _customers.Cast<T>() : _customers.Cast<T>().Where(predicate)
                ?? throw new ArgumentException("Nothing to return.");
        }
        else if (typeof(T) == typeof(IBooking))
        {
            return predicate is null ? _bookings.Cast<T>() : _bookings.Cast<T>().Where(predicate)
                ?? throw new ArgumentException("Nothing to return.");
        }
        else
        {
            throw new ArgumentException("Invalid type.");
        }
    }
    public T? GetSingle<T>(Func<T, bool> predicate) where T : class
    {
        if (typeof(T) == typeof(IRentable))
        {
            return _rentables.Cast<T>().SingleOrDefault(predicate)
                ?? throw new ArgumentException("Nothing to return.");
        }
        else if (typeof(T) == typeof(ICustomer))
        {
            return _customers.Cast<T>().SingleOrDefault(predicate)
                ?? throw new ArgumentException("Nothing to return.");
        }
        else if (typeof(T) == typeof(IBooking))
        {
            return _bookings.Cast<T>().SingleOrDefault(predicate)
                ?? throw new ArgumentException("Nothing to return.");
        }
        else
        {
            throw new ArgumentException("Invalid type.");
        }
    }

    public void Add<T>(T item) where T : class
    {
        if (item == default) throw new ArgumentNullException("Invalid item");

        if (item is IRentable rentable)
        {
            _rentables.Add(rentable);
        }
        else if (item is ICustomer customer)
        {
            _customers.Add(customer);
        }
        else if (item is IBooking booking)
        {
            _bookings.Add(booking);
        }
        else
        {
            throw new ArgumentException("Invalid type.");
        }
    }
    public void Remove<T>(T item) where T : class
    {
        if (item == default) throw new ArgumentNullException("Invalid item");

        if (item is IRentable rentable)
        {
            _rentables.Remove(rentable);
        }
        else if (item is ICustomer customer)
        {
            _customers.Remove(customer);
        }
        else if (item is IBooking booking)
        {
            _bookings.Remove(booking);
        }
        else
        {
            throw new ArgumentException("Invalid type.");
        }
    }
}
