/*
This code implements the Prototype design pattern in C# to create copies of resume objects without needing to create them from scratch.

It has two main classes - Resume and ResumeRepository.

The Resume class represents a resume for a job candidate. It has properties like CandidateName, Skills, and WorkExperience. The key part is the Clone() method,
which creates a copy of the Resume object using C#'s built-in MemberwiseClone() method. This allows copies of a Resume to be created easily.

The ResumeRepository class manages a dictionary of Resume objects, keyed by candidate name. Its constructor populates the dictionary with some sample Resume objects.

The main method GetResume() takes a candidate name, looks up the Resume object for that candidate in the dictionary, calls the Resume's Clone() method to create a copy, 
and returns the copied Resume object.

So in summary, this code allows Resume objects to be cloned instead of re-created from scratch every time. The ResumeRepository stores original Resume objects, 
and returns cloned copies of them when requested. This saves time and memory by re-using existing initialized Resume objects. The Prototype pattern provides an easy way 
in C# to implement cloning through the ICloneable interface and MemberwiseClone() method.

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




