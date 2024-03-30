using TopDownShooter.Enums;

namespace TopDownShooter.Gameplay
{
    public class EnemyAttackState : EnemyState
    {
        private string animationName = "Attack";
        public EnemyAttackState(Enemy enemy, EnemyStateMachine stateMachine) : base(enemy, stateMachine)
        {

        }
        public override void Enter()
        {
            StateName = EnemyStateEnum.Attack;
            enemy.SetCurrentState(StateName);
            enemy.GetEnemyAnimationHelper.SetAnimationBool(animationName, true);
        }
        public override void Exit() 
        {
            enemy.GetEnemyAnimationHelper.SetAnimationBool(animationName, false);
        }
    }
}
