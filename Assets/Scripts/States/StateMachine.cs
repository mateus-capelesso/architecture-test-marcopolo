namespace States
{
    public class StateMachine
    {
        private State _currentState;
    
        public void ChangeState(State newState)
        {
            _currentState = newState;
            _currentState.Begin(this);
        }

        public void CallStateEnd()
        {
            _currentState.End();
        }

        public void CallMainMenu()
        {
            ChangeState(new MainMenuState(this));
        }

        public void CallGameplay()
        {
            ChangeState(new GameplayState(this));
        }

        public void SetGameOverState(bool win)
        {
            if(win)
                ChangeState(new WinState(this));
            else
                ChangeState(new LoseState(this));
        }
    }
}