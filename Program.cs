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
            descriptiveStatic(numberArray);
            Console.WriteLine(Max(numberArray))
            Console.WriteLine(Min(numberArray));
            Median(numberArray);
            Console.WriteLine(Avrage(numberArray));
            range(numberArray);
            standardDiviation(numberArray);
            mode(numberArray);
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
        static double Avrage(int[] numberArray ) 
        {
        double avrg = Enumerable.Average(numberArray.AsEnumerable());  
        return Math.Round(avrg, 1);
        }



        static void range (int[] numberArray) 
        {
          Console.WriteLine(Max(numberArray) - Min(numberArray));
        }

        static void standardDiviation(int[] numberArray) 
        {
        double avrg = Avrage(numberArray);
        double sqrDiff = 0.0;
        
        double diff = 0.0;
        foreach(double value in numberArray) 
        {
        
        diff = value - avrg;
        
        sqrDiff += (diff * diff) / numberArray.Length ;
        }
        var stdDev = Math.Sqrt(sqrDiff);
        Console.WriteLine(Math.Round(stdDev, 1));

        }

        static void mode(int[] numberArray)
        {
        var order = numberArray.GroupBy(i => i) 
        .OrderByDescending(g => g.Count()); 
        
        var max = order.Max(g => g.Count());
        int [] mode = order.Where(g => g.Count() == max).Select(g => g.Key).ToArray(); 
         
         Console.WriteLine(string.Join("," , mode));
        
       
        
        }

        static dynamic descriptiveStatic (int[] numberArray) 
        {
            
        
           
        }
    }

}
