/* [EN]
The Memento pattern is a design pattern that allows us to save the state of an object and restore 
it later without exposing its internal structure or altering it. This pattern enables us to return 
to previous states of an object. 
 
For example, in a text editor application, the Memento pattern can be used for implementing undo and redo functionalities. 
This allows users to revert to previous states of the text or move forward as needed.
*/

/* [TR]
Memento pattern, bir nesnenin durumunu kaydedip daha sonra geri yüklememizi sağlayan bir tasarım desenidir. 
Bu desen, nesnenin durumunu dışarıya açıklamadan ve değiştirilmeden kaydetmeye olanak tanır. Bu sayede, 
nesnenin geçmiş durumlarına geri dönüş yapılabilir. 
 
Örneğin, bir metin düzenleyici uygulamasında kullanıcı bir metin parçasını düzenlerken, 
geri alma (undo) ve ileri alma (redo) işlemlerinde Memento pattern kullanılabilir. 
Bu sayede kullanıcı istediği zaman önceki metin durumlarına geri dönebilir veya ileri gidebilir. 
*/


// Usage

TextEditor editor = new TextEditor();
TextEditorHistory history = new TextEditorHistory();

editor.Text = "Hello, World!";
history.Memento = editor.Save();

editor.Text = "Goodbye, World!";
editor.Restore(history.Memento);


// Originator class
class TextEditor
{
    private string text;

    public string Text
    {
        get { return text; }
        set
        {
            Console.WriteLine("Current text: " + value);
            text = value;
        }
    }

    public TextMemento Save()
    {
        return new TextMemento(text);
    }

    public void Restore(TextMemento memento)
    {
        text = memento.Text;
        Console.WriteLine("Restored text: " + text);
    }
}

// Memento class
class TextMemento
{
    public string Text { get; }

    public TextMemento(string text)
    {
        Text = text;
    }
}

// Caretaker class
class TextEditorHistory
{
    public TextMemento Memento { get; set; }
}


/* Output

Current text: Hello, World!
Current text: Goodbye, World!
Restored text: Hello, World!

*/