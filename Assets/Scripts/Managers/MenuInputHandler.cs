using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInputHandler : IInputHandler
{
	[SerializeField]
	private InventoryNavigationController inventoryController;

	public override void OnKeyPressed(KeyCode key)
	{
		switch (key)
		{
			case KeyCode.Z:
			{
				inventoryController.Interact();
				break;
			}
			case KeyCode.C:
			{
				GameManager.instance.CloseInventoryDialog();
				break;
			}
			case KeyCode.DownArrow:
			{
				if (inventoryController.IsOnBackpack)
				{
					if (inventoryController.SelectionIndex > 11)
					{
						inventoryController.SelectionIndex -= 12;
					}
					else
					{
						inventoryController.SelectionIndex += 4;
					}
				}
				break;
			}
			case KeyCode.UpArrow:
			{
				if (inventoryController.IsOnBackpack)
				{
					if (inventoryController.SelectionIndex < 4)
					{
						inventoryController.SelectionIndex += 12;
					}
					else
					{
						inventoryController.SelectionIndex -= 4;
					}
				}
				break;
			}
			case KeyCode.RightArrow:
			{
				if (!inventoryController.IsOnBackpack)
				{
					inventoryController.IsOnBackpack = true;
				}
				else if (inventoryController.SelectionIndex % 4 == 3)
				{
					inventoryController.SelectionIndex -= 3;
					inventoryController.IsOnBackpack = false;
				}
				else
				{
					inventoryController.SelectionIndex += 1;
				}
				break;
			}
			case KeyCode.LeftArrow:
			{
				if (!inventoryController.IsOnBackpack)
				{
					inventoryController.IsOnBackpack = true;
				}
				else if (inventoryController.SelectionIndex % 4 == 0)
				{
					inventoryController.SelectionIndex += 3;
					inventoryController.IsOnBackpack = false;
				}
				else
				{
					inventoryController.SelectionIndex -= 1;
				}
				break;
			}
		}
		inventoryController.UpdateState();
	}

	public override void OnKeyReleased(KeyCode key)
	{
	}

	public override void UpdateDirectionalInput(float horizontalAxis, float verticalaxis)
	{
	}
}
