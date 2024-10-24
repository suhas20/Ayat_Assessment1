using System;
using System.Collections.Generic;

public class Ayat
{
    static List<List<int>> WaysOFParentheses(List<string> expression)
    {
        List<List<int>> res = new List<List<int>>();
        for (int i = 0; i < expression.Count; i++)
        {
            char[] arr = expression[i].ToCharArray();
            res.Add(parenthesesHelper(arr));
        }
        return res;
    }

    static List<int> parenthesesHelper(char[] arr)
    {
        int N = arr.Length;
        int idx = Array.IndexOf(arr, '(');
        List<int> indRes = new List<int>();
        if (idx > -1)
        {
            for (int i = idx + 1; i < N; i++)
            {
                for (int j = i; j < N; j++)
                {
                    if (char.IsDigit(arr[j]))
                    {
                        continue;
                    }
                    else
                    {
                        indRes.Add(j + 1);
                        i = j;
                        break;
                    }
                }
            }
            indRes.Add(N + 1);
        }
        else
        {
            idx = Array.IndexOf(arr, ')');
            for (int i = idx - 1; i >= 0; i--)
            {
                for (int j = i; j >= 0; j--)
                {
                    if (char.IsDigit(arr[j]))
                    {
                        continue;
                    }
                    else
                    {
                        indRes.Add(j + 2);
                        i = j;
                        break;
                    }
                }
            }
            indRes.Add(1);
            int count = indRes.Count - 1;
            indRes.Reverse(1, count);
        }
        return indRes;
    }

    public static void Main(string[] args)
    {
        List<string> expressions = new List<string>();
        Console.WriteLine("Enter 5 expressions:");
        for (int i = 0; i < 5; i++)
        {
            string inp = Console.ReadLine();
            expressions.Add(inp);
        }
        Console.WriteLine("thanks for the input.");
        List<List<int>> res = WaysOFParentheses(expressions);
        foreach (var ele in res)
        {
            Console.WriteLine(string.Join(", ", ele.Skip(1)));
        }
    }
}