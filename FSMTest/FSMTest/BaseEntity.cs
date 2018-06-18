using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSMTest
{
    public abstract class BaseEntity
    {
        private int m_ID;

         protected BaseEntity(int id)
        {
            m_ID = id;
        }

        public static int m_NextValidID { get; private set; }

        public int ID
        {
            get { return m_ID; }
            set
            {
                m_ID = value;
                m_NextValidID = m_ID + 1;
            }
        }

        public abstract void Update();
    }
}
