
/* [EN]
The Proxy pattern provides a surrogate or placeholder object to control access to another object. A proxy object is created to represent functionality of another object called subject. Proxy provides a surrogate for the real subject and controls access to it.

The Proxy pattern is used when:
* Access to the real subject should be restricted
* The real subject should be loaded on demand
* Additional functionality needs to be provided when accessing the subject
* The real subject exists remotely and needs remote access
*/

/* [TR]

Proxy pattern, bir nesnenin erişimini kontrol altına almak için kullanılan bir tasarım desenidir. Asıl nesneye erişmek için bir vekil nesne (proxy) kullanılır.

Proxy pattern şu durumlarda kullanılır:
* Asıl nesneye doğrudan erişimin kısıtlanması gerektiğinde
* Asıl nesnenin yüklenmesi pahalı bir işlemse ve gerektiğinde yüklenmesi gerekiyorsa
* Asıl nesnenin uzak bir yerde olduğu ve uzak erişim gerektirdiği durumlarda
* Asıl nesne ile ilgili ek işlemlerin yapılması gerektiğinde (logging, validation vb.)
*/


// Usage
ISubject subject = new Proxy();
subject.Request();


// Subject interface
public interface ISubject
{
    void Request();
}

// RealSubject class
public class RealSubject : ISubject
{
    public void Request()
    {
        Console.WriteLine("Operation");
    }
}

// Proxy class
public class Proxy : ISubject
{
    private RealSubject realSubject;

    public Proxy()
    {
        this.realSubject = new RealSubject();
    }

    public void Request()
    {

        Console.WriteLine("A request is made from the proxy.");

        if (this.realSubject != null)
            this.realSubject.Request();
    }
}


/* Output

A request is made from the proxy.
Operation

*/