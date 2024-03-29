using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Animation;
using TopDownShooter.Enums;
using UnityEngine;
namespace TopDownShooter.Gameplay
{
    public class Enemy : Unit
    {
        [SerializeField] private EnemyStateEnum enemyStateEnum;
        [SerializeField] private EnemyAnimationHelper enemyAnimationHelper;


        public EnemyStateMachine EnemyStateMachine;
        public EnemyIdleState EnemyIdleState;
        public EnemyMoveState EnemyMoveState;
        public EnemyAttackState EnemyAttackState;
        public EnemyAnimationHelper GetEnemyAnimationHelper
        {
            get => enemyAnimationHelper;
        }

        private void Awake()
        {
            EnemyStateMachine = new EnemyStateMachine();
            EnemyIdleState = new EnemyIdleState(this, EnemyStateMachine);
            EnemyMoveState = new EnemyMoveState(this, EnemyStateMachine);
            EnemyAttackState = new EnemyAttackState(this, EnemyStateMachine);
        }
        private void Start()
        {
            EnemyStateMachine.Initialize(EnemyIdleState);
        }
    }
}

