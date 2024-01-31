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
   }
}



