


/*
The purpose of this Adapter Pattern code is to allow new code to interface with legacy code. It takes an old calculator interface that only supports a 
Calculate method and adapts it to a new calculator interface that supports Add, Subtract, Multiply, and Divide.

The OldCalculator interface represents the legacy code. It has a single Calculate method that takes two integers as input and returns their sum as an integer output.

The NewCalculator interface represents the new code. It has methods for Add, Subtract, Multiply, and Divide that also take two integers as input and return an integer result.

The CalculatorAdapter class is the adapter. It implements the NewCalculator interface so it can be used by new code. Internally, it holds an instance of the OldCalculatorImpl 
class which is the legacy implementation of the old interface.

When one of the methods on CalculatorAdapter is called, it simply delegates to the Calculate method of the OldCalculatorImpl instance. For example, 
when Add is called, it just calls Calculate on the old code, passing the two integers through. This allows the old legacy code to be reused and integrated 
with the new code through the adapter.

The main logic flow is:

1. New code calls a method on CalculatorAdapter like Add or Subtract, passing two integers
2. CalculatorAdapter delegates the call to Calculate on its OldCalculatorImpl instance
3. OldCalculatorImpl's Calculate adds the two integers and returns the result
4. CalculatorAdapter returns the result to the new code

So in summary, the Adapter Pattern code adapts an old interface to meet the needs of new code by wrapping the old implementation and converting calls between the interfaces. 
This allows legacy code to be reused with new code that expects a different interface.

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
