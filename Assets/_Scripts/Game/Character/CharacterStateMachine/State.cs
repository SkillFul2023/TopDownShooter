using TopDownShooter.Enums;

namespace TopDownShooter.Gameplay
{
    public abstract class State
    {
        protected readonly Character character;
        protected readonly StateMachine stateMachine;
        protected CharacterState stateName;

        protected State(Character character, StateMachine stateMachine)
        {
            this.character = character;
            this.stateMachine = stateMachine;
        }
        public virtual void Enter()
        {

        }
        public virtual void Input()
        {

        }
        public virtual void LogicUpdate()
        {

        }
        public virtual void Exit()
        {

        }
    }
}

