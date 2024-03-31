using System.Collections;
using System.Collections.Generic;
using TopDownShooter.Interface;
using UnityEngine;

namespace TopDownShooter.Gameplay
{
    public class LootFromEnemy : MonoBehaviour
    {
        [SerializeField] private List<GameObject> dropItems;
        public List<GameObject> GetDropItem
        {
            get => dropItems;
        }
    }

}
