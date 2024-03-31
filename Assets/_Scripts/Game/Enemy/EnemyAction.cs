using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using TopDownShooter.Gameplay;
using TopDownShooter.Interface;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace TopDownShooter.Gameplay
{
    public class EnemyAction : MonoBehaviour, IFindingTarget
    {
        [SerializeField] private Collider[] targetsCollider;
        [SerializeField] private GameObject target;
        [SerializeField] private Enemy enemy;

        private int characterLayerMask = 1 << 7;
        private float attackTimer;

        public Action moveFromTarget;
        public Action idleState;
        public Action attackTarget;

        public GameObject GetTarget
        {
            get => target;
        }
        private void Update()
        {
            TrackTarget(transform.position, enemy.GetVisionRange);

            if (target != null )
            {
                MoveToTarget();
            }
        }
        public void FindTarget(Vector2 unitPosition, float radius)
        {
            targetsCollider = Physics.OverlapSphere(unitPosition, radius, characterLayerMask);
            if (targetsCollider.Length > 0)
            {
                target = targetsCollider[0].gameObject;
                Debug.Log("Enemy Found Target");
                moveFromTarget?.Invoke();
            }
        }
        public void TrackTarget(Vector2 unitPosition, float radius)
        {
            if (target == null)
            {
                FindTarget(transform.position, enemy.GetVisionRange);
            }
            else
            {
                Vector2 targetPosition = target.transform.position;
                if ((float)(Math.Round(Vector2.Distance(unitPosition, targetPosition), 0)) > radius)
                {
                    target = null;
                    idleState?.Invoke();
                }
                else
                {
                    moveFromTarget?.Invoke();
                }
            }
        }
        private void MoveToTarget()
        {
            if (CheckDistanceNearEnemyAndTarget(target.transform.position, transform.position) > enemy.GetAttackRange)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.transform.position, enemy.MoveSpeedValue * Time.deltaTime);
            }
            else
            {
                SetCharacterHealth(enemy.AttackValue);
            }
        }
        public void SetCharacterHealth(int damage)
        {
            attackTarget?.Invoke();
            attackTimer += Time.deltaTime;
            if(attackTimer >= 60f/enemy.GetAttackPerMin)
            {
                Character character = target.GetComponent<Character>();
                character.HealthValue -= damage;
                attackTimer = 0;
            }
        }
        private float CheckDistanceNearEnemyAndTarget(Vector2 targetPosition, Vector2 unitPosition)
        {
            return Vector2.Distance(unitPosition, targetPosition);
        }
        private void OnDrawGizmos()
        {
            Vector2 position = transform.position;
            float visionRange = enemy.GetVisionRange;
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(position, visionRange);
        }
    }
}
