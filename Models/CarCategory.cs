using System.Collections.Generic;

namespace ExceptionTest.Models;

public class CarCategory
{
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<Car> Cars { get; set; }

    public CarCategory(int id, string name)
    {
        this.Id = id;
        this.Name = name;
    }

    public CarCategory Clone()
    {
        return this.MemberwiseClone() as CarCategory;
    }
}