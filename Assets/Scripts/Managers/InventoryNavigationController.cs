using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryNavigationController : MonoBehaviour
{
    [SerializeField]
    private List<Image> playerInventoryDisplay;
    [SerializeField]
    private Image selectionCursor;
    [SerializeField]
    private GameObject armorDisplay;

    private int selectionIndex = 0;

	private bool isOnBackpack = true;

    public int SelectionIndex { get => selectionIndex; set => selectionIndex = value; }
    public bool IsOnBackpack { get => isOnBackpack; set => isOnBackpack = value; }

    // Start is called before the first frame update
    void Start()
    {
        UpdateState();
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void UpdateState()
    {
        ShopItem item = null;
        for (int displayIndex = 0; displayIndex < 16; displayIndex++)
        {
            if (displayIndex < GameManager.instance.Player.Inventory.ItemList.Count)
            {
                item = GameManager.instance.Player.Inventory.ItemList[displayIndex];
                playerInventoryDisplay[displayIndex].sprite = item.ItemIcon;
                playerInventoryDisplay[displayIndex].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
            else
            {
                playerInventoryDisplay[displayIndex].sprite = null;
                playerInventoryDisplay[displayIndex].color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            }
        }
        if (isOnBackpack)
        {
            selectionCursor.transform.position = playerInventoryDisplay[selectionIndex].transform.position;
        }
        else
        {
            selectionCursor.transform.position = armorDisplay.transform.position;

        }
    }

    public void Interact()
    {
        if (isOnBackpack)
		{
            Debug.Log("Interact - index:" + selectionIndex + "count: " + GameManager.instance.Player.Inventory.ItemList.Count);
            // Maybe equip.
            if (selectionIndex < GameManager.instance.Player.Inventory.ItemList.Count)
			{
                ShopItem item = GameManager.instance.Player.Inventory.ItemList[selectionIndex];
                if (item.CanEquip)
				{
                    Debug.Log("Can quip.");
                    GameManager.instance.Player.Equipment.EquipOutfit(item);
                    GameManager.instance.Player.UpdateOutfit();
                    armorDisplay.GetComponent<Image>().sprite = item.ItemIcon;
                }
			}
        }
		else
		{
            // De-equip armor.
            GameManager.instance.Player.Equipment.EquipOutfit(GameManager.instance.Player.DefaultOutfit);
            GameManager.instance.Player.UpdateOutfit();
        }
    }
}
