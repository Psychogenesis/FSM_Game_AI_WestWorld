using System;

namespace FSMTest
{
    public enum Locations
    {
        bathroom,
        house,
        kitchen
    }
    class Wife : BaseEntity
    {
        private StateMachine<Wife> FSM;
        public Locations m_pLocation;
        private int Releaf;
        public Random random = new Random(10);
        public Wife(int ID) : base(ID)
        {
            m_pLocation = Locations.house;
            Releaf = 0;
        }
        public void Awake()
        {
            Console.WriteLine("Wife is here..");
            FSM = new StateMachine<Wife>();
            FSM.Initialise(this, DoHousework.Instance);
        }
        public void ChangeState(State<Wife> sm)
        {
            FSM.ChangeState(sm);
        }
        public override void Update()
        {
            Releaf++;
            FSM.Update();
        }

        public int Releafed() => Releaf = 0;
        public int IncreaseNeed() => Releaf++;
        public bool isInNeed() => Releaf >= 5 ? true : false;
    }
}
