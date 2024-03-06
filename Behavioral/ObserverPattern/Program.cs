/* [EN]
The Observer pattern is a design pattern where an object, called the subject, 
maintains a list of its dependents, called observers, and notifies them of any 
state changes, usually by calling one of their methods. This pattern establishes 
a one-to-many relationship between a subject and multiple observers, allowing automatic 
updates when the subject's state changes. 
 
For example, in a stock market application, when the price of a stock changes, 
all the subscribed users should be notified with the updated price. 
This scenario can be implemented using the Observer pattern.
*/


/* [TR]
Observer pattern, bir nesnenin durumunda bir değişiklik olduğunda bağımlı olan diğer 
nesneleri otomatik olarak bilgilendiren bir tasarım desenidir. Bu desen, birincil nesnenin 
durumu değiştikçe bağımlı nesnelerin otomatik olarak güncellenmesini sağlar. Observer pattern, 
yayın/abone mantığına benzer bir yapıya sahiptir. 
 
Örneğin, bir haber sitesinde haberlerin yayınlanması durumunda abonelere otomatik olarak bildirim 
gönderilmesi için Observer pattern kullanılabilir. Bu sayede haberler güncellendiğinde aboneler anında
haberdar olabilir. 
*/


// Usage

StockMarket stockMarket = new StockMarket();
StockTrader trader1 = new StockTrader("Trader 1");
StockTrader trader2 = new StockTrader("Trader 2");

stockMarket.RegisterObserver(trader1);
stockMarket.RegisterObserver(trader2);

stockMarket.Price = 100.50m;


// Subject interface
public interface ISubject
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}

// Concrete subject
public class StockMarket : ISubject
{
    private List<IObserver> observers = new List<IObserver>();
    private decimal price;

    public decimal Price
    {
        get { return price; }
        set
        {
            price = value;
            NotifyObservers();
        }
    }

    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.Update(price);
        }
    }
}

// Observer interface
public interface IObserver
{
    void Update(decimal price);
}

// Concrete observer
public class StockTrader : IObserver
{
    private string name;

    public StockTrader(string name)
    {
        this.name = name;
    }

    public void Update(decimal price)
    {
        Console.WriteLine($"{name} - Price updated: {price}");
    }
}



/* Output

Trader 1 - Price updated: 100,50
Trader 2 - Price updated: 100,50

*/