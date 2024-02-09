using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField]
    private List<ShopItem> shopItems;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CanPurchaseItem(ShopItem selectedItem)
	{
        //if ()
	}

    public void PurchaseItem(ShopItem selectedItem)
	{
        selectedItem.AvailableQuantity--;
        if (selectedItem.AvailableQuantity == 0)
		{
            shopItems.Remove(selectedItem);
		}
    }

    public void SellItem(ShopItem selectedItem)
    {
        ShopItem listItem = shopItems.Find(item => item.Equals(selectedItem));
        if (listItem == null)
		{
            shopItems.Add(selectedItem);
            selectedItem.AvailableQuantity = 1;
		}
		else
		{
            selectedItem.AvailableQuantity++;
        }
    }
}
