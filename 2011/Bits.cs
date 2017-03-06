// https://code.google.com/codejam/contest/dashboard?c=889487#s=p2

using System;

class Program
{
    static void Main(string[] args)
    {
        Bits b = new Bits();
        b.InputList();
        b.CalcAllCases();
        b.OutputResult();

    }
}

class Bits
{
    ulong[] List;
    int[] Result;

    public Bits()//コンストラクタ
    {

    }

    public void InputList()
    {
        int n = int.Parse(Console.ReadLine());
        List = new ulong[n];
        Result = new int[n];

        for (int i = 0; i < n; i++)
            List[i] = ulong.Parse(Console.ReadLine());

    }

    public void CalcAllCases()
    {
        for (int i = 0; i < List.Length; i++)
            Result[i] = CalcCase(i);
    }
    int CalcCase(int n)
    {
        return GetA(n) + GetB(n);
    }
    int GetA(int n)//右から１が続かなくなるまで続ける
    {
        int Result = 0;
        ulong Sub;

        for (int i = 0; i < 64; i++)
        {
            Sub = (ulong)Math.Pow(2, i);
            if (List[n] >= Sub)
            {
                Result++;
                List[n] -= Sub;
            }
            else
            {
                break;
            }

        }
        return Result;

    }
    int GetB(int n)
    {
        int Result = 0;
        int i = 0;
        ulong Sub;
        while (List[n] > 0)
        {
            Sub = (ulong)Math.Pow(2, i);

            if ((List[n] & Sub) > 0)
            {
                Result++;
                List[n] -= Sub;

            }

            i++;
        }
        return Result;

    }

    public void OutputResult()
    {
        for (int i = 0; i < Result.Length; i++)
            Console.WriteLine("Case #{0}: {1}", i + 1, Result[i]);
    }


}
