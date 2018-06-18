using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSMTest
{
    public abstract class State<T>
    {
        public virtual void Dispose() { }
        public abstract void Enter(T entity);
        public abstract void Execute(T entity);
        public abstract void Exit(T entity);
    }
}
