using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSMTest
{
    class GoHomeAndSleepTilRested : State<Miner>
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
            if (miner.isFatigued())
            {
                miner.DecreaseFatigue();
                Console.WriteLine(EntityType.GetEntityName(miner.ID) + ": ZZZZ...");
            }
            else
            {
                Console.WriteLine(EntityType.GetEntityName(miner.ID) + ": What a God-darn fantastic nap! Time to find more gold.");
                miner.ChangeState(EnterMineAndDigForNugget.Instance);
            }
        }

        public override void Exit(Miner miner)
        {
            Console.WriteLine(EntityType.GetEntityName(miner.ID) + ": Leaving the house.");
        }
    }

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
                miner.ReverttoPreviousState();
            }
            else
                Console.WriteLine("WTF! THIS IS RESTRICTED AREA, NI@GA!");
        }

        public override void Exit(Miner miner)
        {
            Console.WriteLine(EntityType.GetEntityName(miner.ID) + ": Leaving the saloon, feelin' good.");
        }
    }

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
