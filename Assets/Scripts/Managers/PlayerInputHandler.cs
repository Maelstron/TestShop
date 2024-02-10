using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputHandler : IInputHandler
{
	[SerializeField]
	private PlayerCharacter playerCharacter;
	public override void OnKeyPressed(KeyCode key)
	{
		throw new System.NotImplementedException();
	}

	public override void OnKeyReleased(KeyCode key)
	{
		throw new System.NotImplementedException();
	}

	public override void UpdateDirectionalInput(float horizontalAxis, float verticalaxis)
	{
		playerCharacter.UpdateAnimationFromMovement(horizontalAxis, verticalaxis);
	}
}
