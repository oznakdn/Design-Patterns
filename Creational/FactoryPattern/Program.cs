
/*
The purpose of this Factory Method pattern code is to create different types of log file objects without needing to specify the exact class. 
It achieves this by defining a LogFile abstract base class, concrete LogFile subclasses, and a LogFileFactory class.

The input is a LogType enum value like TextFile, XmlFile, or JsonFile specifying the desired log file type. The output is a LogFile object of the corresponding type.

The LogFileFactory class contains a CreateLogFile method that takes the LogType input. It uses a switch statement to determine which LogFile subclass to instantiate 
based on the LogType value. For example, if LogType.JsonFile is passed in, it will return a new JsonFile object.

This allows the client code to get a LogFile object without needing to know the specific class name or managing all the subclasses itself. 
The factory handles instantiating the right class based on the input.

The LogFile abstract base class defines the common Write method that concrete subclasses override to implement logging behavior specific to their type. 
This abstraction allows the factory to return the generic LogFile type to clients.

So in summary, the Factory Method pattern here encapsulates instantiation logic for different LogFile types, provides a simple LogType input, 
and returns LogFile objects without exposing concrete classes to the client. This makes it easy to add new LogFile types later without changing client code.

*/

// Client code
var log = LogFileFactory.CreateLogFile(LogType.JsonFile);
log.Write("Log message");


// LogType enum defines different types of log files
public enum LogType
{
    TextFile,
    XmlFile,
    JsonFile
}

// LogFile abstract base class 
public abstract class LogFile
{
    public abstract void Write(string message);

}

// Concrete LogFile classes
public class TextFile : LogFile
{
    public override void Write(string message)
    {
        Console.WriteLine($"Text: {message}");
    }
}

public class XmlFile : LogFile
{
    public override void Write(string message)
    {
        Console.WriteLine($"Xml: {message}");

    }
}

public class JsonFile : LogFile
{
    public override void Write(string message)
    {
        Console.WriteLine($"Json: {message}");
    }
}

// Factory class
public class LogFileFactory
{

    public static LogFile CreateLogFile(LogType type)
    {
        switch (type)
        {
            case LogType.TextFile:
                return new TextFile();
            case LogType.XmlFile:
                return new XmlFile();
            case LogType.JsonFile:
                return new JsonFile();
            default:
                throw new ArgumentException("Invalid log type");
        }
    }
}


