using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ShopItemReference", order = 1)]
public class ShopItemReference : ScriptableObject
{
	[SerializeField]
	private List<ShopItem> itemList;
}
