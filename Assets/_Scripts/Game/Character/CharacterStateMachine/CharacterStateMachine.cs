namespace TopDownShooter.Gameplay
{
    public class CharacterStateMachine
    {
        public CharacterState CurrentState { get; private set; }

        public void Initialize(CharacterState startState)
        {
            CurrentState = startState;
            startState.Enter();
        }
        public void ChangeState(CharacterState newState)
        {
            CurrentState.Exit();
            CurrentState = newState;
            newState.Enter();
        }
    }
}
