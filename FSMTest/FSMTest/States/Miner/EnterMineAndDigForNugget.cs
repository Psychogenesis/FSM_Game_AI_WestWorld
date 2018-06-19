using System;

namespace FSMTest
{
    class EnterMineAndDigForNugget : State<Miner>
    {
        public static EnterMineAndDigForNugget Instance { get; }

        static EnterMineAndDigForNugget()
        {
            Instance = new EnterMineAndDigForNugget();
        }

        public override void Enter(Miner miner)
        {
            if (miner.m_Location != Location.Goldmine)
            {
                Console.WriteLine(EntityType.GetEntityName(miner.ID) + ": Walkin' to the gold mine.");
                miner.m_Location = Location.Goldmine;
            }               
        }

        public override void Execute(Miner miner)
        {
            miner.AddToGoldCarried(1);
            miner.IncreaseFatigue();
            Console.WriteLine(EntityType.GetEntityName(miner.ID) + ": Pickin' up a nugget.");

            if (miner.isPocketsFull())
                miner.ChangeState(VisitBankAndDepositGold.Instance);
            if (miner.isThirsty())
                miner.ChangeState(QuenchThirst.Instacne);             
        }

        public override void Exit(Miner miner)
        {
            Console.WriteLine(EntityType.GetEntityName(miner.ID) + ": Ah'm leavin' the gold mine with mah pockets full o' sweet gold.");
        }
    }
}
