using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using TMPro;
using static UnityEditor.Timeline.Actions.MenuPriority;
using Unity.VisualScripting;

namespace TopDownShooter.Gameplay
{
    public class ItemSlot : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private GameObject inventoryItem;
        [SerializeField] private GameObject button;
        [SerializeField] private GameObject character;
        [SerializeField] private CharacterAction characterAction;
        [SerializeField] private int id;
        [SerializeField] private string itemName;
        [SerializeField] private int countItem;

        private Inventory inventory;
        private bool enabledButton = false;

        public string ItemName
        {
            get => itemName;
            set => itemName = value;
        }
        public int GetId
        {
            get => id;
        }
        public int CountItem
        {
            get => countItem;
            set => countItem = value;
        }
        private void Awake()
        {
            button = inventoryItem.transform.GetChild(3).gameObject;
            character = GameObject.FindGameObjectWithTag("Character");
            inventory = character.GetComponent<Inventory>();
            characterAction = character.GetComponent<CharacterAction>();
        }
        private void OnEnable()
        {
            characterAction.takeShot += WasteAmmo;
        }
        private void OnDisable()
        {
            characterAction.takeShot -= WasteAmmo;
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            enabledButton = !enabledButton;
            button.SetActive(enabledButton);
        }
        public void OnDeleteItemInInventory()
        {
            DeleteItemInInventory();
        }
        private void DeleteItemInInventory()
        {
            List<GameObject> list = inventory.GetInventorySlots;
            var image = list[id].transform.GetChild(0).GetComponent<Image>();
            image.color = new Color(255, 255, 255, 0);
            image.sprite = null;
            inventory.IdInventorySlot = id;
            var countItemGO = list[id].transform.GetChild(2);
            countItemGO.gameObject.SetActive(false);
            var countItemText = countItemGO.GetComponent<TextMeshProUGUI>();
            countItemText.text = "0";
            countItem = 0;
            inventory.SlotInInventory.Remove(itemName);
            itemName = "";
        }
        private void WasteAmmo()
        {
            if(itemName != "Bullets")
            {
                return;
            }
            else
            {
                countItem--;
                var countItemGO = transform.GetChild(2);
                var countItemText = countItemGO.GetComponent<TextMeshProUGUI>();
                countItemText.text = countItem.ToString();
            }
        }
    }
}
