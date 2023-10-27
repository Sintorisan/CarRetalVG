namespace CarRental.Common.Interfaces;

public interface IData
{
    int VehicleId { get; }
    int CustomerId { get; }

    IEnumerable<T> Get<T>(Func<T, bool>? predicate = null) where T : class;
    public T? GetSingle<T>(Func<T, bool> predicate) where T : class;

    public void Add<T>(T item) where T : class;
    public void Remove<T>(T item) where T : class;
}
