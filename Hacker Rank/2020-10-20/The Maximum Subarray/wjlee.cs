
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution
{

    // Complete the maxSubarray function below.
    static int[] maxSubarray(int[] arr)
    {
        var maxElement = arr.Max();
        var sumPositive = arr.Any(x=>x>0);
        var maxOfSubseq = sumPositive ?  arr.Where(x=>x>0).Sum() : maxElement;

        var dp = new int[] { arr[0], arr[0] };
        var sum = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            var max = Math.Max(dp[0] + arr[i], dp[1] + arr[i]);
            dp[0] = max;
            dp[1] = arr[i];

            var dpsMax = Math.Max(dp[0], dp[1]);

            if (dpsMax > sum)
            {
                sum = dpsMax;
            }
            
        }

        Console.WriteLine(sum);
        Console.WriteLine(maxOfSubseq);
        return new int[] { sum, maxOfSubseq };
    }

    static void Main(string[] args)
    {

        Console.WriteLine(maxSubarray(new int[] { -2, -3 ,-1, -4, -6 }));
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), arrTemp => Convert.ToInt32(arrTemp))
            ;
            int[] result = maxSubarray(arr);

            textWriter.WriteLine(string.Join(" ", result));
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
