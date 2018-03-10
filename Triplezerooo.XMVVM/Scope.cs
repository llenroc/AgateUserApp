using System;

namespace Triplezerooo.XMVVM
{
    public class Scope : IDisposable
    {
        private readonly Action exitAction;

        public Scope(Action exitAction)
        {
            this.exitAction = exitAction;
        }
        public void Dispose()
        {
            exitAction();
        }
    }

    public class OperationScope
    {
        private readonly Action enterAction;
        private readonly Action exitAction;

        public OperationScope(Action enterAction, Action exitAction)
        {
            this.enterAction = enterAction;
            this.exitAction = exitAction;
        }

        public Scope Enter()
        {
            enterAction();
            return new Scope(exitAction);
        }
    }
}