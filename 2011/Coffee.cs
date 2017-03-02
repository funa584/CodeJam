/*
 *  https://code.google.com/codejam/contest/dashboard?c=889487#s=p1
 */


using System;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        Coffee c = new Coffee();

    }
}


class Coffee
{
    int TestCaseNum;
    long[] Result;

    long Satisfication;


    int CoffeeVariety;
    long Days;
    ColCoffee[] CoffeeList;

    public Coffee()//コンストラクタ
    {
        TestCaseNum = int.Parse(Console.ReadLine());
        Result = new long[TestCaseNum];

        for (int i = 0; i < TestCaseNum; i++)
        {
            RunTestCase(i);
        }
        OutputResult();
    }

    void RunTestCase(int n)
    {
        InitTestCase();
        CalcSatisf();

        Result[n] = Satisfication;
    }
    void InitTestCase()
    {
        Satisfication = 0;

        string[] InputTxt = Console.ReadLine().Split();
        CoffeeVariety = int.Parse(InputTxt[0]);
        Days = long.Parse(InputTxt[1]);
        CoffeeList = new ColCoffee[CoffeeVariety];

        for (int i = 0; i < CoffeeVariety; i++)
        {
            InputTxt = Console.ReadLine().Split();

            CoffeeList[i] = new ColCoffee
            {
                Remain = long.Parse(InputTxt[0]),
                Expire = long.Parse(InputTxt[1]),
                Satisfication = int.Parse(InputTxt[2]),
            };
        }
        CoffeeList = CoffeeList.OrderByDescending(x => x.Expire).ToArray();

    }
    void CalcSatisf()
    {
        if (CoffeeList.Length == 1)
        {
            ColCoffee c = CoffeeList.First();

            long q = Days;//３つの中で一番小さい値を調べる
            if (q > c.Expire)
                q = c.Expire;
            if (q > c.Remain)
                q = c.Remain;

            Satisfication = c.Satisfication * q;

            return;
        }

        ColCoffee[] CanDrinkList;
        ColCoffee UsingCoffee;
        long CanDrinkCoffee;
        ColCoffee[] CompareCoffee;


        while (Days > 0)
        {
            CanDrinkList = CoffeeList
                .Where(x => x.Remain > 0 && x.Expire >= Days)
                .OrderByDescending(x => x.Satisfication).ToArray();

            CanDrinkCoffee = CanDrinkList
                .Sum(x => x.Remain);

            if (CanDrinkCoffee == 0)//飲める物がない時
            {
                CompareCoffee = CoffeeList
                    .Where(x => x.Expire < Days).ToArray();
                if (CompareCoffee.Count() == 0)
                    Days = 0;
                else
                    Days -= Days - CompareCoffee.First().Expire;

                continue;
            }
            else
            {
                UsingCoffee = CanDrinkList.First();

                CompareCoffee = CoffeeList
                    .Where(x => x.Expire < Days).ToArray();
            }

            if (CompareCoffee.Count() == 0)
                UseCoffee(UsingCoffee, Days);
            else
                UseCoffee(UsingCoffee, Days - CompareCoffee.First().Expire);

        }

    }
    void UseCoffee(ColCoffee c, long MaxNum)
    {
        if (MaxNum <= c.Remain)
        {
            c.Remain -= MaxNum;
            Satisfication += c.Satisfication * MaxNum;
            Days -= MaxNum;
        }
        else
        {
            Satisfication += c.Satisfication * c.Remain;
            Days -= c.Remain;
            c.Remain = 0;
        }

    }

    void OutputResult()
    {
        for (int i = 0; i < Result.Length; i++)
        {
            Console.WriteLine("Case #" + (i + 1) + ": " + Result[i]);
        }
    }

}
class ColCoffee
{
    public long Remain, Expire;
    public int Satisfication;
}