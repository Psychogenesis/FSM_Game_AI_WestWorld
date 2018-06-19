using System;

namespace FSMTest
{
    public class QuenchThirst : State<Miner>
    {
        static QuenchThirst()
        {
            Instacne = new QuenchThirst();
        }

        public static QuenchThirst Instacne { get; }

        public override void Enter(Miner miner)
        {
            if (miner.m_Location != Location.Saloon)
            {
                Console.WriteLine(EntityType.GetEntityName(miner.ID) + ": Boy, ah sure is thusty! Walkin' to the saloon.");
                miner.m_Location = Location.Saloon;
            }
        }

        public override void Execute(Miner miner)
        {
            if (miner.isThirsty())
            {
                miner.BuyDrinksandWhiskey();
                Console.WriteLine(EntityType.GetEntityName(miner.ID) + ": That's mighty fine sippin liquor.");
                miner.ChangeState(EnterMineAndDigForNugget.Instance);
            }
            else
                Console.WriteLine("WTF! THIS IS RESTRICTED AREA, NI@GA!");
        }

        public override void Exit(Miner miner)
        {
            Console.WriteLine(EntityType.GetEntityName(miner.ID) + ": Leaving the saloon, feelin' good.");
        }
    }
}
