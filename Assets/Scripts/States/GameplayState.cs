using UI;

namespace States
{
    public class GameplayState: State
    {
        private StateMachine _stateMachine;
        
        public override void Begin(StateMachine stateMachine)
        {
            CanvasController.Instance.ActivateGameplayCanvas();
            GameManager.Instance.StartBrickGameplay();
        }

        public override void End()
        {
            return;
        }

        public GameplayState(StateMachine stateMachine) : base(stateMachine)
        {
            _stateMachine = stateMachine;
        }
    }
}