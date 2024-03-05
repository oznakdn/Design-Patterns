/* [EN]
The Decorator design pattern is used to dynamically modify the behavior of an existing class. The Decorator class implements the interface of the class it decorates and enhances its behavior by adding new functionality.

The Decorator pattern is commonly used in scenarios where:
* You want to dynamically extend a class behavior without using inheritance
* You want to add new features to existing classes
* You want to modify the behavior of classes at runtime
*/

/* [TR]
Decorator design pattern, varolan bir sınıfın davranışlarını dinamik olarak değiştirmek için kullanılan bir design pattern'dir. Decorator sınıfı, sarmaladığı sınıfın arayüzünü implemente eder ve istenilen davranışı ekleyerek sınıfı genişletir.

Decorator pattern genellikle aşağıdaki senaryolarda kullanılır:
* Bir sınıfın davranışlarını kalıtım kullanmadan dinamik olarak genişletmek istediğimizde
* Varolan sınıflara yeni özellikler eklemek istediğimizde
* Sınıfların davranışlarını çalışma zamanında değiştirmek istediğimizde
*/


// Usage
IShape circle = new Circle();
IShape redCircle = new RedShapeDecorator(circle);

redCircle.Draw();



// The interface
public interface IShape
{
    void Draw();
}

// Concrete class implementing the interface
public class Circle : IShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing a circle");
    }
}

// Decorator class implementing the interface
public class RedShapeDecorator : IShape
{
    private IShape shape;

    public RedShapeDecorator(IShape shape)
    {
        this.shape = shape;
    }

    public void Draw()
    {
        shape.Draw();
        Console.WriteLine("Adding red border");
    }
}


/* Output: 

Drawing a circle 
Adding red border

*/