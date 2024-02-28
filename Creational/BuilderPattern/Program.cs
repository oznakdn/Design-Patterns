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



/*

The purpose of this Builder Pattern code is to allow creating different configurations of Car objects without needing to specify all the details upfront. 
It achieves this by using a CarBuilder class.

The Car class represents a car object. It has properties like Id, Brand, Model, Color and MaxSpeed. The key thing is it has a private constructor, so a Car object 
can only be created through the static Create method.

The Create method takes an instance of the CarBuilder class. It creates a new Car instance and sets the Id property to a new random GUID. Then it returns this Car object.

The CarBuilder class has a Car property to hold the Car it is building. It has methods like SetBrand, SetModel etc that allow setting the different properties on the Car. 
Each method returns the CarBuilder instance so they can be chained.

To use this, first an instance of CarBuilder is created. Then the Create method is called passing the builder to make a new Car. The builder methods are used to set the properties.

This allows creating different Car configurations by calling Create with the same builder instance. The builder is reset each time to build a new Car. We don't need to specify 
all details upfront.

The key benefit is the client code can focus on building the object through a fluent interface. The complex construction logic is hidden inside the builder. This results in 
cleaner client code and allows varying the internal construction logic later if needed.

So in summary, the Builder pattern here encapsulates the construction process allowing creating different Car configurations through a simple builder interface. It separates
the complex construction code from the clean client code.


*/


/* Unit tests

[Fact]
    public void Create_WithBuilder_SetsId()
    {
        
        var builder = new CarBuilder();

        
        var car = Car.Create(builder);

        
        Assert.NotNull(car.Id);
    }

    [Fact]
    public void SetBrand_SetsBrand()
    {
        
        var builder = new CarBuilder();

        
        builder.SetBrand("Toyota");

        
        Assert.Equal("Toyota", builder.Car.Brand);
    }

    [Fact]
    public void SetModel_SetsModel()
    {
         
        var builder = new CarBuilder();

        
        builder.SetModel("Camry");

        
        Assert.Equal("Camry", builder.Car.Model);
    }

    [Fact]
    public void SetMaxSpeed_SetsMaxSpeed()
    {
        
        var builder = new CarBuilder();

       
        builder.SetMaxSpeed(220);

    
        Assert.Equal(220, builder.Car.MaxSpeed);
    }

    [Fact]
    public void SetColor_SetsColor()
    {
        var builder = new CarBuilder();

        builder.SetColor(Color.Red);

        Assert.Equal("Red", builder.Car.Color);
    }

    [Fact]
    public void WriteToConsole_WritesCarDetails()
    {
    
        var builder = new CarBuilder()
            .SetBrand("Honda")
            .SetModel("Civic")
            .SetMaxSpeed(240)
            .SetColor(Color.Blue);

        
        builder.WriteToConsole();
    }


*/

