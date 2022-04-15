namespace ExceptionTest.Models;

public class Car
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }

    public virtual CarCategory CarCategory { get; set; }

    public Car(int id, string name, int categoryId)
    {
        this.Id = id;
        this.Name = name;
        this.CategoryId = categoryId;
    }

    public Car Clone()
    {
        return this.MemberwiseClone() as Car;
    }
}