
/*
The purpose of this code is to create different logger objects based on the provided logger type, without having to specify the concrete implementation.

It takes as input a LoggerType enum value - either File or Database. Based on this input, it will create and return either a FileLogger or DatabaseLogger object.

The FileLogger and DatabaseLogger classes both implement the ILogger interface, which defines a Log method. This allows them to share a common interface while having 
different implementations.

The LoggerFactory class contains a static CreateLogger method that handles creating the appropriate logger object based on the LoggerType. 
It uses a switch statement to check the LoggerType and instantiate the matching logger class, returning it as an ILogger object.

So the key outputs are the logger objects - FileLogger or DatabaseLogger. The caller just needs to specify the desired LoggerType and they will get back a logger with 
the right implementation, without knowing the concrete class.

This allows swapping the different logger implementations easily by just changing the LoggerType, without having to modify the client code. 
The client only deals with the ILogger interface.

The Factory Method pattern encapsulates the object creation logic centrally in the LoggerFactory class. This abstracts away the concrete classes from the client. 
The pattern promotes loose coupling and encapsulation.

*/


// Usage
var logger = LoggerFactory.CreateLogger(LoggerType.File);
logger.Log("Hello World!");


public enum LoggerType
{
    File,
    Database
}

// Interface for different log types
public interface ILogger
{
    void Log(string message);
}

// Concrete implementation for file logger
public class FileLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"File: {message}");
    }
}

// Concrete implementation for database logger 
public class DatabaseLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"Database: {message}");
    }
}

// Factory class
public class LoggerFactory
{
    public static ILogger CreateLogger(LoggerType type)
    {
        switch (type)
        {
            case LoggerType.File:
                return new FileLogger();
            case LoggerType.Database:
                return new DatabaseLogger();
            default:
                throw new InvalidOperationException("Invalid logger type");
        }
    }
}


