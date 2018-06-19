using System;

namespace FSMTest
{
    class DoHousework : State<Wife>
    {
        public static DoHousework Instance { get; }
        static DoHousework()
        {
            Instance = new DoHousework();
        }

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
            int rnd = wife.random.Next(1, 10);
            if ( rnd == 7)
            {
                Console.WriteLine(EntityType.GetEntityName(wife.ID) + ": Moppin' the floor.");
            }
            if (rnd == 5)
            {
                Console.WriteLine(EntityType.GetEntityName(wife.ID) + ": Oh my! My belly rumbling..");
                wife.ChangeState(VisitBathroom.Instance);
            }
            if(wife.isInNeed())
                Console.WriteLine(EntityType.GetEntityName(wife.ID) + ": Feeling the need..");
        }

        public override void Exit(Wife wife)
        {
            Console.WriteLine(EntityType.GetEntityName(wife.ID) + ": Thats enough cleanin' for now.");
        }
    }
}
