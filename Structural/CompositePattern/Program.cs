
/* [EN]

The Composite design pattern is a structural pattern that allows composing objects into tree structures to represent part-whole hierarchies. It allows clients to treat both individual objects (leaf nodes) and compositions of objects (composite nodes) uniformly.

Some key characteristics and usage of the Composite pattern:

* It defines an abstract Component class that represents both primitives (leaves) and compositions (composites). This enables uniform interaction with both types.

* Composite nodes usually contain child Component nodes through methods like Add, Remove, GetChild etc.

* The key operation(s) that can be applied recursively on both primitives and composites are defined in the Component interface.

* Clients can treat all nodes uniformly via the Component interface without worrying about concrete classes.

The Composite pattern is useful when:

* You need to represent part-whole or hierarchical relationships between objects. For example, folders and files in a file system.

* You want the client code to treat primitive and composite objects in the same way, ignoring the differences in their structure.

* You need to apply operations recursively over a tree structure of objects made of primitives and composites.

It is used extensively in UI libraries to build complex widgets from simple ones. Other examples include representing task decompositions, mathematical expressions, XML/HTML elements etc.

The key advantage is the client handles primitives and compositions through the same interface without coupling to concrete classes. It simplifies the client code. The disadvantages are the increased complexity in the library code and making some operations possibly harder, like ordering all nodes.

*/


/* [TR]

Composite tasarım deseni, nesneleri ağaç yapıları halinde birleştirerek parça-bütün hiyerarşilerini temsil etmeye yarayan yapısal bir tasarım desenidir. Bu desen, hem bireysel nesnelere (yaprak düğümler) hem de nesne kompozisyonlarına (bileşik düğümler) aynı şekilde davranılmasına izin verir.

Composite deseninin bazı temel özellikleri ve kullanım alanları:

* Soyut bir Component sınıfı tanımlar, hem yaprak nesneleri hem de bileşik nesneleri temsil eder. Bu sayede her ikisiyle de aynı şekilde etkileşim kurulabilir.

* Bileşik düğümler genellikle Add, Remove, GetChild gibi metodlar aracılığıyla çocuk Component nesnelerini içerir.

* Component arayüzünde, hem yaprak hem de bileşik nesnelere rekürsif olarak uygulanabilecek anahtar operasyon(lar) tanımlanır.

* İstemciler, somut sınıflarla ilgilenmeksizin Component arayüzü üzerinden tüm düğümlere aynı şekilde davranabilir.

Composite deseni şu durumlarda kullanışlıdır:

* Nesneler arasında parça-bütün veya hiyerarşik ilişkileri temsil etmek gerekir. Örneğin, bir dosya sistemindeki klasörler ve dosyalar.

* İstemci kodunun yaprak ve bileşik nesneleri arasındaki farklılıkları gözardı ederek aynı şekilde davranması istenir.

* Bir yaprak ve bileşik nesnelerden oluşan ağaç yapısı üzerinde operasyonları rekürsif olarak uygulamak gerekir.

Kullanım alanlarına UI kütüphanelerinde karmaşık widget'lar oluşturmak, görev ayrıştırmaları, matematiksel ifadeler, XML/HTML elemanları temsil etmek örnek verilebilir.

Anahtar avantajı, istemcinin somut sınıflara bağımlı olmadan yaprak ve bileşiklerle aynı arayüz üzerinden etkileşim kurmasını sağlamasıdır. İstemci kodunu basitleştirir. Dezavantajları ise kütüphane kodunda artan karmaşıklık ve bazı operasyonları zorlaştırabilmesidir.
*/




// Usage
var root = new Folder("root");
root.Add(new File("file1"));

var usr = new Folder("usr");
usr.Add(new File("file2"));
usr.Add(new File("file3"));
root.Add(usr);

root.Print(1);

// The component interface 
public interface IFileSystemItem
{
    void Print(int depth);
}

// The leaf nodes
public class File : IFileSystemItem
{
    public string Name { get; set; }

    public File(string name)
    {
        Name = name;
    }

    public void Print(int depth)
    {
        Console.WriteLine(new String('-', depth) + Name);
    }
}

// The composite nodes
public class Folder : IFileSystemItem
{
    public string Name { get; }
    private List<IFileSystemItem> children = new List<IFileSystemItem>();

    public Folder(string name)
    {
        Name = name;
    }

    public void Add(IFileSystemItem component)
    {
        children.Add(component);
    }

    public void Remove(IFileSystemItem component)
    {
        children.Remove(component);
    }

    public void Print(int depth)
    {
        Console.WriteLine(new String('-', depth) + Name);

        // recursively print child nodes
        foreach (var child in children)
            child.Print(depth + 2);
    }
}



/* Output

-root
---file1
---usr
-----file2
-----file3

*/