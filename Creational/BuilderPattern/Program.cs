using System.Text;



CarBuilder builder = new CarBuilder();

Car mustang = Car.Create(builder);
 builder.SetBrand("Ford")
 .SetModel("Mustang")
 .SetMaxSpeed(320)
 .SetColor(Color.White)
 .WriteToConsole();

 Car focus = Car.Create(builder);
 builder.SetBrand("Ford")
 .SetModel("Focus")
 .SetMaxSpeed(230)
 .SetColor(Color.Gray)
 .WriteToConsole();

/*Output

ID: a381651d-2f41-4cd7-87ad-0a0437a37d95
Brand: Ford
Model: Mustang
Color: White
Speed: 320

ID: 4bb86b31-9634-49db-8e7b-9e98176f94a9
Brand: Ford
Model: Focus
Color: Gray
Speed: 230

*/


class Car
{
    public string Id {get;private set;}
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public int MaxSpeed { get; set; }
    
    private Car(){}

    public static Car Create(CarBuilder carBuilder)
    {
        carBuilder.Car = new Car();
        carBuilder.Car.Id = Guid.NewGuid().ToString();
        return carBuilder.Car;
    }

}


class CarBuilder
{
    public Car Car {get;set;}
    public CarBuilder SetBrand(string brand)
    {
        Car.Brand = brand;
        return this;
    }

    public CarBuilder SetModel(string model)
    {
        Car.Model = model;
        return this;
    }

    public CarBuilder SetMaxSpeed(int speed)
    {
        Car.MaxSpeed = speed;
        return this;
    }

    public CarBuilder SetColor(Color color)
    {
        Car.Color = color.ToString();
        return this;
    }

    public CarBuilder WriteToConsole()
    {
        var result = new StringBuilder();
        result.AppendLine($"ID: {Car.Id}");

        if(!string.IsNullOrEmpty(Car.Brand))
        {
            result.Append($"Brand: {Car.Brand}\n");
        }

        if(!string.IsNullOrEmpty(Car.Model))
        {
            result.Append($"Model: {Car.Model}\n");
        }

        if(!string.IsNullOrEmpty(Car.Color))
        {
            result.Append($"Color: {Car.Color}\n");
        }

         if(Car.MaxSpeed > 0)
        {
            result.Append($"Speed: {Car.MaxSpeed}\n");
        }

        Console.WriteLine(result.ToString());
        return this;
    }

}

enum Color
{
    Black,
    White,
    Gray,
    Blue,
    Red,
    Green
}






