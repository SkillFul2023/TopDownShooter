using TopDownShooter.Enums;

namespace TopDownShooter.Gameplay
{
    public class EnemyIdleState : EnemyState
    {
        private string animationName = "Idle";

        public EnemyIdleState(Enemy enemy, EnemyStateMachine stateMachine) : base(enemy, stateMachine)
        {
        }

        public override void Enter()
        {
            StateName = EnemyStateEnum.Idle;
            enemy.SetCurrentState(StateName);
            enemy.GetEnemyAnimationHelper.SetAnimationBool(animationName, true);
        }
        public override void Exit()
        {
            enemy.GetEnemyAnimationHelper.SetAnimationBool(animationName, false);
        }
    }
}
