/* [EN]
The Mediator pattern is a design pattern that facilitates communication between objects through a mediator object. 
This pattern aims to reduce tight coupling between objects, creating a more flexible and maintainable structure. 
The Mediator pattern is commonly used in systems with complex interactions. 
 
For example, in a chat application, the Mediator pattern can be used to allow different users to communicate with each other. 
This way, each user can communicate through a mediator object instead of directly accessing other users.
*/

/* [TR]
Mediator pattern, bir nesne aracılığıyla nesneler arasındaki iletişimi kolaylaştıran bir tasarım desenidir. 
Bu desen, nesneler arasındaki sıkı bağımlılıkları azaltarak daha esnek ve bakımı kolay bir yapı oluşturmayı hedefler. 
Mediator pattern genellikle karmaşık etkileşimlerin olduğu sistemlerde kullanılır. 

Örneğin, bir chat uygulamasında farklı kullanıcıların birbiriyle iletişim kurmasını sağlamak için Mediator pattern kullanılabilir. 
Bu şekilde, her kullanıcı doğrudan diğer kullanıcılara erişmek yerine bir aracı (Mediator) üzerinden iletişim kurabilir. 
*/



// Usage

IChatMediator mediator = new ChatMediator();
IUser user1 = new User(mediator, "Alice");
IUser user2 = new User(mediator, "Bob");

user1.SendMessage("Hello, Bob!");
user2.SendMessage("Hi, Alice!");


// Mediator interface
public interface IChatMediator
{
    void SendMessage(string message, IUser user);
}

// Concrete mediator
public class ChatMediator : IChatMediator
{
    public void SendMessage(string message, IUser user)
    {
        Console.WriteLine($"{user.Name} sent a message: {message}");
    }
}

// Colleague interface
public interface IUser
{
    string Name { get; }
    void SendMessage(string message);
    void ReceiveMessage(string message);
}

// Concrete colleague
public class User : IUser
{
    private IChatMediator mediator;
    public string Name { get; private set; }

    public User(IChatMediator mediator, string name)
    {
        this.mediator = mediator;
        this.Name = name;
    }

    public void SendMessage(string message)
    {
        mediator.SendMessage(message, this);
    }

    public void ReceiveMessage(string message)
    {
        Console.WriteLine($"{Name} received a message: {message}");
    }
}


/* Output

Alice sent a message: Hello, Bob!
Bob sent a message: Hi, Alice!

*/