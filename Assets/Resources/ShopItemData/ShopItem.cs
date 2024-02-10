using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ShopItem", order = 2)]
[Serializable]
public class ShopItem : ScriptableObject, IEquatable<ShopItem>
{
	[SerializeField]
	private string itemName;
	[SerializeField]
	private string description;
	[SerializeField]
	private Sprite itemIcon;
	[SerializeField]
	private int availableQuantity;
	[SerializeField]
	private int buyPrice;
	[SerializeField]
	private int sellPrice;

	public string ItemName { get => itemName; }
	public string Description { get => description; }
	public Sprite ItemIcon { get => itemIcon; }
	public int AvailableQuantity { get => availableQuantity; set => availableQuantity = value; }
	public int BuyPrice { get => buyPrice; }
	public int SellPrice { get => sellPrice; }

	public bool Equals(ShopItem other)
	{
		return this.name == other.name;
	}
}
