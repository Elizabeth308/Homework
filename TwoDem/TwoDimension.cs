using System;
class Helper
{
    private int[,] array;
    public Helper(int arrayLength, bool random = false)
    {
        if (!random)
        { 
            RandomFill(arrayLength);
        }
        else
        {
            Console.WriteLine("Please enter elements of your array: ");
            UserFill(arrayLength);
        }
   }








   private void RandomFill(int arrayLength)
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
       PrintArray();
   }








    private void UserFill(int arrayLength)
    {
        array = new int[arrayLength, arrayLength];
        for(int i = 0; i < arrayLength; i++)
        {
            for(int j = 0; j < arrayLength; j++)
            {
               array[i, j] = int.Parse(Console.ReadLine());
            }
        }
       PrintArray();
    }




    public void PrintArray()
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




    public void SecondBackwards()
    {
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
    public void MiddleValue()
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
        Console.WriteLine(MiddleVal);
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
        while(command != "Exit")
        {
            command = Console.ReadLine();
            switch(command)
            {
                case "SB":
                {
                    array.SecondBackwards();
                    Console.WriteLine("Enter your command");
                    break;
                }
                case "MV":
                {
                    array.MiddleValue();
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



