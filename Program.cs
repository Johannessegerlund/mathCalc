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
            using (var reader = File.OpenText("test.json"))
            {
                var serilazier = new JsonSerializer();
                numberArray = (int[])serilazier.Deserialize(reader, typeof(int[]));
            }
            Console.WriteLine(descriptiveStatic(numberArray));
           
        }

        static int Max(int[] numberArray )
        {
             
            return numberArray.Max();
        }
        static int Min(int[] numberArray ) 
        {
             
            return numberArray.Min();
        }
        static double Median(int[] numberArray )
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
            return median;

           
        }
//https://www.tutorialspoint.com/chash-average-method
        static double Mean(int[] numberArray ) 
        {
            double avrg = Enumerable.Average(numberArray.AsEnumerable());  
            return Math.Round(avrg, 1);
        }



        static int range (int[] numberArray) 
        {
            return (Max(numberArray) - Min(numberArray));
        }

        static double standardDiviation(int[] numberArray) 
        {
            double avrg = Mean(numberArray);
            double sqrDiff = 0.0;
        
            double diff = 0.0;
            foreach(double value in numberArray) 
        {
        
            diff = value - avrg;
        
            sqrDiff += (diff * diff) / numberArray.Length ;
        }
            var stdDev = Math.Sqrt(sqrDiff);
            return (Math.Round(stdDev, 1));

        }

        static int[] mode(int[] numberArray)
        {
            var order = numberArray.GroupBy(i => i) 
            .OrderByDescending(g => g.Count()); 
        
            var max = order.Max(g => g.Count());
            int [] mode = order.Where(g => g.Count() == max).Select(g => g.Key).ToArray(); 
         
            return mode;
        
       
        
        }

        static dynamic descriptiveStatic (int[] numberArray) 
        {
            if (numberArray == null)
        {
            throw new System.ArgumentException("Data can not be null");
        }   
            else 
        {
            return ("Maximum:" + " " + Max(numberArray), "minimum:" + " " + Min(numberArray), 
            "Median:" + " " + Median(numberArray), "medelvärde:" + " " + Mean(numberArray), 
            "variationsbredd:" + " " + range(numberArray), "standardavvikelse:" + " " + standardDiviation(numberArray) + " ",
            "typvärde:" + " " + string.Join("," , mode(numberArray)));
        }
        }
    }

}
