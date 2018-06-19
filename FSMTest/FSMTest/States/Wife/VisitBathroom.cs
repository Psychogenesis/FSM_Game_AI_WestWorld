using System;

namespace FSMTest
{
    class VisitBathroom : State<Wife>
    {
        public static VisitBathroom Instance { get; }

        static VisitBathroom()
        {
            Instance = new VisitBathroom();
        }

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
            wife.Releafed();
            Console.WriteLine(EntityType.GetEntityName(wife.ID) + ": Ahhhhhh! Sweet relief!");
            wife.ReverttoPreviousState();
        }

        public override void Exit(Wife wife)
        {
            Console.WriteLine(EntityType.GetEntityName(wife.ID) + ": Leavin' the john");
        }
    }
}
