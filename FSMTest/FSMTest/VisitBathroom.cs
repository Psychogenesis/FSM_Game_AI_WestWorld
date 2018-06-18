using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSMTest
{
    class VisitBathroom : State<Wife>
    {
        public static VisitBathroom Instance { get; }

        static VisitBathroom()
        {
            Instance = new VisitBathroom();
        }

        public override void Enter(Wife entity)
        {
            throw new NotImplementedException();
        }

        public override void Execute(Wife entity)
        {
            throw new NotImplementedException();
        }

        public override void Exit(Wife entity)
        {
            throw new NotImplementedException();
        }
    }
}
