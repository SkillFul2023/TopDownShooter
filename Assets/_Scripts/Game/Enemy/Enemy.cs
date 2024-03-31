using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Animation;
using TopDownShooter.Enums;
using TopDownShooter.Interface;
using Unity.VisualScripting;
using UnityEngine;
namespace TopDownShooter.Gameplay
{
    public class Enemy : Unit, IDropItem
    {
        [SerializeField] private EnemyStateEnum enemyStateEnum;
        [SerializeField] private float attackRange;
        [SerializeField] private float attackPerMin;
        [SerializeField] private EnemyAnimationHelper enemyAnimationHelper;
        [SerializeField] private LegsAnimationHelper legsAnimationHelper;
        [SerializeField] private EnemyAction enemyAction;
        [SerializeField] private LootFromEnemy lootFromEnemy;

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
        public float GetAttackPerMin
        {
            get => attackPerMin;
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
            DropItem();
            Destroy(gameObject);
        }
        public void DropItem()
        {
            int allItemChance = 0;
            int i = 0;
            int j = 0;

            Dictionary<int, int[]> rangeItemDropChance = new Dictionary<int, int[]>();
            
            foreach (GameObject item in lootFromEnemy.GetDropItem)
            {
                int dropChance = item.GetComponent<Item>().GetDropChance;

                int rangeFirstValue = 0 + allItemChance;
                int rangeLastValue = rangeFirstValue + dropChance;

                int[] range = new int[2];
                range[0] = rangeFirstValue + 1; 
                range[1] = rangeLastValue;

                rangeItemDropChance.Add(i, range);
                allItemChance += dropChance;
                i++;
            }
            var randonNumber = Random.Range(0, allItemChance);
            Debug.Log("Item drop " + randonNumber.ToString());

            foreach (var k in rangeItemDropChance)
            {
                if (k.Value[0] <= randonNumber && k.Value[1] >= randonNumber)
                {
                    break;
                }
                else
                {
                    j++;
                    continue;
                }
            }

            Instantiate(lootFromEnemy.GetDropItem[j], transform.position, transform.rotation);

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

