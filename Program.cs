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
   
            Max(numberArray);
            Min(numberArray);
        }

        static void Max(int[] numberArray )
        {
            Console.WriteLine(numberArray.Max());
        }
        static void Min(int[] numberArray ) 
        {
            Console.WriteLine(numberArray.Min());
        }
    }
}
