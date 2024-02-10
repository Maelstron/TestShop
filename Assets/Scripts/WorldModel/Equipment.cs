using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Equipment
{
	private ShopItem hat;
	private ShopItem outfit;

	public Equipment()
	{
		hat = null;
		outfit = null;
	}

	public ShopItem Hat { get => hat;}
	public ShopItem Outfit { get => outfit; }

	/// <summary>
	/// Equips the player with a new hat. If null, the hat will be dequipped.
	/// </summary>
	/// <param name="item">Either the reference to the hat or null to remove the currently equipped one.</param>
	public void EquipHat(ShopItem item)
	{
		hat = item;
	}

	/// <summary>
	/// Equips the player with a new outfit. To remove the used outfit, the player need to equip the default one or a new one.
	/// </summary>
	/// <param name="item"> The outfit to be equipped. Since the character cannot be naked, to remove the equiped outfit, instead the caller needs to equip the default outfit</param>
	public void EquipOutfit(ShopItem item)
	{
		if (item == null)
		{
			throw new InvalidOperationException("Characters cannot have a null outfit.");
		}
		outfit = item;
	}
}
