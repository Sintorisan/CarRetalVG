namespace CarRental.Common.Interfaces;

public interface IData
{
    int VehicleId();
    int CustomerId();

    IEnumerable<T> Get<T>(Func<T, bool>? predicate = null);
    public T? GetSingle<T>(Func<T, bool> predicate) where T : class;

    public void Add<T>(T item) where T : class;
    public void Remove<T>(T item) where T : class;
}
