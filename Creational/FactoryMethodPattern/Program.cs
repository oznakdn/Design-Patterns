
/* [EN]

The factory method design pattern is a creational design pattern used for object creation.

In this pattern, a superclass defines an interface for creating objects, but leaves the choice of the concrete type to its subclasses. This allows using polymorphism for object creation.

The main benefits of the factory method pattern are:

* Subclasses can control the type of object created. This provides polymorphism for object creation.

* Object creation code is separated from business logic code.

* Adding new types is easy by simply adding a new subclass.

* Object creation code is centralized in a single location, following the single responsibility principle.

The factory method pattern is commonly used in object-oriented programming when subclasses are responsible for object creation. It is useful when polymorphism is needed for object creation.
*/

/* [TR]

Factory method pattern, alt sınıflar tarafından instantiate edilecek nesnelerin tipini superclass'a bırakan bir creational design pattern'dir. Bu sayede nesne yaratımı için polymorphism kullanılmış olur.

Factory method pattern'in ana faydaları:

* Alt sınıflar, üretilecek nesnenin tipini belirleyebilir. Böylece nesne yaratımı için polymorphism sağlanmış olur.

* Nesne yaratım kodu ile nesnenin kullanım kodu birbirinden soyutlanmış olur.

* Yeni tiplerin eklenmesi kolaylaşır. Yeni bir alt sınıf eklenerek yeni bir nesne tipi üretilebilir.

* Single responsibility prensibine uygun olarak nesne yaratma kodu tek bir yerde toplanmış olur.

Factory method pattern, nesne yönelimli programlamada yaygın olarak kullanılır. Özellikle alt sınıfların nesne üretiminden sorumlu olduğu durumlarda kullanışlıdır.
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


/* Output

File: Hello World!

*/