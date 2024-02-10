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
			case KeyCode.X:
			{
				inventoryController.IsOnPlayerSide = !inventoryController.IsOnPlayerSide;
				break;
			}
			case KeyCode.DownArrow:
			{
				if (inventoryController.SelectionIndex > 11)
				{
					inventoryController.SelectionIndex -= 12;
				}
				else
				{
					inventoryController.SelectionIndex += 4;
				}
				break;
			}
			case KeyCode.UpArrow:
			{
				if (inventoryController.SelectionIndex < 4)
				{
					inventoryController.SelectionIndex += 12;
				}
				else
				{
					inventoryController.SelectionIndex -= 4;
				}
				break;
			}
			case KeyCode.RightArrow:
			{
				if (inventoryController.SelectionIndex % 4 == 3)
				{
					inventoryController.SelectionIndex -= 3;
				}
				else
				{
					inventoryController.SelectionIndex += 1;
				}
				break;
			}
			case KeyCode.LeftArrow:
			{
				if (inventoryController.SelectionIndex % 4 == 0)
				{
					inventoryController.SelectionIndex += 3;
				}
				else
				{
					inventoryController.SelectionIndex -= 1;
				}
				break;
			}
		}
	}

	public override void OnKeyReleased(KeyCode key)
	{
	}

	public override void UpdateDirectionalInput(float horizontalAxis, float verticalaxis)
	{
	}
}
