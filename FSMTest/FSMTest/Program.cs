using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace FSMTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var miner = new Miner((int) EntityNameType.Miner);
            miner.Awake();
            for (int i = 0; i < 20; i++)
            {
                miner.Update();
                Thread.Sleep(2500);
            }
            Console.WriteLine("GAME OVER!");
            Console.Read();
        }
    }
}
