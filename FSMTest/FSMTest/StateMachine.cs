using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSMTest
{
    class StateMachine<T>
    {
        private T m_pOwner;
        private State<T> m_pCurrentState;
        private State<T> m_pPreviousState;
        private State<T> m_pGlobalState;

        public void Awake()
        {
            m_pCurrentState = null;
            m_pPreviousState = null;
            m_pGlobalState = null;
        }

        public void Initialise(T owner, State<T> InitialState)
        {
            m_pOwner = owner;
            ChangeState(InitialState);
        }

        public void Update()
        {
            m_pGlobalState?.Execute(m_pOwner);
            m_pCurrentState?.Execute(m_pOwner);
        }

        public void ChangeState(State<T> pNewState)
        {
            m_pPreviousState = m_pCurrentState;
            m_pCurrentState?.Exit(m_pOwner);
            m_pCurrentState = pNewState;
            m_pCurrentState?.Enter(m_pOwner);
        }
        public void RevertToPreviousState(State<T> prevState)
        {
            if(m_pCurrentState != null)
                m_pCurrentState = prevState;
        }
    }
}
