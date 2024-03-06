/* [EN]
The Visitor pattern is a design pattern that allows adding new operations to objects without changing 
their structure. This pattern is used to perform different operations on objects and enables adding new 
functionality without changing the structure of objects. The Visitor pattern is typically used when we do 
not want to modify the structure of objects. 
 
For example, in a document processing application, the Visitor pattern can be used to perform different 
operations on objects of different document types. This way, when new document types are added, existing 
operations do not need to be modified.
*/


/* [TR]
Visitor pattern, nesnelerin yapısını değiştirmeden yeni operasyonlar eklemeyi sağlayan bir tasarım desenidir. 
Bu desen, nesneler üzerinde farklı işlemleri gerçekleştirmek için kullanılır ve nesnelerin yapısını değiştirmeden 
yeni işlevsellik eklenmesini sağlar. Visitor pattern genellikle nesnelerin yapısını değiştirmek istemediğimiz 
durumlarda kullanılır. 
 
Örneğin, bir belge işleme uygulamasında farklı belge tiplerindeki nesneler üzerinde farklı işlemler yapmak için 
Visitor pattern kullanılabilir. Bu sayede yeni belge tipleri eklenirken mevcut işlemleri değiştirmeye gerek kalmaz. 
*/


// Usage

Document document = new Document();
document.Attach(new TextElement { Text = "Hello, Visitor Pattern!" });
document.Attach(new ImageElement { ImagePath = "image.jpg" });

HtmlExportVisitor htmlExportVisitor = new HtmlExportVisitor();
document.Export(htmlExportVisitor);


// Element interface
public interface IElement
{
    void Accept(IVisitor visitor);
}

// Concrete elements
public class TextElement : IElement
{
    public void Accept(IVisitor visitor)
    {
        visitor.VisitTextElement(this);
    }

    public string Text { get; set; }
}

public class ImageElement : IElement
{
    public void Accept(IVisitor visitor)
    {
        visitor.VisitImageElement(this);
    }

    public string ImagePath { get; set; }
}

// Visitor interface
public interface IVisitor
{
    void VisitTextElement(TextElement element);
    void VisitImageElement(ImageElement element);
}

// Concrete visitor
public class HtmlExportVisitor : IVisitor
{
    public void VisitTextElement(TextElement element)
    {
        Console.WriteLine($"Exporting text element with text: {element.Text} to HTML");
    }

    public void VisitImageElement(ImageElement element)
    {
        Console.WriteLine($"Exporting image element with path: {element.ImagePath} to HTML");
    }
}

// Object structure
public class Document
{
    private List<IElement> elements = new List<IElement>();

    public void Attach(IElement element)
    {
        elements.Add(element);
    }

    public void Export(IVisitor visitor)
    {
        foreach (var element in elements)
        {
            element.Accept(visitor);
        }
    }
}


/* Output

Exporting text element with text: Hello, Visitor Pattern! to HTML
Exporting image element with path: image.jpg to HTML

*/