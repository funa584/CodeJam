// https://code.google.com/codejam/contest/6254486/dashboard

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        var s = new CountingSheep();

        s.CalcAllCases();

        s.OutputResult();

    }

}


class CountingSheep
{
    int _TestCases = 0;
    int[] _InputList;
    long[] _Result;

    public CountingSheep()
    {

    }


    public void CalcAllCases()
    {
        _TestCases = int.Parse(Console.ReadLine());
        _InputList = new int[_TestCases];
        _Result = new long[_TestCases];

        for (int i = 0; i < _TestCases; i++)
        {
            _InputList[i] = int.Parse(Console.ReadLine());
            _Result[i] = 0;
        }

        for (int i = 0; i < _TestCases; i++)
        {
            CalcOneCase(i);
        }
    }

    private void CalcOneCase(int Case)
    {
        bool[] SeenDigits = new bool[10];

        for (int i = 0; i < 10; i++)
            SeenDigits[i] = false;

        int n = _InputList[Case];

        if (n == 0)
            return;

        string Digit = "";
        for (int i = 1; i < 10000; i++)
        {
            Digit = (n * i).ToString();

            for (int j = 0; j < 10; j++)
            {
                if (Digit.IndexOf(j.ToString()) != -1)
                    SeenDigits[j] = true;

            }

            if (SeenDigits.Where(x => x == true).Count() == 10)
            {
                _Result[Case] = long.Parse(Digit);
                return;
            }

        }



    }

    public void OutputResult()
    {
        string Result;
        for (int i = 0; i < _TestCases; i++)
        {
            if (_Result[i] == 0)
                Result = "INSOMNIA";
            else
                Result = _Result[i].ToString();

            Console.WriteLine("Case #" + (i + 1) + ": " + Result);
        }
    }

}