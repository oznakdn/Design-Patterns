/* [EN]
The Chain of Responsibility pattern is used to search for the appropriate handler in a chain to handle a request.

In this pattern, a request is passed along a chain of handlers and each handler decides either to process the request or pass it on to the next handler in the chain. This way appropriate handlers to handle the request are searched for in a chain.

The Chain of Responsibility pattern is used when:
* Multiple objects need to handle a request
* We don't know which handler will handle a request
* To define an order to handle requests
*/

/* [TR]
Chain of Responsibility deseni, bir istek için uygun işleyiciyi zincirleme olarak aramak için kullanılır.

Bu desende istek bir zincir boyunca iletilir ve her işleyici istek üzerinde işlem yapmaya karar verir ya da sonraki işleyiciye iletir. Bu sayede istekleri işleyecek uygun işleyiciler zincirleme olarak aranmış olur.

Zincirleme Sorumluluk deseni şu durumlarda kullanılır:
* Birden fazla nesnenin bir isteği işlemesini sağlamak için
* Hangi işleyicinin bir isteği işleyeceğini bilmiyorsak
* İstekleri işleyecek işleyicilerin sıralamasını tanımlamak için
*/



// Usage
var handler1 = new ConcreteHandler1();
var handler2 = new ConcreteHandler2();

handler1.SetSuccessor(handler2);

var request = new Request { RequestType = "Type2" };
handler1.HandleRequest(request);



public abstract class Handler
{
    protected Handler successor;

    public void SetSuccessor(Handler successor)
    {
        this.successor = successor;
    }

    public abstract void HandleRequest(Request request);
}

public class Request
{
    public string RequestType { get; set; }
}

public class ConcreteHandler1 : Handler
{
    public override void HandleRequest(Request request)
    {
        if (request.RequestType == "Type1")
        {
            Console.WriteLine("Request handle");
        }
        else
        {
            successor?.HandleRequest(request);
        }
    }
}

public class ConcreteHandler2 : Handler
{
    public override void HandleRequest(Request request)
    {
        if (request.RequestType == "Type2")
        {
            Console.WriteLine("Request handle");
        }
        else
        {
            successor?.HandleRequest(request);
        }
    }
}

/* Output

Request handle

*/