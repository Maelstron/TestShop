using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopNavigationController : MonoBehaviour
{
    [SerializeField]
    private List<Image> playerInventoryDisplay;
    [SerializeField]
    private List<Image> shopInventoryDisplay;
    [SerializeField]
    private Image selectionCursor;

    private int selectionIndex = 0;
    private bool isOnPlayerSide = false;

	public int SelectionIndex { get => selectionIndex; set => selectionIndex = value; }
	public bool IsOnPlayerSide { get => isOnPlayerSide; set => isOnPlayerSide = value; }

	// Start is called before the first frame update
	void Start()
    {
        UpdateState();
        UpdateCursorColor();
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
            if (displayIndex < ShopManager.instance.ShopItems.Count)
            {
                item = ShopManager.instance.ShopItems[displayIndex];
                shopInventoryDisplay[displayIndex].sprite = item.ItemIcon;
                shopInventoryDisplay[displayIndex].color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            }
			else
			{
                shopInventoryDisplay[displayIndex].sprite = null;
                shopInventoryDisplay[displayIndex].color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
            }
        }

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
        if (isOnPlayerSide)
		{
            selectionCursor.transform.position = playerInventoryDisplay[selectionIndex].transform.position;
        }
        else
        {
            selectionCursor.transform.position = shopInventoryDisplay[selectionIndex].transform.position;
            
        }
    }
    
    public void UpdateCursorColor()
	{
        if (!IsOnPlayerSide)
        {
            if (selectionIndex >= ShopManager.instance.ShopItems.Count)
            {
                selectionCursor.color = new Color(1.0f, 0.0f, 0.0f);
                return;
            }
            ShopItem item = ShopManager.instance.ShopItems[selectionIndex];
            if (GameManager.instance.Player.Inventory.Money < item.BuyPrice)
            {
                selectionCursor.color = new Color(1.0f, 0.0f, 0.0f);
                return;
            }
        }
        selectionCursor.color = new Color(1.0f, 1.0f, 0.0f);

    }

    public void BuySellSelectedItem()
    {
        if (IsOnPlayerSide)
        {
            // Sell
            if (selectionIndex < GameManager.instance.Player.Inventory.ItemList.Count)
            {
                ShopItem item = GameManager.instance.Player.Inventory.ItemList[selectionIndex];
                ShopManager.instance.SellItem(item);
            }
        }
        else
        {
            // Buy
            if (selectionIndex < ShopManager.instance.ShopItems.Count)
            {
                ShopItem item = ShopManager.instance.ShopItems[selectionIndex];
                ShopManager.instance.PurchaseItem(item);
            }
        }
    }
}
