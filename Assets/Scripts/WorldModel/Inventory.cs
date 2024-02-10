using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
class Inventory
{
	[SerializeField]
	private List<ShopItem> itemList;
	[SerializeField]
	private int money;

	public List<ShopItem> ItemList { get => itemList; set => itemList = value; }
	public int Money { get => money; set => money = value; }
}
