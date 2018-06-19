using System;
using System.Threading;

namespace FSMTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var miner = new Miner((int) EntityNameType.Miner);
            var wife = new Wife((int) EntityNameType.Wife);

            for (int i = 0; i < 20; i++)
            {
                miner.Update();
                wife.Update();
                Thread.Sleep(2500);
            }
            Console.WriteLine("GAME OVER!");
            Console.Read();
        }
    }
}
