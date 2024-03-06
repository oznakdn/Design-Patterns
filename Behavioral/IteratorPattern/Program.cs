/* [EN]
Iterator pattern is a design pattern used to sequentially access the elements of a collection. 
This pattern separates the structure of the collection from the method of accessing its elements, 
thus hiding the internal structure of the collection and making it easier to access the elements. 
This way, when there is a change in the collection's structure, the changes can be made through 
the Iterator without affecting the user code. 
 
Iterator pattern is commonly used when iterating over the elements of a collection or accessing 
the elements sequentially is required. Especially when working with large data sets, using the 
iterator pattern can make data access and operations more organized. 
*/

/* [TR]
Iterator pattern, bir koleksiyonun elemanlarına sırayla erişmek için kullanılan bir tasarım desenidir. 
Bu desen, koleksiyonun yapısını ve elemanlarına erişim yöntemini birbirinden ayırarak, koleksiyonun 
iç yapısını gizler ve elemanlara erişimi kolaylaştırır. Bu sayede koleksiyonun yapısında bir değişiklik olduğunda, 
bu değişiklikler Iterator üzerinden yapılır ve kullanıcı kodunu etkilemez. 
 
Iterator pattern, genellikle bir koleksiyonun elemanları üzerinde döngü yapmak veya elemanlara sırayla erişmek gereken 
durumlarda kullanılır. Özellikle büyük veri setleri üzerinde işlem yaparken, iterator pattern kullanılarak veri erişimi 
ve işlemleri daha düzenli hale getirilebilir.
*/

// Usage
ConcreteAggregate aggregate = new ConcreteAggregate();
aggregate.AddItem("1");
aggregate.AddItem("2");
aggregate.AddItem("3");

IIterator iterator = aggregate.CreateIterator();

while (iterator.HasNext())
{
    Console.WriteLine(iterator.Next());
}


interface IIterator
{
    bool HasNext();
    object Next();
}

// Collection interface
interface IAggregate
{
    IIterator CreateIterator();
}

// Collection class
class ConcreteAggregate : IAggregate
{
    private List<object> items = new List<object>();

    public void AddItem(object item)
    {
        items.Add(item);
    }

    public IIterator CreateIterator()
    {
        return new ConcreteIterator(this);
    }

    public int Count()
    {
        return items.Count;
    }

    public object GetItem(int index)
    {
        return items[index];
    }
}

// Iterator class
class ConcreteIterator : IIterator
{
    private ConcreteAggregate aggregate;
    private int index = 0;

    public ConcreteIterator(ConcreteAggregate aggregate)
    {
        this.aggregate = aggregate;
    }

    public bool HasNext()
    {
        return index < aggregate.Count();
    }

    public object Next()
    {
        if (HasNext())
        {
            return aggregate.GetItem(index++);
        }
        else
        {
            return null;
        }
    }
}

/* Output

1
2
3

*/