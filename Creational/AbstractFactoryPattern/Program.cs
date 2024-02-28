
/*
The purpose of this code is to provide an interface for creating related objects without specifying their concrete classes. It allows creating different 
types of objects (buttons and textboxes) from different factories (WinUIFactory and WebUIFactory), while keeping the client code independent of the concrete classes.

The IUIFactory interface declares factory methods for creating buttons (CreateButton) and textboxes (CreateTextBox). The WinUIFactory and WebUIFactory classes 
implement IUIFactory and provide concrete implementations of the factory methods, creating Win/Web versions of buttons and textboxes respectively.

The IButton and ITextBox interfaces declare method signatures for all buttons and textboxes. The WinButton, WebButton, WinTextBox and WebTextBox classes implement 
these interfaces with platform-specific implementations.

The client Application class uses IUIFactory and the abstract interfaces IButton and ITextBox to create and work with buttons and textboxes through their interfaces, 
without caring about the concrete classes. It takes an IUIFactory object in the constructor, calls its factory methods to create buttons and textboxes, and interacts 
with them through their interfaces.

This allows the client code to work with different types of buttons and textboxes from different factories, without changes to the client code itself. 
The factory objects encapsulate the concrete classes and instantiate the appropriate ones as needed.

The key benefit is that the client code is decoupled from the concrete classes and only depends on abstractions. This makes it easier to implement new types 
of factories and products without changing the client code. It follows the open/closed principle - open for extension but closed for modification.

*/



// Client
Application application = new(new WinUIFactory());
application.Paint();

/* Output
WinButton Created
WinTextBox Created
*/


// The abstract factory interface declares a set of methods for creating abstract products
interface IUIFactory
{
    IButton CreateButton();
    ITextBox CreateTextBox();
}

// Concrete factory implements the abstract factory interface 
// and implements the factory methods to create concrete products
class WinUIFactory : IUIFactory
{
    public IButton CreateButton()
    {
        return new WinButton();
    }

    public ITextBox CreateTextBox()
    {
        return new WinTextBox();
    }
}

// Another concrete factory
class WebUIFactory : IUIFactory
{
    public IButton CreateButton()
    {
        return new WebButton();
    }

    public ITextBox CreateTextBox()
    {
        return new WebTextBox();
    }
}

// Abstract product interfaces declare methods all products will implement
interface IButton
{
    void Paint();
}

interface ITextBox
{
    void Draw();
}

// Concrete products implement the product interfaces
class WinButton : IButton
{
    public void Paint()
    {
        Console.WriteLine("WinButton Created");
    }
}

class WebButton : IButton
{
    public void Paint()
    {
        Console.WriteLine("WebButton Created");
    }
}

class WinTextBox : ITextBox
{
    public void Draw()
    {
        Console.WriteLine("WinTextBox Created");
    }
}

class WebTextBox : ITextBox
{
    public void Draw()
    {
        Console.WriteLine("WebTextBox Created");
    }
}

// Client code uses the abstract interfaces to work with products
class Application
{
    private IButton button;
    private ITextBox textBox;

    public Application(IUIFactory factory)
    {
        button = factory.CreateButton();
        textBox = factory.CreateTextBox();
    }

    public void Paint()
    {
        button.Paint();
        textBox.Draw();
    }
}