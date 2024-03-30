using System;
using TopDownShooter.Interface;
using UnityEngine;

namespace TopDownShooter.Gameplay
{
    public class CharacterAction : MonoBehaviour, IFindingTarget
    {
        [SerializeField] private Collider[] targetsCollider;
        [SerializeField] private GameObject target;
        [SerializeField] private Character character;

        private int enemyLayerMask = 1 << 6;

        public Action addEnemyInTargetCollider;
        public Action removeEnemyInTargetCollider;

        private void Update()
        {
            TrackTarget(transform.position, character.GetVisionRange);
        }
        public void FindTarget(Vector2 unitPosition, float radius)
        {
            targetsCollider = Physics.OverlapSphere(unitPosition, radius, enemyLayerMask);
            if (targetsCollider.Length > 0)
            {
                target = targetsCollider[0].gameObject;
                Debug.Log("TargetFind");
                addEnemyInTargetCollider?.Invoke();
            }
        }
        public void TrackTarget(Vector2 unitPosition, float radius)
        {
            if (target == null)
            {
                FindTarget(transform.position, character.GetVisionRange);
            }
            else
            {
                Vector2 targetPosition = target.transform.position;
                if ((float)(Math.Round(Vector2.Distance(unitPosition, targetPosition), 0)) > radius)
                {
                    target = null;
                    removeEnemyInTargetCollider?.Invoke();
                }
            }
        }
        public void OnAttackTarget_EditorEvent()
        {
            if (target != null)
            {
                SetHealth(character.AttackValue);
            }            
        }

        public void SetHealth(int damage)
        {
            Enemy enemy = target.GetComponent<Enemy>();
            enemy.HealthValue -= damage;
        }
        private void OnDrawGizmos()
        {
            Vector2 position = transform.position;
            float visionRange = character.GetVisionRange;
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(position, visionRange);
        }
    }
}

