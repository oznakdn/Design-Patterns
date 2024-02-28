/* What is
The Bridge pattern is a structural design pattern that decouples an abstraction from its implementation so that the two can vary independently.

Some key characteristics and usage of the Bridge pattern:

* It separates an abstract concept (e.g. shape) from its implementation (e.g. rendering). This allows the two to vary independently.

* It does this by putting the abstraction and implementation in separate class hierarchies. There is an abstraction hierarchy (Shape) and an implementor hierarchy (IRenderer).

* A reference to the implementation is stored in the abstraction. The Shape class stores a reference to IRenderer.

* Concrete classes derive from the abstraction (Circle, Square) and implementor (RasterRenderer, VectorRenderer) hierarchies.

* Communication between abstraction and implementor happens via an interface known to both (IRenderer interface).

* This pattern is useful when you want to decouple abstraction from implementation so that the two can be developed and extended independently.

* It avoids a multiplicative explosion of classes when extending abstractions and implementations independently.

* Examples of using the Bridge pattern:

  * Rendering shapes in different ways (vector, raster)

  * Platform independent GUI (abstraction) that can run on multiple OS (implementations)

  * Device drivers (abstraction) that can work with different devices (implementations)

So in summary, the Bridge pattern separates out abstraction from implementation details via interfacing and composition, allowing them to vary independently.

*/


/* Code description
This code demonstrates the Bridge design pattern, which decouples an abstraction from its implementation so that the two can vary independently.

The key purpose is to separate the abstract concept of a shape from the implementation details of how it is rendered. This allows us to create different 
shape types (like Circle and Square) that can be rendered in different ways (raster or vector) without having to create a class for every combination.

The main abstraction is the Shape class, which represents a shape conceptually without any rendering details. It takes an IRenderer implementor object in its constructor, 
storing it in the renderer field. The Draw method is defined abstractly to delegate the actual rendering to the implementor object.

The Circle and Square classes extend Shape as concrete shape implementations. They define radius and side fields to represent their shape data. 
In the constructor they call the base Shape constructor, passing a renderer. The override of Draw calls methods on the renderer to render the shape.

The IRenderer interface defines the API for concrete renderers. It has RenderCircle and RenderSquare methods the shapes will call. 
RasterRenderer and VectorRenderer implement this interface with specific rendering logic for raster and vector graphics respectively.

In summary, the Bridge pattern here allows us to define shapes and renderers independently so we can combine circles/squares with raster/vector 
without exploding class combinations. The Shape abstraction delegates to the IRenderer implementation via its renderer field. This separates the 
high-level shape concept from the implementation detail of rendering.

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


