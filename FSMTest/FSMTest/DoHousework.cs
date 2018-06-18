using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine(EntityType.GetEntityName(wife.ID) + "Walkin' to the can. Need to powda mah pretty li'l nose.");
        }

        public override void Execute(Wife wife)
        {
            Console.WriteLine(EntityType.GetEntityName(wife.ID) + "Ahhhhhh! Sweet relief!");
        }

        public override void Exit(Wife wife)
        {
            Console.WriteLine(EntityType.GetEntityName(wife.ID) + "Leavin' the john");
        }
    }
}
