using System;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
namespace examination_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numberArray;
            using (var reader = File.OpenText("data.json"))
            {
                var serilazier = new JsonSerializer();
                numberArray = (int[])serilazier.Deserialize(reader, typeof(int[]));
            }
   
            Console.WriteLine(numberArray.Max());
            Console.WriteLine(numberArray.Min());
            Median(numberArray);
            Avrage(numberArray);
            range(numberArray);
        }

        static int Max(int[] numberArray )
        {
             
            return numberArray.Max();
        }
        static int Min(int[] numberArray ) 
        {
             
            return numberArray.Min();
        }
        static void Median(int[] numberArray )
        {
            int [] arr = numberArray;
            int arrLength = arr.Length;
            Array.Sort(arr);
            double median = 0;
           
           if (arrLength % 2 == 0) {
            median = (arr[arrLength / 2 - 1] + arr[arrLength / 2]) / 2;
            } else {
             median = arr[(arrLength - 1) / 2];
            }
            Console.WriteLine(median);

           
        }
//https://www.tutorialspoint.com/chash-average-method
        static void Avrage(int[] numberArray ) 
        {
        double avrg = Enumerable.Average(numberArray.AsEnumerable());  
        Console.WriteLine(Math.Round(avrg, 1));
        }

        static void range (int[] numberArray) 
        {
          Console.WriteLine(Max(numberArray) - Min(numberArray));
        }

        static void descriptivStatic(int[] numberArray) 
        {
            
        }
    }

}
