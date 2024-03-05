/* [EN]

The Prototype design pattern is a creational design pattern that allows cloning objects, even complex ones, without coupling to their specific classes.

The Prototype pattern is used when:

* The classes to instantiate are specified at run-time
* Avoiding building a class hierarchy of factories that parallels the class hierarchy of products
* Instances of a class can have one of only a few different combinations of state. It may be more convenient to install a corresponding number of prototypes and clone them rather than instantiating the class manually each time.
In summary, the Prototype pattern provides a mechanism for cloning objects instead of instantiating them directly. This allows dynamically specifying the objects to create based on a prototype, without needing to know the concrete type.

*/

/* [TR]

Prototype tasarım deseni, nesnelerin, karmaşık olanlar da dahil, sınıflarına bağımlı olmadan klonlanmasını sağlayan yaratımsal bir tasarım desenidir.

Prototype deseni şu durumlarda kullanılır:

* Oluşturulacak sınıflar çalışma zamanında belirleniyorsa
* Ürün sınıf hiyerarşisine paralel bir fabrika sınıf hiyerarşisi oluşturmaktan kaçınmak için
* Bir sınıfın örneklerinin sadece birkaç farklı durum kombinasyonu olabiliyorsa. Bu durumda ilgili sayıda prototype oluşturup bunları klonlamak, her seferinde sınıfı manuel oluşturmaktan daha kullanışlı olabilir.
Özetle, Prototype deseni nesneleri doğrudan oluşturmak yerine klonlamak için bir mekanizma sağlar. Bu sayede prototype'a dayalı olarak çalışma zamanında oluşturulacak nesneleri dinamik belirleme imkanı sağlanır, somut tip bilinmesi gerekmez.

*/

// Usage
var repository = new ResumeRepository();

// Clone existing resumes from repository instead of creating new instances
var johnResume = repository.GetResume("JohnDoe");
var janeResume = repository.GetResume("JaneDoe");

// Make changes to cloned resumes
johnResume.Skills = "C#, ASP.NET";
janeResume.WorkExperience = "4 years";

// Original resumes in repository remain unchanged 
Console.WriteLine(repository.GetResume("JohnDoe").Skills); // .NET, Java
Console.WriteLine(repository.GetResume("JaneDoe").WorkExperience); // 3 years


public class Resume : ICloneable
{
    public string CandidateName { get; set; }
    public string Skills { get; set; }
    public string WorkExperience { get; set; }

    public object Clone()
    {
        return MemberwiseClone();
    }
}

public class ResumeRepository
{
    private Dictionary<string, Resume> resumes = new Dictionary<string, Resume>();

    public ResumeRepository()
    {
        // Add some sample resumes
        var resume1 = new Resume { CandidateName = "John Doe", Skills = ".NET, Java", WorkExperience = "5 years" };
        resumes.Add("JohnDoe", resume1);

        var resume2 = new Resume { CandidateName = "Jane Doe", Skills = "Python, JavaScript", WorkExperience = "3 years" };
        resumes.Add("JaneDoe", resume2);
    }

    public Resume GetResume(string key)
    {
        return resumes[key].Clone() as Resume;
    }
}




