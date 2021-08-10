using UI;

namespace States
{
    public class WinState: State
    {
        private StateMachine _stateMachine;
        public override void Begin(StateMachine stateMachine)
        {
            CanvasController.Instance.ActivateWinCanvas();
        }

        public override void End()
        {
            _stateMachine.CallMainMenu();
        }

        public WinState(StateMachine stateMachine) : base(stateMachine)
        {
            _stateMachine = stateMachine;
        }
    }
}