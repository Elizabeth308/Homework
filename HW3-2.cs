using System;
abstract class ArrayBase
{
    public abstract void CreateArray();
    
    public abstract void UserChoise();

    public abstract void PrintArray();

    public abstract void MiddleValue();
    
    protected ArrayBase(bool random = false)
    {
        if (!random)
        { 
            CreateArray();
        }
        else
        {
            UserChoise();
        }
    }
}


sealed class OneD:ArrayBase
{
   private int[] array;

   public override void CreateArray()
    {
        Console.WriteLine("Enter the length of your array (1 dimension)");
        int arrayLength = int.Parse(Console.ReadLine());
        array = new int[arrayLength];
        Random random1 = new Random();
        for (int i = 0; i < array.Length; i++)
        {
            int value = random1.Next(0, 1000);
            array[i] = value;
        }
    }
   
    public override void UserChoise()
    {
        Console.WriteLine("Enter the length of your array (1 dimension)");
        int arrayLength = int.Parse(Console.ReadLine());
        array = new int[arrayLength];
        Console.WriteLine("Please enter elements of your array: ");
        for(int i = 0; i < arrayLength; i++)
        {
           array[i] = int.Parse(Console.ReadLine());
        }
    }
    
    public OneD(bool random = false) : base (random)
    {

    }
    
    public override void PrintArray()
    {
        Console.WriteLine("Your array (one dimension): ");
        foreach (var item in array)
        { 
            Console.WriteLine(item);
        }
    }

    public override void MiddleValue()
    {
       int sum = 0;
       double MiddleVal = 0.0;
       int arrayLength = array.Length;
       for (int i = 0; i < arrayLength; i++)
       {
           sum += array[i];
       }
       MiddleVal = (double) sum/arrayLength;
       Console.WriteLine("Middle value of 1 dimensional array is " + MiddleVal);
    }
}


sealed class TwoD:ArrayBase
{
    private int[,] array;

    public override void CreateArray()
    {
        Console.WriteLine("Enter the length of the array (2 dimensions)");
        int arrayLength = int.Parse(Console.ReadLine());
        array = new int[arrayLength, arrayLength];
        Random random1 = new Random();
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for(int j = 0; j < array.GetLength(1); j++)
            {
                int value = random1.Next(0, 1000);
                array[i,j] = value;
            }
        }
        
    }

    public override void PrintArray()
    {
        Console.WriteLine("Your array (two dimensions): ");
        for (int i = 0; i < array.GetLength(0); i++)
        {   
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write(array[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    public TwoD(bool random = false) : base (random)
    {

    }
    
    public override void UserChoise()
    {
        Console.WriteLine("Enter the length of the array (2 dimensions)");
        int arrayLength = int.Parse(Console.ReadLine());
        array = new int[arrayLength, arrayLength];
        Console.WriteLine("Please enter elements of your array: ");
        for(int i = 0; i < arrayLength; i++)
        {
            for(int j = 0; j < arrayLength; j++)
            {
                array[i, j] = int.Parse(Console.ReadLine());
            }
        }
    }
    
    public override void MiddleValue()
    {
        int sum = 0;
        double MiddleVal = 0.0;
        int arrayLength = array.Length;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for(int j = 0; j < array.GetLength(1); j++)
            {
                sum += array[i, j];
            }
        }
        MiddleVal = (double) sum/arrayLength;
        Console.WriteLine("Middle value of 2 dimensional array is " + MiddleVal);
    }
}


sealed class IDKD:ArrayBase
{
    private int[][] array;
    
    public override void CreateArray()
    {
        Random random1 = new Random();
        Console.WriteLine("Enter the length of the array (how many arrays tht array will contain)");
        int arrayLength = int.Parse(Console.ReadLine());
        array = new int[arrayLength][];
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine("Enter the length of the array (jagged): ");
            int k  = int.Parse(Console.ReadLine());
            array[i] = new int[k];
            for(int j = 0; j < k; j++)
            {
                int value = random1.Next(0, 1000);
                array[i][j] = value;
            }
        }
    }

    public override void PrintArray()
    {
        Console.WriteLine("Your array (jagged): ");
        for (int i = 0; i < array.GetLength(0); i++)
        {   
            for (int j = 0; j < array[i].Length; j++)
            {
                Console.Write(array[i][j] + "\t");
            }
            Console.WriteLine();
        }
    }

    public IDKD(bool random = false) : base (random)
    {

    }
       
    public override void UserChoise()
    {
        Console.WriteLine("Enter the length of the array (how many arrays tht array will contain)");
        int arrayLength = int.Parse(Console.ReadLine());
        array = new int[arrayLength][];
        for(int i = 0; i < arrayLength; i++)
        {
            Console.WriteLine("Enter the length of the array: ");
            int k = int.Parse(Console.ReadLine());
            array[i] = new int[k];
            for(int j = 0; j < k; j++)
            {
                Console.WriteLine("Please enter element of your array: ");
               array[i][j] = int.Parse(Console.ReadLine());
            }
        }
    }
    
    public override void MiddleValue()
    {
        int sum = 0;
        double MiddleVal = 0.0;
        int count = 0;
        for (int i = 0; i < array.Length; i++)
        {
            int r = array[i].Length;
            for(int j = 0; j < r; j++)
            {
                sum += array[i][j];
                count ++;
            }
        }
        MiddleVal = (double) sum/count;
        Console.WriteLine("Middle value of jagged array is " + MiddleVal);
    }
}


class Program
{
    static void Main()
    {
        ArrayBase[] array = new ArrayBase[3];
        Console.WriteLine("If you want to fill your array with random numbers, type \"false\", if you want to fill it yourself, type \"true\"");
        bool userchoise = bool.Parse(Console.ReadLine());
        array[0] = new OneD(userchoise);
        array[1] = new TwoD(userchoise);
        array[2] = new IDKD(userchoise);
        foreach(var i in array)
        {
            i.PrintArray();
            i.MiddleValue();
        }
   }
}



