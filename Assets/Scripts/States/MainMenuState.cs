using UI;

namespace States
{
    public class MainMenuState: State
    {
        private StateMachine _stateMachine;

        public override void Begin(StateMachine stateMachine)
        {
            CanvasController.Instance.ActivateMainMenu();
        }

        public override void End()
        {
            _stateMachine.CallGameplay();
        }

        public MainMenuState(StateMachine stateMachine) : base(stateMachine)
        {
            _stateMachine = stateMachine;
        }
    }
}