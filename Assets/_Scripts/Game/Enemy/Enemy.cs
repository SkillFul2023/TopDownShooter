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
        [SerializeField] private float attackRange;
        [SerializeField] private EnemyAnimationHelper enemyAnimationHelper;
        [SerializeField] private LegsAnimationHelper legsAnimationHelper;
        [SerializeField] private EnemyAction enemyAction;


        public EnemyStateMachine EnemyStateMachine;
        public EnemyIdleState EnemyIdleState;
        public EnemyMoveState EnemyMoveState;
        public EnemyAttackState EnemyAttackState;
        public EnemyAnimationHelper GetEnemyAnimationHelper
        {
            get => enemyAnimationHelper;
        }
        public LegsAnimationHelper GetLegsAnimationHelper
        {
            get => legsAnimationHelper;
        }
        public float GetAttackRange
        {
            get => attackRange;
        }

        private void Awake()
        {
            EnemyStateMachine = new EnemyStateMachine();
            EnemyIdleState = new EnemyIdleState(this, EnemyStateMachine);
            EnemyMoveState = new EnemyMoveState(this, EnemyStateMachine);
            EnemyAttackState = new EnemyAttackState(this, EnemyStateMachine);

            enemyAction = GetComponent<EnemyAction>();
        }
        private void OnEnable()
        {
            enemyAction.moveFromTarget += OnChangeEnemyStateMove;
            enemyAction.idleState += OnChangeEnemyStateIdle;
            enemyAction.attackTarget += OnChangeEnemyAttackState;
        }
        private void OnDisable()
        {
            enemyAction.moveFromTarget += OnChangeEnemyStateMove;
            enemyAction.idleState -= OnChangeEnemyStateIdle;
            enemyAction.attackTarget -= OnChangeEnemyAttackState;
        }
        private void Start()
        {
            EnemyStateMachine.Initialize(EnemyIdleState);
        }
        private void Update()
        {
            TurnGameObject();
            currentHealth.fillAmount = (float)HealthValue / GetMaxHealthValue;

            if (HealthValue <= 0)
            {
                EnemyDie();
            }
        }
        private void EnemyDie()
        {
            Destroy(gameObject);
        }
        public void SetCurrentState(EnemyStateEnum currentState)
        {
            enemyStateEnum = currentState;
        }
        public void TurnGameObject()
        {
            if (enemyAction.GetTarget == null)
            {
                return;
            }
            if(enemyAction.GetTarget.transform.position.x <= transform.position.x)
            {
                Vector3 rotate = transform.eulerAngles;
                rotate.y = 180;
                transform.rotation = Quaternion.Euler(rotate);
            }
            else
            {
                Vector3 rotate = transform.eulerAngles;
                rotate.y = 0;
                transform.rotation = Quaternion.Euler(rotate);
            }
        }
        private void OnChangeEnemyStateMove()
        {
            EnemyStateMachine.ChangeState(EnemyMoveState);
        }
        private void OnChangeEnemyStateIdle()
        {
            EnemyStateMachine.ChangeState(EnemyIdleState);
        }
        private void OnChangeEnemyAttackState()
        {
            EnemyStateMachine.ChangeState(EnemyAttackState);
        }

    }
}

