
/* [EN]

The abstract factory pattern provides an interface for creating families of related or dependent objects without specifying their concrete classes. This pattern defines factories for abstract products and derives concrete factories from these abstract factories.

The main benefits of the abstract factory pattern are:

* Allows abstracting application code from concrete classes using abstract classes and interfaces. This means concrete classes can be easily changed without changing application code.

* Adding new product types just requires creating new abstract factories and concrete factories. Rest of the code does not need to change.

* Abstract factories facilitate working with related object families together.

This pattern is commonly used when creating sets of related objects that need to work together. For example, creating a GUI factory that abstracts away different GUI components.
*/



/* [TR]

Soyut fabrika deseni, ilgili veya bağımlı nesne ailelerini, onların somut sınıflarını belirtmeksizin üretmek için kullanılır. Bu desen, soyut ürünlerin fabrikalarını tanımlar ve somut fabrikaları bu soyut fabrikalardan türetir.

Soyut fabrika deseninin temel faydaları:

* Soyut sınıflar ve arayüzler kullanarak, uygulama kodunun somut sınıflardan soyutlanmasını sağlar. Böylece uygulama kodu değişmeden somut sınıflar kolayca değiştirilebilir.

* Yeni ürün türleri eklemek için yeni soyut fabrikalar ve somut fabrikalar oluşturmak yeterlidir. Kodun geri kalanı değiştirilmesi gerekmez.

* Soyut fabrikalar, ilgili nesne ailelerini birlikte çalıştırmayı kolaylaştırır.

Bu desen genellikle birbirine bağlı veya ilgili nesne ailelerini birlikte oluşturmak için kullanılır. Örneğin, farklı GUI bileşenlerini soyutlayan bir GUI fabrikası oluşturmak için kullanılabilir.
*/



// Client
Application application = new(new WinUIFactory());
application.Paint();


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

/* Output
WinButton Created
WinTextBox Created
*/