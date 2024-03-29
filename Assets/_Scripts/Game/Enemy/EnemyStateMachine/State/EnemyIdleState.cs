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
            enemy.GetEnemyAnimationHelper.SetAnimationBool(animationName, true);
        }
        public override void Exit()
        {
            //character.GetCharacterAnimationHelper.SetAnimationBool(animationName, false);
        }
    }
}
