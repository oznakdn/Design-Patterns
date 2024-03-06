/* [EN]
The Strategy pattern is a design pattern that defines a family of algorithms, encapsulates each algorithm, 
and makes them interchangeable. This pattern allows the client to choose from different algorithms dynamically 
and reduces the dependency between objects. 
 
For example, in a payment processing application where different payment methods 
(credit card, bank transfer, cash on delivery, etc.) need to be implemented, 
the Strategy pattern can be used. This way, when we want to change the payment method, 
we only need to change the relevant strategy class.
*/


/* [TR]
Strategy pattern, bir algoritmayı bir nesne içine kapsülleyerek, bu algoritmayı değiştirmek istediğimizde 
nesnenin davranışını değiştirmemize olanak tanıyan bir tasarım desenidir. Bu desen, algoritmalar arasında 
dinamik olarak geçiş yapmayı sağlar ve nesneler arasındaki bağımlılığı azaltır. 
 
Örneğin, bir ödeme işlemi uygulamasında farklı ödeme yöntemlerinin (kredi kartı, havale, kapıda ödeme vb.) 
uygulanması durumunda Strategy pattern kullanılabilir. Bu sayede ödeme yöntemini değiştirmek istediğimizde 
sadece ilgili strateji sınıfını değiştirmemiz yeterli olacaktır.
*/

// Usage

PaymentProcessor processor = new PaymentProcessor(new CreditCardPaymentStrategy());
processor.ProcessPayment(100.50);

processor = new PaymentProcessor(new BankTransferPaymentStrategy());
processor.ProcessPayment(200.75);



// Strategy interface
public interface IPaymentStrategy
{
    void ProcessPayment(double amount);
}

// Concrete strategies
public class CreditCardPaymentStrategy : IPaymentStrategy
{
    public void ProcessPayment(double amount)
    {
        Console.WriteLine($"Paying {amount} TL with Credit Card.");
    }
}

public class BankTransferPaymentStrategy : IPaymentStrategy
{
    public void ProcessPayment(double amount)
    {
        Console.WriteLine($"Paying {amount} TL with Bank Transfer.");
    }
}

// Context
public class PaymentProcessor
{
    private IPaymentStrategy paymentStrategy;

    public PaymentProcessor(IPaymentStrategy strategy)
    {
        paymentStrategy = strategy;
    }

    public void ProcessPayment(double amount)
    {
        paymentStrategy.ProcessPayment(amount);
    }
}

/* Output

Paying 100,5 TL with Credit Card.
Paying 200,75 TL with Bank Transfer.

*/