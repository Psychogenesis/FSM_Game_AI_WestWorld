using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSMTest
{
    public enum Locations
    {
        bathroom,
        house
    }
    class Wife : BaseEntity
    {
        private StateMachine<Wife> FSM;
        public Wife(int ID) : base(ID) { }
        public override void Update()
        {
            FSM.Update();
        }
    }
}
