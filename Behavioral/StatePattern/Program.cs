/* [EN]
The State pattern is a design pattern that allows an object to alter its behavior when its internal state changes. 
This pattern enables an object to change its behavior based on its state. State pattern is useful for modeling state 
machines and managing behaviors that are dependent on the state of an object. 
 
For example, in an order management system where different actions need to be taken based on the state of an order 
(pending, preparing, shipped, etc.), the State pattern can be used. This way, appropriate actions can be automatically 
performed based on the state of the order object.
*/


/* [TR]
State pattern, bir nesnenin davranışlarını durumlarına göre değiştirmesini sağlayan bir tasarım desenidir. 
Bu desen, nesnenin iç durumunu değiştirerek farklı davranışlar sergilemesini sağlar. State pattern, durum 
makinelerini modellemek ve duruma bağlı davranışları yönetmek için kullanılır. 
 
Örneğin, bir sipariş yönetim sisteminde siparişin farklı durumlarına (beklemede, hazırlanıyor, sevk edildi vb.) 
göre farklı işlemler yapılması gerekiyorsa State pattern kullanılabilir. Bu sayede sipariş nesnesinin durumuna 
göre uygun işlemler otomatik olarak gerçekleştirilebilir. 
*/


// Usage
Order order = new Order();

order.ProcessOrder(); // Output: Order is pending. Waiting for processing.

order.SetState(new ShippedState());
order.ProcessOrder(); // Output: Order has been shipped to the customer.


// Context class
public class Order
{
    private OrderState currentState;

    public Order()
    {
        currentState = new PendingState();
    }

    public void SetState(OrderState state)
    {
        currentState = state;
    }

    public void ProcessOrder()
    {
        currentState.ProcessOrder(this);
    }
}

// State interface
public interface OrderState
{
    void ProcessOrder(Order order);
}

// Concrete states
public class PendingState : OrderState
{
    public void ProcessOrder(Order order)
    {
        Console.WriteLine("Order is pending. Waiting for processing.");
    }
}

public class ShippedState : OrderState
{
    public void ProcessOrder(Order order)
    {
        Console.WriteLine("Order has been shipped to the customer.");
    }
}


/* Output

Order is pending. Waiting for processing.
Order has been shipped to the customer.

*/