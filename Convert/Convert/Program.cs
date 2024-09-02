public class CustomConverter
{
    public void Convert(int a, out string resultString) => resultString = a.ToString();
    public void Convert(object a, out string resultString) => resultString = a.ToString();

    public void Convert(string a, out int resultInt)
    {
        try
        {
            resultInt = int.Parse(a);

        }
        catch (OverflowException)
        {
            Console.WriteLine("Число не попадает в INT32");
            resultInt = 0;
        }
        catch(Exception e) {Console.WriteLine(e.Message); resultInt = -1;}
    }

}

class Program
{
    static void Main(string[] args)
    {
        CustomConverter convert = new CustomConverter();

        string resultString;
        convert.Convert(100, out resultString);
        Console.WriteLine($"{resultString} \n");

        convert.Convert(convert, out resultString);
        Console.WriteLine($"{resultString} \n");

        int resultInt;
        convert.Convert("10",out resultInt);
        Console.WriteLine($"{resultInt} \n");

        convert.Convert("10000000000000000000000000000", out resultInt);
        Console.WriteLine($"{resultInt} \n");


        convert.Convert("#", out resultInt);
        Console.WriteLine($"{resultInt} \n");

        Console.ReadKey();
    }
}