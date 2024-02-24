using System;
abstract class ArrayBase:IBaseArray
{
    public abstract void CreateArray();
    
    public abstract void UserChoise();

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

public interface IBaseArray
{
   void CreateArray();
  
   void UserChoise();

   void MiddleValue();
}


public interface IPrinter
{
    void Print();
}


public interface IOneDimensionalArray
{
    void NoDoubles();
}


public interface ITwoDimensionalArray
{
    void SecondBackwards();
}


public interface IManyDimensionalArray
{
    void EvenToIndex();
}

sealed class OneD:ArrayBase,IOneDimensionalArray,IPrinter
{
    private int[] array;

    public OneD(bool random = false) : base (random)
    {

    }


    public override void CreateArray()
    {
        Console.WriteLine("Enter the length of your array (1 dimension)");
        int arrayLength = int.Parse(Console.ReadLine());
        array = new int[arrayLength];
        Random random1 = new Random();
        for (int i = 0; i < array.Length; i++)
        {
            int value = random1.Next(0, 10);
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


    void IPrinter.Print()
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


    private static void PrintArray2(int[] array1)
    {
        Console.WriteLine("Your array (one dimension): ");
        foreach (var item in array1)
        {
            if(item != int.MinValue)
            {
                Console.WriteLine(item);
            }
        }
    }


    void IOneDimensionalArray.NoDoubles()
    {
       int[] newArray = GetArrayWithoutDuplicates(array);
       PrintArray2(newArray);
    }


    private int[] GetArrayWithoutDuplicates(int[] array)
    {    
        int newArrayLength = array.Length;
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i; j < array.Length; j++)
            {
                if (array[i] == array[j] && i != j)
                {
                    newArrayLength--;
                    break;
                }
            }
        }
        int[] newArray = new int[newArrayLength];
        for (int i = 0; i < newArray.Length; i++)
        {
            newArray[i] = int.MinValue;
        }
        int counter = 0;   
        for (int i = 0; i < array.Length; i++)
        {                
            if (!Exists(array[i], newArray))
            {
                newArray[counter] = array[i];
                counter++;
            }
        }            
        return newArray;
    }

    private bool Exists(int value, int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == value)
            {
                return true;
            }
        }
        return false;
    }
}


sealed class TwoD:ArrayBase,ITwoDimensionalArray,IPrinter
{
    private int[,] array;

    public TwoD(bool random = false) : base (random)
    {

    }

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


    void IPrinter.Print()
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


    void ITwoDimensionalArray.SecondBackwards()
    {
        Console.WriteLine("Your array (two dimensions): ");
        for(int i = 0; i < array.GetLength(1); i++)
        {
            for(int j = 0; j < array.GetLength(0); j++)
            {
                if(i%2!=0)
                {
                    Console.Write(array[i, array.GetLength(0) - 1 - j] + "\t");
                }
                else
                {
                    Console.Write(array[i, j] + "\t");
                }
            }
            Console.WriteLine();
        }
    }
}



sealed class IDKD:ArrayBase,IManyDimensionalArray,IPrinter
{
    private int[][] array;
    
    public IDKD(bool random = false) : base (random)
    {

    } 

    public override void CreateArray()
    {
        Random random1 = new Random();
        Console.WriteLine("Enter the length of the array (how many arrays jagged array will contain)");
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

    void IPrinter.Print()
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

    public override void UserChoise()
    {
        Console.WriteLine("Enter the length of the array (how many arrays jagged array will contain)");
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

    void IManyDimensionalArray.EvenToIndex()
    {
        Console.WriteLine("Your array (jagged): ");
        int arrayLength = array.Length;
        for(int i = 0; i < arrayLength; i++)
        {
            for(int j = 0; j < array[i].Length; j++)
            {
                if(array[i][j]%2 == 0)
                {
                    array[i][j] = i*j;
                    Console.Write(array[i][j] + "\t");
                }
                else
                {
                    Console.Write(array[i][j] + "\t");
                }
            }
            Console.WriteLine();
        }
    }
}


class Days:IPrinter
{
    private string[] days;
    public Days(string language)
    {
        if(language == "russian")
        {
            days = {"пн", "вт", "ср", "чт", "пт", "сб", "вс"};
        }
        else if(language == "english")
        {
            days = {"mon", "tue", "wed", "thu", "fri", "sat", "sun"};
        }
        else
        {
            Console.WriteLine("This program does not support this language, weekdays will be shown in english");
            days = {"mon", "tue", "wed", "thu", "fri", "sat", "sun"};
        }
    }


    void IPrinter.Print()
    {
        foreach(var i in days)
        {
            Console.WriteLine(i);
        }  
    }
}



class Program
{
   static void Main()
   {
       ArrayBase[] array = new ArrayBase[4];
       Console.WriteLine("If you want to fill your array with random numbers, type \"false\", if you want to fill it yourself, type \"true\"");
       bool userchoise = bool.Parse(Console.ReadLine());
       array[0] = new OneD(userchoise);
       array[1] = new TwoD(userchoise);
       array[2] = new IDKD(userchoise);
       Console.WriteLine("If you want to get the weekdays in russian, type \"russian\", if you want to get the weekdays in english, type \"english\"");
       string language = Console.ReadLine();
       Days weekdays = new Days(language);
       IPrinter[] printers = { (IPrinter)array[0], (IPrinter)array[1], (IPrinter)array[2], weekdays };
       foreach(var t in printers)
       {
           t.Print();
       }
       
       foreach(var i in array)
       {
           i.MiddleValue();
       }
       Console.WriteLine("NEW ARRAYS------------------------------------------------------------------------------------------------------------------------------------------------------------------");
       ((IOneDimensionalArray)array[0]).NoDoubles();
       ((ITwoDimensionalArray)array[1]).SecondBackwards();
       ((IManyDimensionalArray)array[2]).EvenToIndex();
  }
}
