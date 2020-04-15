using System;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Collections.Generic; 
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

        static double Mean(int[] numberArray ) 
        {
            double avrg = numberArray.Average();
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
            .OrderByDescending(o => o.Count()); 
        
            var maxi = order.Max(o => o.Count());
            int [] mode = order.Where(o => o.Count() == maxi)
            .Select(o => o.Key)
            .ToArray(); 
            
             return mode;
        
       
        
        }

        static dynamic descriptiveStatic (int[] numberArray) 
        {
            if (numberArray == null)
        {
            throw new System.ArgumentNullException("Data can not be null");
        }  
            if(numberArray.Length == 0) 
        {
            throw new InvalidOperationException("Sequence contains no elements");
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
