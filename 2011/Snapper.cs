// https://code.google.com/codejam/contest/1343486/dashboard

using System;

class Program
{
    static void Main(string[] args)
    {
        var s = new Snapper();
        s.InputTxt();
        s.CalcAllCase();
        s.OutputResult();
    }

}

class Snapper
{
    long[] ListN, ListK;
    bool[] Result;

    public void InputTxt()
    {
        int n = int.Parse(Console.ReadLine());
        string[] s;
        ListN = new long[n];
        ListK = new long[n];
        Result = new bool[n];

        for (int i = 0; i < n; i++)
        {
            s = Console.ReadLine().Split();
            ListN[i] = long.Parse(s[0]);
            ListK[i] = long.Parse(s[1]);
        }
    }

    public void CalcAllCase()
    {
        for (int i = 0; ListN.Length > i; i++)
            CalcCase(i);
    }
    void CalcCase(int n)
    {
        long Cmp = 0;

        for (int i = 0; i < ListN[n]; i++)
            Cmp += (long)Math.Pow(2, i);

        Result[n] = (Cmp & ListK[n]) == Cmp ? true : false;
    }

    public void OutputResult()
    {
        for (int i = 0; i < ListN.Length; i++)
            Console.WriteLine("Case #{0}: {1}", i + 1, Result[i] ? "ON" : "OFF");
    }

}