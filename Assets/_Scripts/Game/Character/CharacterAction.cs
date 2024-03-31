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

        private Inventory inventory;
        private int enemyLayerMask = 1 << 6;

        public Action characterReadyForAttackState;
        public Action characterIdleState;
        public Action<GameObject, bool> addItemInInventory;
        public Action takeShot;

        private void Awake()
        {
            inventory = GetComponent<Inventory>();
        }
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
                characterReadyForAttackState?.Invoke();
            }
            else
            {
                characterIdleState?.Invoke();
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
                    characterIdleState?.Invoke();
                }
            }
        }
        public void OnAttackTarget_EditorEvent()
        {
            if (target != null)
            {
                foreach(GameObject inventorySlot in inventory.GetInventorySlots)
                {
                    ItemSlot itemSlot = inventorySlot.GetComponent<ItemSlot>();
                    if(itemSlot.ItemName != "Bullets" )
                    {
                        continue;
                    }
                    else
                    {
                        if(itemSlot.CountItem > 0)
                        {
                            takeShot?.Invoke();
                            SetEnemyHealth(character.AttackValue, target);
                            break;
                        }
                        else
                        {
                            Debug.Log("No ammo");
                            break;
                        }
                    }
                }
            }            
        }
        public void SetEnemyHealth(int damage, GameObject target)
        {
            Debug.Log("Attack");
            Enemy enemy = target.GetComponent<Enemy>();
            enemy.HealthValue -= damage;
        }
        private void OnTriggerEnter(Collider collider)
        {
            if(collider.gameObject.tag == "Item")
            {
                CatchUpItem(collider.gameObject);
            }
        }
        private void CatchUpItem(GameObject item)
        {
            addItemInInventory?.Invoke(item, true);
            //Destroy(item);
            Debug.Log("Catch Up Item");
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

