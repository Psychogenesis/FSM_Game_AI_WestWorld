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

            EntityManager.Instance.RegisterEntity(miner);
            EntityManager.Instance.RegisterEntity(wife);

            for (int i = 0; i < 30; i++)
            {
                miner.Update();
                wife.Update();

                MessageDispatcher.Instance.DispatchDelayedMessage();

                Thread.Sleep(1300);
            }
            Console.WriteLine("GAME OVER!");
            Console.Read();
        }
    }
}
