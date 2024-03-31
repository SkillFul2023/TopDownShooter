using Microsoft.Unity.VisualStudio.Editor;
using TopDownShooter.Enums;
using UnityEngine;

namespace TopDownShooter.Gameplay
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private ItemStats itemStats;
        [SerializeField] private SpriteRenderer itemSprite;

        public ItemNameEnum GetNameItem
        {
            get => itemStats.name;
        }
        public int GetCountItem
        {
            get => itemStats.countItem;
        }
        public int GetIdItem
        {
            get => itemStats.idItem;
        }
        public int GetDropChance
        {
            get => itemStats.dropChance;
        }
    }
}

