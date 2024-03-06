/* [EN]
Command Pattern is a design pattern that replaces an object with an object that represents an operation.
This pattern makes it easier to wrap operations and perform those operations on an object. In this way
processes can communicate between objects and client code becomes more flexible.
 
For example, if different actions need to be performed when a button is clicked, Command Pattern can be used.
Each action can be assigned to a button by creating a Command object, and the relevant Command object can be run when the button is clicked.
*/

/* [TR]
Command Pattern, bir nesnenin bir işlemi temsil eden bir nesneyle değiştirilmesini sağlayan bir tasarım desenidir. 
Bu desen, işlemlerin sarmalanmasını ve bu işlemlerin bir nesne üzerinde gerçekleştirilmesini kolaylaştırır. Bu sayede 
işlemler nesneler arasında iletişim kurabilir ve istemci kodu daha esnek hale gelir. 
 
Örneğin, bir butonun tıklanması durumunda farklı işlemlerin gerçekleştirilmesi gerekiyorsa Command Pattern kullanılabilir. 
Her işlem bir Command nesnesi oluşturularak butona atanabilir ve buton tıklandığında ilgili Command nesnesi çalıştırılabilir. 
*/


// Usage
Receiver receiver = new Receiver();
ICommand command = new ConcreteCommand(receiver);
Invoker invoker = new Invoker();

invoker.SetCommand(command);
invoker.ExecuteCommand();


// Command interface
interface ICommand
{
    void Execute();
}

// Class that implements Command
class ConcreteCommand : ICommand
{
    private Receiver _receiver;

    public ConcreteCommand(Receiver receiver)
    {
        _receiver = receiver;
    }

    public void Execute()
    {
        _receiver.Action();
    }
}

// Class that receives and executes commands
class Invoker
{
    private ICommand _command;

    public void SetCommand(ICommand command)
    {
        _command = command;
    }

    public void ExecuteCommand()
    {
        _command.Execute();
    }
}

// The class that performs the operations
class Receiver
{
    public void Action()
    {
        Console.WriteLine("Receiver.Action() method worked.");
    }
}


/* Output

Receiver.Action() method worked.

*/