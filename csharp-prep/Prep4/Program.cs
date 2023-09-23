using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        
        int usernumber = -1;
        while(usernumber != 0){
            Console.Write("Enter a list of numbers, type 0 when finished.");

            string enter = Console.ReadLine();
            usernumber = int.Parse(enter);


            if (usernumber != 0){
                
                numbers.Add(usernumber);
            }
        }
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }

        Console.WriteLine($"The sum is: {sum}");


        int max = numbers[0];
        foreach (int number in numbers){
            if (number  > max){
                max = number;
            }
        }
        Console.WriteLine($"The largest number is:{max}");

        int quantity = 0;
        int average = 0;
        quantity = numbers.Count;
        average = sum/quantity;
        Console.WriteLine($"The average is:{average}");




    }
}