using TopDownShooter.Enums;

namespace TopDownShooter.Gameplay
{
    public abstract class EnemyState 
    {
        protected readonly Enemy enemy;
        protected readonly EnemyStateMachine stateMachine;
        protected EnemyStateEnum StateName;

        protected EnemyState(Enemy enemy, EnemyStateMachine stateMachine)
        {
            this.enemy = enemy;
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

