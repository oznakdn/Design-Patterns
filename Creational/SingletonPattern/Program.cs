
/*
The purpose of this Singleton class is to ensure only one instance of a class T can be created. It allows controlling access to a single shared instance across the application.

The Singleton class takes a generic type parameter T which specifies the type of object to make singleton. T must satisfy the constraint that it can be created using the 'new()' constructor.

The Instance method takes an instance of T as input and returns an instance of T as output. It first checks if the static _instance field is null, indicating no instance has been created yet. If so, it creates a new T using 'new()', assigns it to _instance, and also assigns the passed input instance to _instance. This overrides the newly created instance with the provided one. Finally, _instance is returned.

So the first time Instance is called, it will create a new T instance and return it. On subsequent calls, it will keep returning the same _instance field, ensuring only one instance of T exists. The input instance is only used the first time to initialize the singleton. After that, any passed instances are ignored.

This allows creating a singleton class where the first instance can be provided from the caller, while still ensuring future callers receive the same instance. The singleton instance is initialized lazily on first use.

*/


// Usage
var firstInstance = Singleton<Connection>.Instance(new Connection { ConnectionString = "firstConnection" });
var secodInstance = Singleton<Connection>.Instance(new Connection { ConnectionString = "secondConnection" });
Console.Write(firstInstance.ConnectionString + " " + secodInstance.ConnectionString);




/// <summary>
/// Singleton class that ensures only one instance of T can be created.
/// Uses lazy initialization to create instance on first call to Instance().
/// Allows passing initial instance on first call that will be returned.
/// Subsequent calls ignore passed instance and return same cached instance.
/// </summary>
public static class Singleton<T> where T : new()
{
    private static T _instance;
    private static object _lockObject = new();

    /// <summary>
    /// Returns the instance of T. If no instance exists, creates a new instance using the 'new()' constructor.
    /// On subsequent calls, returns the same instance.
    /// </summary>
    /// <param name="instance">An instance of T to be used as the initial instance. This instance will be returned if no other instance exists.</param>
    /// <returns>An instance of T.</returns>
    public static T Instance(T instance)
    {
        lock (_lockObject)
        {
            if (_instance is null)
            {
                _instance = new();
                _instance = instance;
            }
        }

        return _instance;
    }
}


public class Connection
{
    public string ConnectionString { get; set; }
}







/* Unit test

public class SingletonTests
{
    [Fact]
    public void Instance_WithNewInstance_ShouldReturnSameInstance()
    {
        var mock = new Mock<Connection>();
        var instance1 = Singleton<Connection>.Instance(mock.Object);
        var instance2 = Singleton<Connection>.Instance(mock.Object);

        Assert.Same(instance1, instance2);
    }

    [Fact]
    public void Instance_WithDifferentInstances_ShouldReturnFirstInstance()
    {
        var mock1 = new Mock<Connection>();
        var mock2 = new Mock<Connection>();
        var instance1 = Singleton<Connection>.Instance(mock1.Object);
        var instance2 = Singleton<Connection>.Instance(mock2.Object);

        Assert.Same(instance1, instance2);
    }

    class Connection
    {

    }
}




*/