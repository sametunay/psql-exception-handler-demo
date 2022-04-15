using ExceptionTest.Data;
using ExceptionTest.Extensions;
using ExceptionTest.Models;

namespace ExceptionTest.Services;

public class Service
{
    private readonly DbOperations _operations;

    public Service(DbOperations operations)
    {
        _operations = operations;
    }

    // DbUpdateException => PostgresExcetion => "Code" =>  
    public void Test()
    {
        try
        {
            // var category = new CarCategory(1, "SUV");
            // var car = new Car(1, "honda civic", 1);
            var existCategory = _operations.Get<CarCategory>(x => x.Id == 1);
            // _operations.Add(car);
            _operations.Remove(existCategory);
        }
        catch (Exception ex) { throw ex.Handle(); }
        finally
        {
            _operations.Clear<Car>();
            _operations.Clear<CarCategory>();
        }
    }
}