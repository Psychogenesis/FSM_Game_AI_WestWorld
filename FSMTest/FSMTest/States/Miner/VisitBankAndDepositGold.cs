using System;

namespace FSMTest
{
    class VisitBankAndDepositGold : State<Miner>
    {
        public static VisitBankAndDepositGold Instance { get; }
        static VisitBankAndDepositGold()
        {
            Instance = new VisitBankAndDepositGold();
        }
        public override void Enter(Miner miner)
        {
            if (miner.m_Location != Location.Bank)
            {
                Console.WriteLine(EntityType.GetEntityName(miner.ID) + ": Goin' to the bank. Yes siree.");
                miner.m_Location = Location.Bank;
            }
        }

        public override void Execute(Miner miner)
        {
            miner.DepositGoldInBank();
            Console.WriteLine(EntityType.GetEntityName(miner.ID) + ": Depositin’ gold. Total savings now: " + miner.MoneyInBank);

            if (miner.isWealthy())
            {
                Console.WriteLine(EntityType.GetEntityName(miner.ID) + ": Woohoo!Rich enough for now.Back home to mah li'l lady.");
                miner.ChangeState(GoHomeAndSleepTilRested.Instance);
            }
            else
                miner.ReverttoPreviousState();
        }

        public override void Exit(Miner miner)
        {
            Console.WriteLine(EntityType.GetEntityName(miner.ID) + ": Leavin' the bank.");
        }
    }
}
