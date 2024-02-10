using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInputHandler : IInputHandler
{
	[SerializeField]
	private ShopNavigationController shopController;

	public override void OnKeyPressed(KeyCode key)
	{
		switch (key)
		{
			case KeyCode.X:
			{
				shopController.IsOnPlayerSide = !shopController.IsOnPlayerSide;
				break;
			}
			case KeyCode.DownArrow:
			{
				if (shopController.SelectionIndex > 11)
				{
					shopController.SelectionIndex -= 12;
				}
				else
				{
					shopController.SelectionIndex += 4;
				}
				break;
			}
			case KeyCode.UpArrow:
			{
				if (shopController.SelectionIndex < 4)
				{
					shopController.SelectionIndex += 12;
				}
				else
				{
					shopController.SelectionIndex -= 4;
				}
				break;
			}
			case KeyCode.RightArrow:
			{
				if (shopController.SelectionIndex % 4 == 3)
				{
					shopController.SelectionIndex -= 3;
				}
				else
				{
					shopController.SelectionIndex += 1;
				}
				break;
			}
			case KeyCode.LeftArrow:
			{
				if (shopController.SelectionIndex % 4 == 0)
				{
					shopController.SelectionIndex += 3;
				}
				else
				{
					shopController.SelectionIndex -= 1;
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
