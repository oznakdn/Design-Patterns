
/* [EN]

The Adapter pattern is a structural design pattern used to adapt incompatible interfaces to work together.

The intent of the Adapter pattern is to convert the interface of one or more classes into another interface that clients expect in order to allow them to work together.

Usage scenarios for the Adapter pattern:
* When an existing class needs to be used with an interface that is incompatible with its current interface
* When new functionality needs to be added to an existing class without changing its interface
* When incompatible classes need to work together and their interfaces cannot be changed
The Adapter pattern allows otherwise incompatible classes to work together by resolving their interface incompatibilities. This increases reusability of existing code.

*/

/* [TR]

Adapter pattern, uyumsuz arayüzleri birbiriyle uyumlu hale getirmek için kullanılan yapısal bir tasarım desenidir.

Adapter pattern'in amacı, birbirine uymayan ancak birlikte çalışması gereken sınıf ya da nesnelerin arayüzlerini uyumlulaştırarak onları birlikte kullanabilmektir.

Adapter pattern kullanım senaryoları:
* Varolan bir sınıfın arayüzünü istemcinin beklediği arayüze dönüştürmek gerektiğinde
* Bir sınıfın varolan arayüzünü bozmadan yeni özellikler eklemek istediğimizde
* Birlikte çalışması gereken ancak uyumsuz arayüzlere sahip sınıfları bir arada kullanmak istediğimizde
Adapter pattern, nesneler arasındaki uyumsuzluğu gidererek onların birlikte çalışabilmesini sağlar. Böylece varolan kodların yeniden kullanılabilirliğini arttırır.

*/


// Client
NewCalculator newCalculator = new CalculatorAdapter();
int result = newCalculator.Add(2, 3);
Console.WriteLine(result);



// The old interface that needs adapting
public interface OldCalculator
{
    int Calculate(int x, int y);
}

// The new interface we want to use 
public interface NewCalculator
{
    int Add(int x, int y);
    int Subtract(int x, int y);
    int Multiply(int x, int y);
    int Divide(int x, int y);
}

// The old implementation that only supports calculate
public class OldCalculatorImpl : OldCalculator
{
    public int Calculate(int x, int y)
    {
        return x + y;
    }
}

// The adapter that converts the old interface to the new one
public class CalculatorAdapter : NewCalculator
{
    private OldCalculator oldCalculator = new OldCalculatorImpl();

    public int Add(int x, int y)
    {
        return oldCalculator.Calculate(x, y);
    }

    public int Subtract(int x, int y)
    {
        return x - y;
    }

    public int Multiply(int x, int y)
    {
        return x * y;
    }

    public int Divide(int x, int y)
    {
        return x / y;
    }


}
