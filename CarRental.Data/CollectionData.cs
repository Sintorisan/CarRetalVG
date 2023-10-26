using CarRental.Common.Classes;
using CarRental.Common.Enums;
using CarRental.Common.Interfaces;
using System.Reflection;

namespace CarRental.Data;

public class CollectionData : IData
{



    private readonly List<IBooking> _bookings = new();
    private readonly List<ICustomer> _customers = new();
    private readonly List<IRentable> _rentables = new();


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
        return _rentables.Count == 0 ? 1 : _rentables.Max(r => r.Id) + 1;
    }
    public int CustomerId()
    {
        return _customers.Count == 0 ? 1 : _customers.Max(c => c.Id) + 1;
    }

    public IEnumerable<T> Get<T>(Func<T, bool>? predicate)
    {
        var collections = GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(f => f.FieldType == typeof(List<T>) && f.IsInitOnly)
                ?? throw new InvalidOperationException("Unsupported type");

        var value = collections.GetValue(this) ?? throw new InvalidDataException();
        var collection = ((List<T>)value).AsQueryable();
        if (predicate is null) return collection.ToList();

        return collection.Where(predicate).ToList();
    }

    public T? GetSingle<T>(Func<T, bool> predicate) where T : class
    {
        var collections = GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
               .FirstOrDefault(f => f.FieldType == typeof(List<T>) && f.IsInitOnly)
               ?? throw new InvalidOperationException("Unsupported type");

        var value = collections.GetValue(this) ?? throw new InvalidDataException();
        var collection = ((List<T>)value).AsQueryable();

        return collection.SingleOrDefault(predicate);
    }

    public void Add<T>(T item) where T : class
    {
        if (item == null)
            throw new ArgumentNullException("Invalid item");

        var collections = GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(f => f.FieldType == typeof(List<T>) && f.IsInitOnly)
                ?? throw new InvalidOperationException("Unsupported type");

        var value = collections.GetValue(this) ?? throw new InvalidDataException();
        var collection = ((List<T>)value);

        collection.Add(item);
    }

    public void Remove<T>(T item) where T : class
    {
        if (item == null)
            throw new ArgumentNullException("Invalid item");

        var collections = GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(f => f.FieldType == typeof(List<T>) && f.IsInitOnly)
                ?? throw new InvalidOperationException("Unsupported type");

        var value = collections.GetValue(this) ?? throw new InvalidDataException();
        var collection = ((List<T>)value);

        collection.Remove(item);
    }
}
