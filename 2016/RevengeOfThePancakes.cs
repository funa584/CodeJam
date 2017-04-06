// https://code.google.com/codejam/contest/6254486/dashboard#s=p1

using System;
using System.Collections.Generic;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        var r = new RevengeOfThePancakes();
        r.SolveAllCases();
        r.OutputResult();

    }

}


class RevengeOfThePancakes
{
    int _Case;
    int[] _Result;

    public void SolveAllCases()
    {
        _Case = int.Parse(Console.ReadLine());
        _Result = new int[_Case];

        for (int i = 0; i < _Case; i++)
        {
            _Result[i] = SolveOneCase();
        }
    }

    int SolveOneCase()
    {
        string InputTxt = Console.ReadLine();
        int StrLength = InputTxt.Length;

        bool[] Stack = new bool[StrLength];
        for (int i = 0; i < StrLength; i++)
            Stack[i] = InputTxt[i] == '+' ? true : false;

        int Count = 0;
        while (Stack.Where(x => x == true).Count() != StrLength)
        {
            Count++;
            Stack = Flip(Stack);
        }

        return Count;
    }

    bool[] Flip(bool[] Stack)
    {
        for (int i = Stack.Length - 1; i >= 0; i--)
        {
            if (Stack[i] == false)
            {
                for (int j = 0; j <= i; j++)
                {
                    Stack[j] = Stack[j] == true ? false : true;

                }

                return Stack;
            }
        }

        return Stack;
    }

    public void OutputResult()
    {
        for (int i = 0; i < _Result.Length; i++)
            Console.WriteLine("Case #" + (i + 1) + ": " + _Result[i]);
    }
}