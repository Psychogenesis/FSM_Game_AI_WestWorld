using System;

namespace FSMTest
{
    public class GoHomeAndSleepTilRested : State<Miner>
    {
        public static GoHomeAndSleepTilRested Instance { get; }
        static GoHomeAndSleepTilRested()
        {
            Instance = new GoHomeAndSleepTilRested();
        }
        public override void Enter(Miner miner)
        {
            if (miner.m_Location != Location.Shack)
            {
                Console.WriteLine(EntityType.GetEntityName(miner.ID) + ": Walkin' home.");
                miner.m_Location = Location.Shack;
            }
        }

        public override void Execute(Miner miner)
        {
            if(miner.isFatigued())
            {
                miner.DecreaseFatigue();
                Console.WriteLine(EntityType.GetEntityName(miner.ID) + ": ZZZZ...");
            }
            else
            {
                Console.WriteLine(EntityType.GetEntityName(miner.ID) + ": What a God-darn fantastic nap! Time to find more gold.");
                miner.ReverttoPreviousState();
            }
        }

        public override void Exit(Miner miner)
        {
            Console.WriteLine(EntityType.GetEntityName(miner.ID) + ": Leaving the house.");
        }
    }
}
