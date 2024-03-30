using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace TopDownShooter.Gameplay
{
    public abstract class Unit : MonoBehaviour
    {
        [SerializeField] private Stats stats;
        [SerializeField] protected GameObject healthBar;
        [SerializeField] protected Image currentHealth;

        public int HealthValue
        {
            get => stats.healthValue;
            set => stats.healthValue = value;
        }
        public int AttackValue
        {
            get => stats.attackValue;
            set => stats.attackValue = value;
        }
        public float MoveSpeedValue
        {
            get => stats.moveSpeed;
            set => stats.moveSpeed = value;
        }
        public int GetMaxHealthValue
        {
            get => stats.maxHealtValue;
        }
        public float GetVisionRange
        {
            get => stats.visionRange;
        }
    }
}
