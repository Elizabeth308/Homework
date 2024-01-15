using System;


class Helper
{
    private int[] array;
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
       array = new int[arrayLength];
       for (int i = 0; i < arrayLength; i++)
       {
           int value = random.Next(0, 1000);
           array[i] = value;
       }
       PrintArray();
   }


   private void UserFill(int arrayLength)
   {
       array = new int[arrayLength];
       for(int i = 0; i < arrayLength; i++)
       {
           array[i] = int.Parse(Console.ReadLine());
       }
       PrintArray();
   }

    public void PrintArray()
    {
        Console.WriteLine("Your array: ");
        foreach (var item in array)
        { 
            Console.WriteLine(item);
        }
    }

    public void MiddleValue()
    {
       int sum = 0;
       double MiddleVal = 0.0;
       int arrayLength = array.Length;
       for (int i = 0; i < arrayLength; i++)
       {
           sum += array[i];
       }
       MiddleVal = (double) sum/arrayLength;
       Console.WriteLine(MiddleVal);
    }


    public void Mod100()
    {
       int arrayLength = array.Length;
       int[] NewArray = new int[array.Length];
       array.CopyTo(NewArray, 0);
       for (int i = 0; i < arrayLength; i++)
       {
           if (!(NewArray[i] < 100 && NewArray[i]>-100))
            {
                NewArray[i] = int.MinValue;
            }
       }
       PrintArray2(NewArray);
   }
   
   private static void PrintArray2(int[] array1)
   {
       Console.WriteLine("Your array: ");
        foreach (var item in array1)
        {
            if(item != int.MinValue)
            {
                Console.WriteLine(item);
            }
        }
   }

   public void NoDoubles()
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
       {                if (!Exists(array[i], newArray))
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


class MainCLass
{
    static void Main()
    {
        Console.WriteLine("Enter the length of your array");
        int arrayLength = int.Parse(Console.ReadLine());
        Console.WriteLine("If you want to fill your array with random numbers, type \"false\", if you want to fill it yourself, type \"true\"");
        bool userchoise = bool.Parse(Console.ReadLine());
        Helper array = new Helper(arrayLength, userchoise);
        Console.WriteLine("Enter your command");
        string command = "";
        while(command != "Exit")
        {
            command = Console.ReadLine();
            switch (command)
            {
                case "find middle":
                {
                    array.MiddleValue();
                    Console.WriteLine("Enter your command");
                    break;
                }
                case "100":
                {
                    array.Mod100();
                    Console.WriteLine("Enter your command");
                    break;
                }
                case "ND":
                {
                    array.NoDoubles();
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


