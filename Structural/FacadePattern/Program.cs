/* [EN]
The Facade pattern provides a simplified interface to a complex system of classes, library or framework. It exposes a higher-level interface that makes the subsystem easier to use.

The Facade pattern is used when:
* A simple interface is needed to access the complex system
* To reduce dependencies between system layers
* To improve readability and usability of the software API
*/


/* [TR]
Facade pattern, bir sistemin karmaşık alt sistemlerini, tek bir arayüz aracılığıyla basitleştirmek için kullanılan bir tasarım desenidir. Facade, alt sistemlerle etkileşimi kolaylaştırmak için sadeleştirilmiş bir arayüz sunar.

Facade pattern, aşağıdaki durumlarda kullanılır:
* Karmaşık bir sistemin alt sistemlerine doğrudan erişimin kolay olmadığı durumlarda
* Sistemin farklı katmanları arasında bağımlılığı azaltmak için
* Sistemi kullanan istemci için basit bir arayüz oluşturmak için
*/



// Client 
var converter = new VideoConverterFacade();
converter.ConvertVideo("movie.mp4", "avi");


// Facade
class VideoConverterFacade
{
    private AudioConverter audioConverter;
    private VideoConverter videoConverter;
    private BitrateConverter bitrateConverter;

    public VideoConverterFacade()
    {
        audioConverter = new AudioConverter();
        videoConverter = new VideoConverter();
        bitrateConverter = new BitrateConverter();
    }

    public void ConvertVideo(string fileName, string format)
    {
        var audio = audioConverter.ExtractAudio(fileName);
        var video = videoConverter.ConvertFormat(fileName, format);
        var bitrate = bitrateConverter.ReduceBitrate(fileName);
        Console.WriteLine(audio + "\n" + video + "\n" + bitrate);
    }
}

public class AudioConverter
{
    public string ExtractAudio(string fileName)
    {
        return $"Extracting audio from {fileName}";
    }
}

public class VideoConverter
{
    public string ConvertFormat(string fileName, string format)
    {
        return $"Converting video from {fileName} to {format}";
    }
}

public class BitrateConverter
{
    public string ReduceBitrate(string fileName)
    {
        return $"Reducing bitrate of {fileName}";
    }
}

/* Output

Extracting audio from movie.mp4       
Converting video from movie.mp4 to avi
Reducing bitrate of movie.mp4

*/