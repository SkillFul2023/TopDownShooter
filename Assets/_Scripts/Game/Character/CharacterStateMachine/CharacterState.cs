using TopDownShooter.Enums;

namespace TopDownShooter.Gameplay
{
    public abstract class CharacterState
    {
        protected readonly Character character;
        protected readonly CharacterStateMachine stateMachine;
        protected CharacterStateEnum StateName;

        protected CharacterState(Character character, CharacterStateMachine stateMachine)
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

