using TopDownShooter.Enums;

namespace TopDownShooter.Gameplay
{
    public class EnemyMoveState : EnemyState
    {
        private string animationLegsName = "Move";
        private string animationHandsName = "RiseHand";
        public EnemyMoveState(Enemy enemy, EnemyStateMachine stateMachine) : base(enemy, stateMachine)
        {

        }
        public override void Enter()
        {
            StateName = EnemyStateEnum.Move;
            enemy.SetCurrentState(StateName);
            enemy.GetEnemyAnimationHelper.SetAnimationBool(animationHandsName, true);
            enemy.GetLegsAnimationHelper.SetAnimationBool(animationLegsName, true);
        }
        public  override void Exit() 
        {
            enemy.GetEnemyAnimationHelper.SetAnimationBool(animationHandsName, false);
            enemy.GetLegsAnimationHelper.SetAnimationBool(animationLegsName, false);
        }
    }
}
