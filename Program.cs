
using System;
using System.Globalization;
using System.IO;

class Program
{
    static int counterPascal = 0;
    static int counterNewton = 0;

    static long SymbolNewtona(int n, int k)
    {
        k = n - k;
        int numerator = n;
        int help = n - 1;
        if (k == 0)
        {
            return 1;
        }
        else
        {
            for (; help > k; help--)
            {
                numerator = numerator * help;
                counterNewton++;
            }
            int denominator = 1;
            for (int i = 2; i <= n - k; i++)
            {
                denominator *= i;
                counterNewton++;
            }
            return numerator / denominator;
        }
    }
    static long Pascal(int n, int k)
    {
        long[] vector = new long[n + 1];
        vector[0] = 1;

        for (int i = 0; i <= n; i++)
        {
            vector[i] = 1;
        }

        for (int i = 2; i <= n; i++)
        {
            for (int j = i - 1; j >= 1; j--)
            {
                vector[j] += vector[j - 1];
                counterPascal++;
            }
        }
        return vector[k];
    }

    /*
    static int FindMinimum(int a, int b)
    {
        return a < b ? a : b;
    }

    static long Pascal(int n, int k)
    {
        int[] vector = new int[k + 1];

        for (int i = 0; i <= k; i++)
        {
            vector[i] = 0;
        }

        vector[0] = 1;

        for (int i = 1; i <= n; i++)
        {
            int min = FindMinimum(i, k);

            for (int j = min; j >= 1; j--)
            {
                vector[j] = vector[j] + vector[j - 1];
                counterPascal++;
            }
        }

        return vector[k];

    }
    */
    static void Main()
    {
        using (StreamReader reader = new StreamReader("In0101.txt"))
        {
            string[] input = reader.ReadLine().Split();
            int n = int.Parse(input[0]);
            int k = int.Parse(input[1]);

            long result1 = SymbolNewtona(n, k);
            long result2 = Pascal(n, k);

            using (StreamWriter writer = new StreamWriter("Out0101.txt"))
            {
                writer.WriteLine($"n={n} k={k}");
                writer.WriteLine($"SN2 = {result1}, licz = {counterNewton}");
                writer.WriteLine($"SN4 = {result2}, licz = {counterPascal}");
                Console.WriteLine($"SN2 = {result1}, licz = {counterNewton}");
                Console.WriteLine($"SN4 = {result2}, licz = {counterPascal}");
            }
        }
    }
}


// ~~~~~~~~~~DRUGIE ZADANIE (ZADANIE 3 o PREZESIE)~~~~~~~~

/*
using System;
using System.IO;

class Program
{
    static void Main()
    {
        string filePath = "In0103.txt";
        string fileContent = File.ReadAllText(filePath);
        string[] values = fileContent.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

        int n = int.Parse(values[0]);
        int[] data = new int[n];

        for (int i = 1; i <= n; i++)
        {
            data[i-1] = int.Parse(values[i]);
        }

        int maxSum = data[0];
        int currentSum = data[0];
        int startIndex = 0;
        int endIndex = 0;
        int tempStartIndex = 0;

        for (int i = 1; i < n; i++)
        {
            int newSum = currentSum + data[i];
            if (data[i] > newSum)
            {
                currentSum = data[i];
                tempStartIndex = i;
            }
            else
            {
                currentSum = newSum;
            }

            if (currentSum > maxSum)
            {
                maxSum = currentSum;
                startIndex = tempStartIndex;
                endIndex = i;
            }
        }

        using (StreamWriter writer = new StreamWriter("Out0103.txt"))
        {
            writer.WriteLine($"{maxSum}, {startIndex}, {endIndex}");
        }
    }
}


*/
// ~~~~~~~~~~~~ZADANIE 2 (3) v2 ~~~~~~~~~~~~


/*
class Program
{
    static void Main()
    {
        string filePath = "In0103.txt";
        string fileContent = File.ReadAllText(filePath);
        string[] values = fileContent.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

        int n = int.Parse(values[0]);
        int[] data = new int[n];

        for (int i = 1; i <= n; i++)
        {
            data[i - 1] = int.Parse(values[i]);
        }

        int maxSum = 0;
        int startIndex = 0;
        int endIndex = 0;

        for (int i = 0; i < n; i++)
        {
            for (int j = i; j < n; j++)
            {
                int sum = 0;
                for (int k = i; k <= j; k++)
                {
                    sum += data[k];
                }
                if (sum > maxSum)
                {
                    maxSum = sum;
                    startIndex = i;
                    endIndex = j;
                }
            }
        }

        using (StreamWriter writer = new StreamWriter("Out0103.txt"))
        {
            writer.WriteLine($"{maxSum}, {startIndex}, {endIndex}");
        }
    }
}

*/