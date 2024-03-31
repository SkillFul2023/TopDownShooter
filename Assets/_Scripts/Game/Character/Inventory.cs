using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Progress;
using Image = UnityEngine.UI.Image;

namespace TopDownShooter.Gameplay
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private GameObject inventory;
        [SerializeField] private CharacterAction characterAction;
        [SerializeField] private GameObject startItem;
        [SerializeField] private List<GameObject> inventorySlots;

        private Dictionary<string, List<int>> slotInInventory = new Dictionary<string, List<int>>();
        private int idInventorySlot = 0;

        public Dictionary<string, List<int>> SlotInInventory
        {
            get => slotInInventory;
            set => slotInInventory = value;
        }
        public List<GameObject> GetInventorySlots
        {
            get => inventorySlots;
        }
        public int IdInventorySlot
        {
            get => idInventorySlot;
            set => idInventorySlot = value;
        }
        private void Awake()
        {
            inventory = GameObject.FindGameObjectWithTag("Inventory");
        }
        private void Start()
        {
            for (int i = 0; i < inventory.transform.childCount; i++)
            {
                inventorySlots.Add(inventory.transform.GetChild(i).gameObject);
            }
            OnAddItemInInvenotry(startItem, false);
        }
        private void OnEnable()
        {
            characterAction.addItemInInventory += OnAddItemInInvenotry;
        }
        private void OnDisable()
        {
            characterAction.addItemInInventory -= OnAddItemInInvenotry;
        }
        private void OnAddItemInInvenotry(GameObject item, bool destroy)
        {
            Item addItem = item.GetComponent<Item>();
            var key = addItem.GetNameItem.ToString();
            List<int> listSlotCount = new List<int>
            {
                idInventorySlot,
                addItem.GetCountItem
            };

            if (slotInInventory.ContainsKey(key))
            {
                var list = slotInInventory[key];
                int slotNumber = list[0];
                int countItem = inventorySlots[slotNumber].GetComponent<ItemSlot>().CountItem + addItem.GetCountItem;
                listSlotCount.Clear();

                List<int> listSlotCountNew = new List<int>
                {
                    slotNumber,
                    countItem
                };
                var inventorySlotGO = inventorySlots[slotNumber].GetComponent<ItemSlot>();
                inventorySlotGO.CountItem = countItem;
                slotInInventory.Remove(key);
                slotInInventory.Add(key, listSlotCountNew);
                var countItemGO = inventorySlots[slotNumber].transform.GetChild(2);
                countItemGO.gameObject.SetActive(true);
                var countItemText = countItemGO.GetComponent<TextMeshProUGUI>();
                countItemText.text = countItem.ToString();
                Destroy(item);
            }
            else
            {
                slotInInventory.Add(addItem.GetNameItem.ToString(), listSlotCount);
                var inventorySlotGO = inventorySlots[idInventorySlot].GetComponent<ItemSlot>();
                inventorySlotGO.ItemName = addItem.GetNameItem.ToString();
                inventorySlotGO.CountItem = addItem.GetCountItem;
                var image = inventorySlots[idInventorySlot].transform.GetChild(0).GetComponent<Image>();
                var countItemGO = inventorySlots[idInventorySlot].transform.GetChild(2);
                if(destroy == false | inventorySlotGO.CountItem > 1)
                {
                    countItemGO.gameObject.SetActive(true);
                }
                var countItemText = countItemGO.GetComponent<TextMeshProUGUI>();
                countItemText.text = addItem.GetCountItem.ToString();
                image.color = new Color(255, 255, 255, 255);
                image.sprite = addItem.GetItemSprite;
                idInventorySlot++;

                foreach (var slot in inventorySlots)
                {
                    var itemUI = slot.GetComponent<ItemSlot>();
                    if (itemUI.GetId >= idInventorySlot)
                    {
                        if (itemUI.ItemName == "")
                        {
                            break;
                        }
                        else
                        {
                            idInventorySlot++;
                            continue;
                        }
                    }
                    else
                    { 
                        continue; 
                    }
                }
                if (destroy)
                {
                    Destroy(item);
                }
            }
        }
    }
}
