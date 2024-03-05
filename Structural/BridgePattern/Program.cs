/* [EN]

The Bridge design pattern is a structural design pattern that separates abstraction from implementation.

Usage scenarios for the Bridge pattern:
* When we want the abstraction and implementation to be independently extensible
* When we are developing for multiple platforms and want platform specific code separated from abstract code
* When classes in a hierarchy should be isolated from implementation details
The Bridge pattern bridges the abstraction and the implementation allowing them to vary independently from each other.
*/

/* [TR]

Bridge design pattern, soyutlama ile uygulamanın birbirinden ayrılmasını sağlayan yapısal bir design pattern'dir.

Bridge pattern kullanım senaryoları:
* Soyutlama ile uygulamanın bağımsız şekilde değiştirilebilmesini istediğimizde
* Çoklu platformlarda uygulama geliştirirken platforma özgü kodların soyut kodlardan ayrılması gerektiğinde
* Bir hiyerarşideki sınıfların uygulama ayrıntılarından bağımsız olması gerektiğinde
Bridge pattern ile soyutlama ile uygulama arasında köprü kurulur, böylece ikisi birbirinden bağımsız olarak değiştirilebilir.
*/




// Usage
IRenderer rasterRenderer = new RasterRenderer();
Shape circle = new Circle(10, rasterRenderer);
circle.Draw(); // Renders using raster

IRenderer vectorRenderer = new VectorRenderer();
Shape square = new Square(20, vectorRenderer);
square.Draw(); // Renders using vectors



// Shape abstraction
public abstract class Shape
{
    // Reference to the implementor 
    protected IRenderer renderer;

    public Shape(IRenderer renderer)
    {
        this.renderer = renderer;
    }

    public abstract void Draw(); // Delegates drawing to implementor
}

// Concrete shapes
public class Circle : Shape
{
    private float radius;

    public Circle(float radius, IRenderer renderer) : base(renderer)
    {
        this.radius = radius;
    }

    public override void Draw()
    {
        renderer.RenderCircle(radius);
    }
}

public class Square : Shape
{
    private float side;

    public Square(float side, IRenderer renderer) : base(renderer)
    {
        this.side = side;
    }

    public override void Draw()
    {
        renderer.RenderSquare(side);
    }
}

// Renderer implementor interface
public interface IRenderer
{
    void RenderCircle(float radius);
    void RenderSquare(float side);
}

// Concrete implementors 
public class RasterRenderer : IRenderer
{
    public void RenderCircle(float radius)
    {
        Console.WriteLine($"Raster Circle: {radius}");
    }

    public void RenderSquare(float side)
    {
        Console.WriteLine($"Raster Square: {side}");

    }
}

public class VectorRenderer : IRenderer
{
    public void RenderCircle(float radius)
    {
        Console.WriteLine($"Vector Circle: {radius}");

    }

    public void RenderSquare(float side)
    {
        Console.WriteLine($"Vector Square: {side}");

    }
}


