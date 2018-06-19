using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSMTest
{
    class WifeGlobalState : State<Wife>
    {
        Random random = new Random();
        public static WifeGlobalState Instance { get; }
        static WifeGlobalState() { Instance = new WifeGlobalState(); }

        public override void Enter(Wife wife){}

        public override void Execute(Wife wife)
        {
            if(random.Next(1,10) <= 1)
            wife.GetFSM().ChangeState(VisitBathroom.Instance);
        }

        public override void Exit(Wife wife){}
    }
    class DoHousework : State<Wife>
    {
        Random random = new Random();
        public static DoHousework Instance { get; }
        static DoHousework() { Instance = new DoHousework(); }

        public override void Enter(Wife wife)
        {
            if (wife.m_pLocation != Locations.house)
            {
                Console.WriteLine(EntityType.GetEntityName(wife.ID) + ": Gonna do some cleanin'.");
                wife.m_pLocation = Locations.house;
            }
        }

        public override void Execute(Wife wife)
        {
            switch(random.Next(0,2))
            {
                case 0:
                    {
                        Console.WriteLine(EntityType.GetEntityName(wife.ID) + ": Moppin' the floor.");
                        return;
                    }
                case 1:
                    {
                        Console.WriteLine(EntityType.GetEntityName(wife.ID) + ": Washin' the dishes.");
                        return;
                    }
                case 2:
                    {
                        Console.WriteLine(EntityType.GetEntityName(wife.ID) + ": Makin' the bed.");
                        return;
                    }                    
                default:
                    return;
            }
        }

        public override void Exit(Wife wife)
        {
            Console.WriteLine(EntityType.GetEntityName(wife.ID) + ": Thats enough cleanin' for now.");
        }
    }

    class VisitBathroom : State<Wife>
    {
        public static VisitBathroom Instance { get; }

        static VisitBathroom() { Instance = new VisitBathroom(); }

        public override void Enter(Wife wife)
        {
            if (wife.m_pLocation != Locations.bathroom)
            {
                Console.WriteLine(EntityType.GetEntityName(wife.ID) + ": Walkin' to the can. Need to powda mah pretty li'l nose.");
                wife.m_pLocation = Locations.bathroom;
            }
        }

        public override void Execute(Wife wife)
        {
            Console.WriteLine(EntityType.GetEntityName(wife.ID) + ": Ahhhhhh! Sweet relief!");
            wife.ReverttoPreviousState();
        }

        public override void Exit(Wife wife)
        {
            Console.WriteLine(EntityType.GetEntityName(wife.ID) + ": Leavin' the john");
        }
    }
}
