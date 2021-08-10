namespace States
{
    public abstract class State
    {
        private StateMachine _stateMachine;

        protected State(StateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        public abstract void Begin(StateMachine stateMachine);
        public abstract void End();
    }
}