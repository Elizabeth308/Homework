using System;
class Helper
{
    private int[][] array;
    public Helper(int arrayLength, bool random = false)
    {
        if (!random)
        { 
            RandomFill(arrayLength);
        }
        else
        {
            UserFill(arrayLength);
        }
   }


   private void RandomFill(int arrayLength)
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
       PrintArray();
   }


    private void UserFill(int arrayLength)
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
       PrintArray();
    }


    public void PrintArray()
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

    public void ReCreateArray(int arrayLength, bool userchoise)
    {
        if (userchoise == false)
        { 
            RandomFill(arrayLength);
        }
        else
        {
            UserFill(arrayLength);
        }
    }
    public void MiddleValueAllArray()
    {
        int sum = 0;
        double MiddleVal = 0.0;
        int arrayLength = array.Length;
        for (int i = 0; i < arrayLength; i++)
        {
            int r = array[i].Length;
            for(int j = 0; j < r; j++)
            {
                sum += array[i][j];
            }
        }
        MiddleVal = (double) sum/arrayLength;
        Console.WriteLine(MiddleVal);
    }

    public void MiddleValueOfArrayInArray()
    {
        int sum = 0;
        double MiddleVal = 0.0;
        int arrayLength = array.Length;
        for (int i = 0; i < arrayLength; i++)
        {
            int r = array[i].Length;
            for(int j = 0; j < r; j++)
            {
                sum += array[i][j];
            }
            MiddleVal = (double) sum/arrayLength;
            Console.WriteLine(MiddleVal);
            MiddleVal = 0;
            sum = 0;
        }
    }
    public void EvenToIndex()
    {
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

class OP
{
    static void Main()
    {
        Console.WriteLine("Enter the length of your array");
        int arrayLength = int.Parse(Console.ReadLine());
        Console.WriteLine("If you want to fill your array with random numbers, type \"false\", if you want to fill it yourself, type \"true\"");
        bool userchoise = bool.Parse(Console.ReadLine());
        Helper array = new Helper(arrayLength, userchoise);
        string command = "";
        Console.WriteLine("Enter your command");
        while(command != "Exit")
        {
            command = Console.ReadLine();
            switch(command)
            {
                case "MVA":
                {
                    array.MiddleValueAllArray();
                    Console.WriteLine("Enter your command");
                    break;
                }
                case "RA":
                {
                    array.ReCreateArray(arrayLength, userchoise);
                    Console.WriteLine("Enter your command");
                    break;
                }
                case "MVO":
                {
                    array.MiddleValueOfArrayInArray();
                    Console.WriteLine("Enter your command");
                    break;
                }
                case "ETI":
                {
                    array.EvenToIndex();
                    Console.WriteLine("Enter your command");
                    break;
                }
                default:
                {   
                    Console.WriteLine("Unknown command, try again");
                    break;
                }
            }
        }
    }
}

