using UI;

namespace States
{
    public class LoseState: State
    {
        private StateMachine _stateMachine;
        public override void Begin(StateMachine stateMachine)
        {
            CanvasController.Instance.ActivateLoseCanvas();
        }

        public override void End()
        {
            _stateMachine.CallMainMenu();
        }

        public LoseState(StateMachine stateMachine) : base(stateMachine)
        {
            _stateMachine = stateMachine;
        }
    }
}