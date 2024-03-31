using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace TopDownShooter.Gameplay
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private CharacterAction characterAction;
        [SerializeField] private List<GameObject> itemGO;
        [SerializeField] private Dictionary<string, int> itemInInventory; //= new List<Dictionary<Item, int>>();

        private void OnEnable()
        {
            characterAction.addItemInInventory += OnAddItemInInvenotry;
        }
        private void OnDisable()
        {
            characterAction.addItemInInventory -= OnAddItemInInvenotry;
        }

        private void OnAddItemInInvenotry(GameObject item)
        {
            Item addItem = item.GetComponent<Item>();
            itemGO.Add(item);

            itemInInventory.Add(addItem.GetNameItem.ToString(), addItem.GetCountItem);
        }
    }
}
