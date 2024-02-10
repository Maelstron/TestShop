using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField]
    private List<ShopItem> shopItems;
    [SerializeField]
    private GameObject shopkeeper;
    [SerializeField]
    private GameObject interactionNotice;
    [SerializeField]
    private float interactionDistance = 6.0f;

    public static ShopManager instance = null;

	public List<ShopItem> ShopItems { get => shopItems; }

	private void Awake()
    {
        if (ShopManager.instance == null)
        {
            ShopManager.instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (interactionNotice.activeSelf)
        {
            Vector3 distance = shopkeeper.transform.position - GameManager.instance.Player.transform.position;
            if (distance.sqrMagnitude >= interactionDistance)
            {
                interactionNotice.SetActive(false);
            }
        }
        else
        {
            Vector3 distance = shopkeeper.transform.position - GameManager.instance.Player.transform.position;
            if (distance.sqrMagnitude < interactionDistance)
            {
                interactionNotice.SetActive(true);
            }
        }
    }


    public bool CanPurchaseItem(ShopItem selectedItem, int quantity = 1)
	{
        PlayerCharacter player = GameManager.instance.Player;
        if (!player)
		{
            return false;
		}
		if (player.Inventory.Money < selectedItem.BuyPrice)
		{
            return false;
		}
        // TODO check inventory space.
		return true;
	}

    public void PurchaseItem(ShopItem selectedItem)
	{
        selectedItem.AvailableQuantity--;
        if (selectedItem.AvailableQuantity == 0)
		{
            ShopItems.Remove(selectedItem);
		}
        GameManager.instance.Player.Inventory.ItemList.Add(selectedItem);
        GameManager.instance.Player.Inventory.Money -= selectedItem.BuyPrice;
    }

    public void SellItem(ShopItem selectedItem, int quantity = 1)
    {
        ShopItem listItem = ShopItems.Find(item => item.Equals(selectedItem));
        if (listItem == null)
		{
            ShopItems.Add(selectedItem);
            selectedItem.AvailableQuantity = quantity;
		}
		else
		{
            selectedItem.AvailableQuantity += quantity;
        }
        GameManager.instance.Player.Inventory.ItemList.Remove(selectedItem);
        GameManager.instance.Player.Inventory.Money += selectedItem.SellPrice;
    }

    public bool CanInitiateShop()
	{
        return interactionNotice.activeSelf;
	}
}
