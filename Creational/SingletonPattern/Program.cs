
/* [EN]

The Singleton design pattern ensures that only one instance of a class is created and provides global access to that instance. It provides a single shared instance across the application and restricts instantiation of the class to only one object.

The Singleton pattern is used when:
* Only one instance of a class is needed across the application
* Restricted access to a single shared resource is needed
* A single instance needs to be accessed globally
* The class needs to be extensible through subclasses but clients should not be able to instantiate subclasses

The key aspects of the Singleton pattern are:
* A static method that returns the singleton instance
* A private constructor to restrict instantiation
* Lazy initialization of the singleton instance

The Singleton pattern falls under the Creational design pattern category. It provides a mechanism to access a shared resource in a controlled manner.

*/

/* [TR]

Singleton design pattern, bir sınıfın yalnızca tek bir örneğinin oluşturulmasını ve bu örneğe global erişim sağlanmasını amaçlar.

Singleton pattern şu durumlarda kullanılır:
* Uygulama genelinde bir sınıfın yalnızca tek örneğine ihtiyaç duyulduğunda
* Tek bir paylaşılan kaynağa kısıtlı erişim gerektiğinde
* Tek bir örneğin global olarak erişilmesi gerektiğinde
* Bir sınıfın alt sınıflar yoluyla genişletilebilir olması ancak istemcilerin alt sınıfları örnekleyememesi gerektiğinde

Singleton pattern'in temel özellikleri:
* Singleton örneğini döndüren static bir yöntem
* Örneklenmeyi kısıtlayan private bir constructor
* Singleton örneğinin lazy initialization'ı

Singleton pattern, Creational design pattern kategorisinde yer alır. Kontrollü bir şekilde paylaşılan bir kaynağa erişim mekanizması sağlar.


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



