using System;
abstract class ArrayBase
{
    public abstract void CreateArray();

    public abstract void PrintArray();

    public abstract void MiddleValue();
}


sealed class OneD:ArrayBase
{
   private int[] array;

   public override void CreateArray()
   {
       Console.WriteLine("Enter the length of your array (1 dimension)");
       array = new int[int.Parse(Console.ReadLine())];
       Random random = new Random();
       for (int i = 0; i < array.Length; i++)
       {
           int value = random.Next(0, 1000);
           array[i] = value;
       }
   }
    public OneD(int arrayLength, bool random = false)
    {
        if (!random)
        { 
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                int value = random.Next(0, 1000);
                array[i] = value;
            }
        }
        else
        {
            Console.WriteLine("Please enter elements of your array: ");
            array = new int[arrayLength];
           for(int i = 0; i < arrayLength; i++)
           {
               array[i] = int.Parse(Console.ReadLine());
           }
        }
    }
    public override void PrintArray()
    {
        Console.WriteLine("Your array: ");
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
        Random random = new Random();
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for(int j = 0; j < array.GetLength(1); j++)
            {
                int value = random.Next(0, 1000);
                array[i,j] = value;
            }
        }
    }

    public override void PrintArray()
    {
        Console.WriteLine("Your array: ");
        for (int i = 0; i < array.GetLength(0); i++)
        {   
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write(array[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    public TwoD(int arrayLength, bool random = false)
    {
        if (!random)
        { 
            Random random = new Random();
           array = new int[arrayLength, arrayLength];
           for (int i = 0; i < arrayLength; i++)
           {
                for(int j = 0; j < arrayLength; j++)
                {
                    int value = random.Next(0, 1000);
                    array[i,j] = value;
                }
           }
        }
        else
        {
            Console.WriteLine("Please enter elements of your array: ");
            array = new int[arrayLength, arrayLength];
            for(int i = 0; i < arrayLength; i++)
            {
                for(int j = 0; j < arrayLength; j++)
                {
                   array[i, j] = int.Parse(Console.ReadLine());
                }
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
        Random random = new Random();
        Console.WriteLine("Enter the length of the array (how many arrays tht array will contain)");
        array = new int[int.Parse(Console.ReadLine())][];
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine("Enter the length of the array: ");
            int k  = int.Parse(Console.ReadLine());
            array[i] = new int[k];
            for(int j = 0; j < k; j++)
            {
                int value = random.Next(0, 1000);
                array[i][j] = value;
            }
        }
    }

    public override void PrintArray()
    {
        Console.WriteLine("Your array: ");
        for (int i = 0; i < array.GetLength(0); i++)
        {   
            for (int j = 0; j < array[i].Length; j++)
            {
                Console.Write(array[i][j] + "\t");
            }
            Console.WriteLine();
        }
    }

     public IDKD(int arrayLength, bool random = false)
    {
        if (!random)
        { 
            Random random = new Random();
           array = new int[arrayLength][];
           for (int i = 0; i < arrayLength; i++)
           {
                Console.WriteLine("Enter the length of the array: ");
                int k  = int.Parse(Console.ReadLine());
                array[i] = new int[k];
                for(int j = 0; j < k; j++)
                {
                    int value = random.Next(0, 1000);
                    array[i][j] = value;
                }
            }
        }
        else
        {
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
        array[0] = new OneD();
        array[1] = new TwoD();
        array[2] = new IDKD();
        foreach(var i in array)
        {
            i.CreateArray();
            i.PrintArray();
            i.MiddleValue();
        }
        Console.WriteLine("Enter the length of your array");
        int arrayLength = int.Parse(Console.ReadLine());
        Console.WriteLine("If you want to fill your array with random numbers, type \"false\", if you want to fill it yourself, type \"true\"");
        bool userchoise = bool.Parse(Console.ReadLine());
        array[0].OneD(arrayLength, userchoise);
        array[1].TwoD(arrayLength, userchoise);
        array[2].IDKD(arrayLength, userchoise);
        foreach(var t in array)
        {
            i.PrintArray();
        }
   }
}



